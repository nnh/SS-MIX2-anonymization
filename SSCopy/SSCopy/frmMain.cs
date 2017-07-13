using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SSCopy
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        private string StrMain_ErrorMessage;

        public frmMain()
        {
            InitializeComponent();

            lblProgress.Text = "";
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {

            if (cmdCopy.Text == "中止")
            {
                //中止

            }

            lblProgress.Text = "";
            cmdCopy.Text = "中止";
            cmdCopy.Refresh();
            txtStorage.Enabled = false;
            cmdStorage.Enabled = false;
            txtDays.Enabled = false;
            txtCopyFolder.Enabled = false;
            cmdCopyFolder.Enabled = false;
            cmdExit.Enabled = false;
            //コピー
            bool blnReturn = CopySSMIX();
            if (blnReturn == false)
            {
                MessageBox.Show(StrMain_ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("コピーが完了しました。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cmdCopy.Text = "コピー";
            cmdCopy.Refresh();
            txtStorage.Enabled = true;
            cmdStorage.Enabled = true;
            txtDays.Enabled = true;
            txtCopyFolder.Enabled = true;
            cmdCopyFolder.Enabled = true;
            cmdExit.Enabled = true;


        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            //閉じる
            this.Close();
        }

        private bool CopySSMIX()
        {
            Random rndRandom = new Random();
            DateTime datNow = DateTime.Now;
            Dictionary<string, string> dicDataKinds = new Dictionary<string, string>();
            bool blnAllDataKindFlg;
            Dictionary<string, string> dicPatientIds = new Dictionary<string, string>();
            int intCopyCount = 0;
            //SS-MIXストレージ
            if (Directory.Exists(txtStorage.Text) == false)
            {
                //フォルダなし
                StrMain_ErrorMessage = "SS-MIXストレージが見つかりません。";
                return false;
            }
            //取り込み日数
            int intDays;
            if (int.TryParse(txtDays.Text, out intDays) == false)
            {
                //日数不正
                StrMain_ErrorMessage = "取り込み日数が正しくありません。";
                return false;
            }
            //取り込みデータ種別
            blnAllDataKindFlg = true;
            foreach (Control ctrDataKind in grpDataKind.Controls)
            {
                if (typeof(CheckBox) == ctrDataKind.GetType())
                {
                    //チェックボックス
                    CheckBox chkDataKind = (CheckBox)ctrDataKind;
                    if (chkDataKind.Checked == true)
                    {
                        //選択
                        if (dicDataKinds.ContainsKey((string)chkDataKind.Tag) == false)
                        {
                            dicDataKinds.Add((string)chkDataKind.Tag, (string)chkDataKind.Tag);
                        }
                    }
                    else
                    {
                        //未選択
                        blnAllDataKindFlg = false;
                    }
                }
            }
            if (dicDataKinds.Count == 0)
            {
                //全て未選択
                StrMain_ErrorMessage = "取り込みデータ種別が選択されていません。";
                return false;
            }
            //コピー先フォルダー
            if (Directory.Exists(txtCopyFolder.Text) == false)
            {
                //フォルダなし
                StrMain_ErrorMessage = "コピー先が見つかりません。";
                return false;
            }
            //ソルト
            if (txtHashSalt.Text.Length == 0)
            {
                //ソルトなし
                StrMain_ErrorMessage = "ソルトが入力されていません。";
                return false;
            }
            //ストレッチング回数
            int intStretchingCount;
            if (int.TryParse(txtHashStretching.Text, out intStretchingCount) == false)
            {
                //ストレッチング回数
                StrMain_ErrorMessage = "ストレッチング回数が正しくありません。";
                return false;
            }
            //患者IDリスト
            if (txtPatientIdList.Text.Trim() != "")
            {
                string[] strPatientIds = txtPatientIdList.Text.Split(new string[] {"\r\n"}, StringSplitOptions.None);
                foreach (string strPatientId in strPatientIds)
                {
                    if (strPatientId.Trim() != "")
                    {
                        if (dicPatientIds.ContainsKey(strPatientId) == false)
                        {
                            //患者IDリストに追加
                            dicPatientIds.Add(strPatientId, strPatientId);
                        }
                    }
                }
            }
            DirectoryInfo dirCopyFolfer = new DirectoryInfo(txtCopyFolder.Text);
            //検索
            try
            {
                string strPatientId = "";
                string strHashPatientId = "";
                string strMedicalDate = "";
                System.Threading.Thread.Sleep(10);
                DirectoryInfo dirStorage = new DirectoryInfo(txtStorage.Text);
                //患者ID先頭3文字
                DirectoryInfo[] dirPatientIdTop3s = dirStorage.GetDirectories();
                foreach (DirectoryInfo dirPatientIdTop3 in dirPatientIdTop3s)
                {
                    //患者ID4～6文字
                    DirectoryInfo[] dirPatientId4to6s = dirPatientIdTop3.GetDirectories();
                    foreach (DirectoryInfo dirPatientId4to6 in dirPatientId4to6s)
                    {
                        //患者ID
                        DirectoryInfo[] dirPatientIds = dirPatientId4to6.GetDirectories();
                        foreach (DirectoryInfo dirPatientId in dirPatientIds)
                        {
                            if ((dicPatientIds.Count == 0) || (dicPatientIds.ContainsKey(dirPatientId.Name) == true))
                            {
                                //患者ID指定なし、または対象患者ID
                                //診療日
                                strMedicalDate = "";
                                DirectoryInfo[] dirMedicalDates = dirPatientId.GetDirectories();
                                foreach (DirectoryInfo dirMedicalDate in dirMedicalDates)
                                {
                                    DirectoryInfo dirCopyMedicalDate = null;
                                    bool blnTarget = false;
                                    if (strMedicalDate != dirMedicalDate.Name)
                                    {
                                        strMedicalDate = dirMedicalDate.Name;
                                        if (strMedicalDate.Length >= 8)
                                        {
                                            DateTime datMedicalDate;
                                            if (DateTime.TryParse(strMedicalDate.Substring(0, 4) + "-" + strMedicalDate.Substring(4, 2) + "-" + strMedicalDate.Substring(6, 2), out datMedicalDate) == true)
                                            {
                                                TimeSpan tmsTimeSpan = datNow - datMedicalDate;
                                                if (tmsTimeSpan.Days <= intDays)
                                                {
                                                    //取り込み日数内
                                                    blnTarget = true;
                                                }
                                            }
                                            else
                                            {
                                                //日付以外はとりあえず対象とする
                                                blnTarget = true;
                                            }
                                        }
                                        else
                                        {
                                            //日付以外はとりあえず対象とする
                                            blnTarget = true;
                                        }
                                    }
                                    if (blnTarget == true)
                                    {
                                        //取り込み対象日付
                                        //データ種別
                                        DirectoryInfo[] dirDataKinds = dirMedicalDate.GetDirectories();
                                        foreach (DirectoryInfo dirDataKind in dirDataKinds)
                                        {
                                            if ((blnAllDataKindFlg == true) || (dicDataKinds.ContainsKey(dirDataKind.Name) == true))
                                            {
                                                //取り込み対象データ種別フォルダ
                                                DirectoryInfo dirCopyPatientId = null;
                                                DirectoryInfo dirCopyDataKind = null;
                                                //データファイル
                                                FileInfo[] filDataFiles = dirDataKind.GetFiles();
                                                foreach (FileInfo filDataFile in filDataFiles)
                                                {
                                                    if (filDataFile.Name.Substring(filDataFile.Name.Length - 2, 2) == "_1")
                                                    {
                                                        //アクティブデータ
                                                        if (dirMedicalDate.Name == "-")
                                                        {
                                                            string[] strFileNames = filDataFile.Name.Split('_');
                                                            if (strFileNames.Length >= 5)
                                                            {
                                                                if (strFileNames[4].Length >= 8)
                                                                {
                                                                    DateTime datMedicalDate;
                                                                    if (DateTime.TryParse(strFileNames[4].Substring(0, 4) + "-" + strFileNames[4].Substring(4, 2) + "-" + strFileNames[4].Substring(6, 2), out datMedicalDate) == true)
                                                                    {
                                                                        TimeSpan tmsTimeSpan = datNow - datMedicalDate;
                                                                        if (tmsTimeSpan.Days > intDays)
                                                                        {
                                                                            //取り込み日数内以前
                                                                            blnTarget = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //ここでは日付以外は対象外とする
                                                                        blnTarget = false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //ここでは日付以外は対象外とする
                                                                    blnTarget = false;
                                                                }
                                                            }
                                                        }
                                                        if (blnTarget == true)
                                                        {
                                                            //データファイル読み込み
                                                            try
                                                            {
                                                                //-15～15のランダムなスライド日数
                                                                int intSlideDays = rndRandom.Next(-15, 15);
                                                                if (strPatientId != dirPatientId.Name)
                                                                {
                                                                    //患者の初回データ
                                                                    strPatientId = dirPatientId.Name;
                                                                    //コピー先患者ID（ハッシュ化）
                                                                    strHashPatientId = GetHashPatientId(strPatientId, txtHashSalt.Text.Trim(), intStretchingCount);
                                                                }
                                                                //患者IDフォルダ作成
                                                                //患者ID先頭3文字
                                                                string strPatientIdTop3 = strHashPatientId.Substring(0, 3);
                                                                DirectoryInfo dirCopyPatientIdTop3;
                                                                if (Directory.Exists(dirCopyFolfer.FullName + "\\" + strPatientIdTop3) == false)
                                                                {
                                                                    //フォルダなし
                                                                    //フォルダ作成
                                                                    dirCopyPatientIdTop3 = dirCopyFolfer.CreateSubdirectory(strPatientIdTop3);
                                                                }
                                                                else
                                                                {
                                                                    //フォルダあり
                                                                    dirCopyPatientIdTop3 = new DirectoryInfo(dirCopyFolfer.FullName + "\\" + strPatientIdTop3);
                                                                }
                                                                //患者ID4～6文字
                                                                string strPatientId4to6 = strHashPatientId.Substring(3, 3);
                                                                DirectoryInfo dirCopyPatientId4to6;
                                                                if (Directory.Exists(dirCopyPatientIdTop3.FullName + "\\" + strPatientId4to6) == false)
                                                                {
                                                                    //フォルダなし
                                                                    //フォルダ作成
                                                                    dirCopyPatientId4to6 = dirCopyPatientIdTop3.CreateSubdirectory(strPatientId4to6);
                                                                }
                                                                else
                                                                {
                                                                    //フォルダあり
                                                                    dirCopyPatientId4to6 = new DirectoryInfo(dirCopyPatientIdTop3.FullName + "\\" + strPatientId4to6);
                                                                }
                                                                //患者ID
                                                                if (Directory.Exists(dirCopyPatientId4to6.FullName + "\\" + strHashPatientId) == false)
                                                                {
                                                                    //フォルダなし
                                                                    //フォルダ作成
                                                                    dirCopyPatientId = dirCopyPatientId4to6.CreateSubdirectory(strHashPatientId);
                                                                }
                                                                else
                                                                {
                                                                    //フォルダあり
                                                                    dirCopyPatientId = new DirectoryInfo(dirCopyPatientId4to6.FullName + "\\" + strHashPatientId);
                                                                }
                                                                //診療日
                                                                string strSlideMedicalDate;
                                                                if (dirMedicalDate.Name.Length >= 8)
                                                                {
                                                                    strSlideMedicalDate = dirMedicalDate.Name.Substring(0, 4) + "-" + dirMedicalDate.Name.Substring(4, 2) + "-" + dirMedicalDate.Name.Substring(6, 2);
                                                                    DateTime datSlideMedicalDate;
                                                                    if (DateTime.TryParse(strSlideMedicalDate, out datSlideMedicalDate) == true)
                                                                    {
                                                                        //スライド日数分移動
                                                                        strSlideMedicalDate = datSlideMedicalDate.AddDays(intSlideDays).ToString("yyyyMMdd");
                                                                    }
                                                                    else
                                                                    {
                                                                        //日付変換できない場合はそのまま
                                                                        strSlideMedicalDate = dirMedicalDate.Name;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //日付変換できない場合はそのまま
                                                                    strSlideMedicalDate = dirMedicalDate.Name;
                                                                }
                                                                if (Directory.Exists(dirCopyPatientId.FullName + "\\" + strSlideMedicalDate) == false)
                                                                {
                                                                    //フォルダなし
                                                                    //フォルダ作成
                                                                    dirCopyMedicalDate = dirCopyPatientId.CreateSubdirectory(strSlideMedicalDate);
                                                                }
                                                                else
                                                                {
                                                                    //フォルダあり
                                                                    dirCopyMedicalDate = new DirectoryInfo(dirCopyPatientId.FullName + "\\" + strSlideMedicalDate);
                                                                }
                                                                //データ種別
                                                                if (Directory.Exists(dirCopyMedicalDate.FullName + "\\" + dirDataKind.Name) == false)
                                                                {
                                                                    //フォルダなし
                                                                    //フォルダ作成
                                                                    dirCopyDataKind = dirCopyMedicalDate.CreateSubdirectory(dirDataKind.Name);
                                                                }
                                                                else
                                                                {
                                                                    //フォルダあり
                                                                    dirCopyDataKind = new DirectoryInfo(dirCopyMedicalDate.FullName + "\\" + dirDataKind.Name);
                                                                }
                                                                //PIDセグメント削除
                                                                string strSSMIX = "";
                                                                using (StreamReader strDataFile = new StreamReader(filDataFile.FullName, System.Text.Encoding.GetEncoding("iso-2022-jp")))
                                                                {
                                                                    //読み込み
                                                                    strSSMIX = strDataFile.ReadToEnd();
                                                                    //ダミーデータ変換
                                                                    strSSMIX = ConvertDummyData(strSSMIX, strHashPatientId, intSlideDays);
                                                                }
                                                                if (strSSMIX.Length > 0)
                                                                {
                                                                    //ファイル出力（ファイル名をハッシュ化患者IDに変更）
                                                                    string strCopyDateFileName = strHashPatientId + filDataFile.Name.Substring(filDataFile.Name.IndexOf('_'));
                                                                    using (StreamWriter stwDateFile = new StreamWriter(dirCopyDataKind.FullName + "\\" + strCopyDateFileName, false, System.Text.Encoding.GetEncoding("iso-2022-jp")))
                                                                    {
                                                                        //書き込み
                                                                        stwDateFile.Write(strSSMIX);
                                                                    }
                                                                    //コピー数
                                                                    intCopyCount++;
                                                                    lblProgress.Text = "コピー数:" + intCopyCount.ToString();
                                                                }
                                                                else
                                                                {
                                                                    //ダミーデータ変換失敗
                                                                    StrMain_ErrorMessage = "ダミーデータの変換に失敗しました。";
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                //読み込み失敗
                                                                StrMain_ErrorMessage = "SS-MIXファイルの読み込みに失敗しました。" + ex.Message;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //取り込み失敗
                StrMain_ErrorMessage = "SS-MIXファイルの検索に失敗しました。" + ex.Message;
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// ハッシュ化患者ID取得
        /// </summary>
        /// <param name="pmstrPatientId">患者ID</param>
        /// <param name="pmstrSalt">ソルト</param>
        /// <param name="pmintStretchingCount">ストレッチング回数</param>
        /// <returns></returns>
        private string GetHashPatientId(string pmstrPatientId, string pmstrSalt, int pmintStretchingCount)
        {

            //患者IDにソルト付加
            string strHashValue = pmstrPatientId + pmstrSalt;
            //ストレッチング回数分ハッシュ化
            for (int intCounter = 0; intCounter < pmintStretchingCount; intCounter++)
            {
                strHashValue = GetHashValue(strHashValue);
            }

            return strHashValue;
        }

        /// <summary>
        /// ハッシュ値取得
        /// </summary>
        /// <param name="pmstrValue">値</param>
        /// <returns></returns>
        private string GetHashValue(string pmstrValue)
        {
            SHA1 sha1Hash = SHA1Managed.Create();
            byte[] bytValue = Encoding.UTF8.GetBytes(pmstrValue);
            byte[] bytHash = sha1Hash.ComputeHash(bytValue);
            StringBuilder stbHash = new StringBuilder();
            for (int intCounter = 0; intCounter < bytHash.Length; intCounter++)
            {
                stbHash.AppendFormat("{0:x2}", bytHash[intCounter]);
            }

            return stbHash.ToString();
        }

        /// <summary>
        /// ダミーデータ変換
        /// </summary>
        /// <param name="ssmix">SS-MIXデータ</param>
        /// <param name="strHashPatientId">患者ID</param>
        /// <returns></returns>
        private string ConvertDummyData(string pmstrSSMIX, string pmstrHashPatientId, int pmintSlideDays)
        {

            string strSSMIX = "";
            //改行（\n）で分割
            string[] strLines = pmstrSSMIX.Split('\r');
            foreach (string strLine in strLines)
            {
                bool blnErrorFlg = false;
                bool blnRemoveFlg = false;
                string strLineData = strLine;
                //|」で分割
                string[] strItems = strLineData.Split('|');
                switch (strItems[0])
                {
                    case "ZGW":
                        //ZGWセグメントは削除
                        blnRemoveFlg = true;
                        break;
                    case "PID":
                        strLineData = "";
                        for (int intCounter = 0; intCounter < strItems.Length; intCounter++)
                        {
                            switch (intCounter)
                            {
                                case 0:
                                    //そのまま
                                    break;
                                case 2:
                                    //患者ID
                                    //ハッシュ化患者IDに置き換える
                                    strItems[intCounter] = pmstrHashPatientId;
                                    break;
                                case 7:
                                    //生年月日
                                    //スライド日数分移動
                                    string strBirthday = strItems[intCounter].Substring(0, 4) + "-" + strItems[intCounter].Substring(4, 2) + "-" + strItems[intCounter].Substring(6, 2);
                                    DateTime datBirthday;
                                    if (DateTime.TryParse(strBirthday, out datBirthday) == true)
                                    {
                                        strItems[intCounter] = datBirthday.AddDays(pmintSlideDays).ToString("yyyyMMdd");
                                    }
                                    else
                                    {
                                        //生年月日不正
                                        blnErrorFlg = true;
                                    }
                                    break;
                                case 8:
                                    //性別
                                    //そのまま
                                    break;
                                default:
                                    //以外はクリア
                                    strItems[intCounter] = "";
                                    break;
                            }
                            if (strLineData.Length > 0)
                            {
                                strLineData = strLineData + '|';
                            }
                            strLineData = strLineData + strItems[intCounter];
                        }
                        break;
                    case "OBX":
                        strLineData = "";
                        for (int intCounter = 0; intCounter < strItems.Length; intCounter++)
                        {
                            switch (intCounter)
                            {
                                case 14:
                                    //検査日時
                                    //スライド日数分移動
                                    string strLaboDate;
                                    if (strItems[intCounter].Length >= 14)
                                    {
                                        //時間あり
                                        strLaboDate = strItems[intCounter].Substring(0, 4) + "-" + strItems[intCounter].Substring(4, 2) + "-" + strItems[intCounter].Substring(6, 2) + " " + strItems[intCounter].Substring(8, 2) + ":" + strItems[intCounter].Substring(10, 2) + ":" + strItems[intCounter].Substring(12, 2);
                                    }
                                    else
                                    {
                                        //時間なし
                                        strLaboDate = strItems[intCounter].Substring(0, 4) + "-" + strItems[intCounter].Substring(4, 2) + "-" + strItems[intCounter].Substring(6, 2);
                                    }
                                    DateTime datLaboDate;
                                    if (DateTime.TryParse(strLaboDate, out datLaboDate) == true)
                                    {
                                        if (strItems[intCounter].Length >= 14)
                                        {
                                            //時間あり
                                            strItems[intCounter] = datLaboDate.AddDays(pmintSlideDays).ToString("yyyyMMddhhmmss");
                                        }
                                        else
                                        {
                                            //時間なし
                                            strItems[intCounter] = datLaboDate.AddDays(pmintSlideDays).ToString("yyyyMMdd");
                                        }
                                    }
                                    else
                                    {
                                        //検査日時
                                        blnErrorFlg = true;
                                    }
                                    break;
                                default:
                                    //以外はそのまま
                                    break;
                            }
                            if (strLineData.Length > 0)
                            {
                                strLineData = strLineData + '|';
                            }
                            strLineData = strLineData + strItems[intCounter];
                        }
                        break;
                    case "TQ1":
                        strLineData = "";
                        for (int intCounter = 0; intCounter < strItems.Length; intCounter++)
                        {
                            switch (intCounter)
                            {
                                case 7:
                                    //開始日
                                    //スライド日数分移動
                                    string strStartDate;
                                    if (strItems[intCounter].Length >= 14)
                                    {
                                        //時間あり
                                        strStartDate = strItems[intCounter].Substring(0, 4) + "-" + strItems[intCounter].Substring(4, 2) + "-" + strItems[intCounter].Substring(6, 2) + " " + strItems[intCounter].Substring(8, 2) + ":" + strItems[intCounter].Substring(10, 2) + ":" + strItems[intCounter].Substring(12, 2);
                                    }
                                    else
                                    {
                                        //時間なし
                                        strStartDate = strItems[intCounter].Substring(0, 4) + "-" + strItems[intCounter].Substring(4, 2) + "-" + strItems[intCounter].Substring(6, 2);
                                    }
                                    DateTime datStartDate;
                                    if (DateTime.TryParse(strStartDate, out datStartDate) == true)
                                    {
                                        if (strItems[intCounter].Length >= 14)
                                        {
                                            //時間あり
                                            strItems[intCounter] = datStartDate.AddDays(pmintSlideDays).ToString("yyyyMMddhhmmss");
                                        }
                                        else
                                        {
                                            //時間なし
                                            strItems[intCounter] = datStartDate.AddDays(pmintSlideDays).ToString("yyyyMMdd");
                                        }
                                    }
                                    else
                                    {
                                        //開始日
                                        blnErrorFlg = true;
                                    }
                                    break;
                                default:
                                    //以外はそのまま
                                    break;
                            }
                            if (strLineData.Length > 0)
                            {
                                strLineData = strLineData + '|';
                            }
                            strLineData = strLineData + strItems[intCounter];
                        }
                        break;
                    default:
                        break;

                }
                if (blnErrorFlg == true)
                {
                    //エラー
                    strSSMIX = "";
                    break;
                }
                if (blnRemoveFlg != true)
                {
                    //削除以外
                    strSSMIX = strSSMIX + strLineData + '\r';
                }
            }

            return strSSMIX;
        }

    }
}
