namespace SSCopy
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdStorage = new System.Windows.Forms.Button();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.lblStorage = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblBefore = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdCopyFolder = new System.Windows.Forms.Button();
            this.txtCopyFolder = new System.Windows.Forms.TextBox();
            this.lblCopyFolder = new System.Windows.Forms.Label();
            this.lblHashSalt = new System.Windows.Forms.Label();
            this.txtHashSalt = new System.Windows.Forms.TextBox();
            this.txtHashStretching = new System.Windows.Forms.TextBox();
            this.lblHashStretching = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.grpDataKind = new System.Windows.Forms.GroupBox();
            this.chkDataKind12 = new System.Windows.Forms.CheckBox();
            this.chkDataKind11 = new System.Windows.Forms.CheckBox();
            this.chkDataKind10 = new System.Windows.Forms.CheckBox();
            this.chkDataKind9 = new System.Windows.Forms.CheckBox();
            this.chkDataKind8 = new System.Windows.Forms.CheckBox();
            this.chkDataKind7 = new System.Windows.Forms.CheckBox();
            this.chkDataKind6 = new System.Windows.Forms.CheckBox();
            this.chkDataKind5 = new System.Windows.Forms.CheckBox();
            this.chkDataKind3 = new System.Windows.Forms.CheckBox();
            this.chkDataKind2 = new System.Windows.Forms.CheckBox();
            this.chkDataKind4 = new System.Windows.Forms.CheckBox();
            this.chkDataKind1 = new System.Windows.Forms.CheckBox();
            this.txtPatientIdList = new System.Windows.Forms.TextBox();
            this.lblPatientIdList = new System.Windows.Forms.Label();
            this.grpDataKind.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdStorage
            // 
            this.cmdStorage.Location = new System.Drawing.Point(384, 12);
            this.cmdStorage.Name = "cmdStorage";
            this.cmdStorage.Size = new System.Drawing.Size(23, 19);
            this.cmdStorage.TabIndex = 2;
            this.cmdStorage.Text = "...";
            this.cmdStorage.UseVisualStyleBackColor = true;
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(111, 12);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(267, 19);
            this.txtStorage.TabIndex = 1;
            this.txtStorage.Text = "C:\\Users\\SS2S\\Desktop\\ss-mix-st\\storage";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(12, 15);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(62, 12);
            this.lblStorage.TabIndex = 0;
            this.lblStorage.Text = "取り込み先:";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(12, 40);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(74, 12);
            this.lblDays.TabIndex = 3;
            this.lblDays.Text = "取り込み日数:";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(111, 37);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(48, 19);
            this.txtDays.TabIndex = 4;
            this.txtDays.Text = "180";
            // 
            // lblBefore
            // 
            this.lblBefore.AutoSize = true;
            this.lblBefore.Location = new System.Drawing.Point(165, 40);
            this.lblBefore.Name = "lblBefore";
            this.lblBefore.Size = new System.Drawing.Size(29, 12);
            this.lblBefore.TabIndex = 5;
            this.lblBefore.Text = "日前";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 268);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(44, 12);
            this.lblProgress.TabIndex = 17;
            this.lblProgress.Text = "コピー数";
            // 
            // cmdCopy
            // 
            this.cmdCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCopy.Location = new System.Drawing.Point(486, 303);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(75, 23);
            this.cmdCopy.TabIndex = 18;
            this.cmdCopy.Text = "コピー";
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(567, 303);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 19;
            this.cmdExit.Text = "閉じる";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdCopyFolder
            // 
            this.cmdCopyFolder.Location = new System.Drawing.Point(384, 177);
            this.cmdCopyFolder.Name = "cmdCopyFolder";
            this.cmdCopyFolder.Size = new System.Drawing.Size(23, 19);
            this.cmdCopyFolder.TabIndex = 9;
            this.cmdCopyFolder.Text = "...";
            this.cmdCopyFolder.UseVisualStyleBackColor = true;
            // 
            // txtCopyFolder
            // 
            this.txtCopyFolder.Location = new System.Drawing.Point(111, 177);
            this.txtCopyFolder.Name = "txtCopyFolder";
            this.txtCopyFolder.Size = new System.Drawing.Size(267, 19);
            this.txtCopyFolder.TabIndex = 8;
            this.txtCopyFolder.Text = "D:\\Test5\\storage";
            // 
            // lblCopyFolder
            // 
            this.lblCopyFolder.AutoSize = true;
            this.lblCopyFolder.Location = new System.Drawing.Point(12, 180);
            this.lblCopyFolder.Name = "lblCopyFolder";
            this.lblCopyFolder.Size = new System.Drawing.Size(46, 12);
            this.lblCopyFolder.TabIndex = 7;
            this.lblCopyFolder.Text = "コピー先:";
            // 
            // lblHashSalt
            // 
            this.lblHashSalt.AutoSize = true;
            this.lblHashSalt.Location = new System.Drawing.Point(12, 205);
            this.lblHashSalt.Name = "lblHashSalt";
            this.lblHashSalt.Size = new System.Drawing.Size(34, 12);
            this.lblHashSalt.TabIndex = 10;
            this.lblHashSalt.Text = "ソルト:";
            // 
            // txtHashSalt
            // 
            this.txtHashSalt.Location = new System.Drawing.Point(111, 202);
            this.txtHashSalt.Name = "txtHashSalt";
            this.txtHashSalt.Size = new System.Drawing.Size(267, 19);
            this.txtHashSalt.TabIndex = 11;
            // 
            // txtHashStretching
            // 
            this.txtHashStretching.Location = new System.Drawing.Point(111, 227);
            this.txtHashStretching.Name = "txtHashStretching";
            this.txtHashStretching.Size = new System.Drawing.Size(48, 19);
            this.txtHashStretching.TabIndex = 13;
            // 
            // lblHashStretching
            // 
            this.lblHashStretching.AutoSize = true;
            this.lblHashStretching.Location = new System.Drawing.Point(12, 230);
            this.lblHashStretching.Name = "lblHashStretching";
            this.lblHashStretching.Size = new System.Drawing.Size(91, 12);
            this.lblHashStretching.TabIndex = 12;
            this.lblHashStretching.Text = "ストレッチング回数:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(165, 230);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(17, 12);
            this.lblCount.TabIndex = 14;
            this.lblCount.Text = "回";
            // 
            // grpDataKind
            // 
            this.grpDataKind.Controls.Add(this.chkDataKind12);
            this.grpDataKind.Controls.Add(this.chkDataKind11);
            this.grpDataKind.Controls.Add(this.chkDataKind10);
            this.grpDataKind.Controls.Add(this.chkDataKind9);
            this.grpDataKind.Controls.Add(this.chkDataKind8);
            this.grpDataKind.Controls.Add(this.chkDataKind7);
            this.grpDataKind.Controls.Add(this.chkDataKind6);
            this.grpDataKind.Controls.Add(this.chkDataKind5);
            this.grpDataKind.Controls.Add(this.chkDataKind3);
            this.grpDataKind.Controls.Add(this.chkDataKind2);
            this.grpDataKind.Controls.Add(this.chkDataKind4);
            this.grpDataKind.Controls.Add(this.chkDataKind1);
            this.grpDataKind.Location = new System.Drawing.Point(14, 62);
            this.grpDataKind.Name = "grpDataKind";
            this.grpDataKind.Size = new System.Drawing.Size(392, 109);
            this.grpDataKind.TabIndex = 6;
            this.grpDataKind.TabStop = false;
            this.grpDataKind.Tag = "";
            this.grpDataKind.Text = "取り込みデータ種別";
            // 
            // chkDataKind12
            // 
            this.chkDataKind12.AutoSize = true;
            this.chkDataKind12.Checked = true;
            this.chkDataKind12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind12.Location = new System.Drawing.Point(87, 84);
            this.chkDataKind12.Name = "chkDataKind12";
            this.chkDataKind12.Size = new System.Drawing.Size(84, 16);
            this.chkDataKind12.TabIndex = 11;
            this.chkDataKind12.Tag = "OMG-01";
            this.chkDataKind12.Text = "放射線検査";
            this.chkDataKind12.UseVisualStyleBackColor = true;
            // 
            // chkDataKind11
            // 
            this.chkDataKind11.AutoSize = true;
            this.chkDataKind11.Checked = true;
            this.chkDataKind11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind11.Location = new System.Drawing.Point(9, 84);
            this.chkDataKind11.Name = "chkDataKind11";
            this.chkDataKind11.Size = new System.Drawing.Size(72, 16);
            this.chkDataKind11.TabIndex = 10;
            this.chkDataKind11.Tag = "OML-11";
            this.chkDataKind11.Text = "検体検査";
            this.chkDataKind11.UseVisualStyleBackColor = true;
            // 
            // chkDataKind10
            // 
            this.chkDataKind10.AutoSize = true;
            this.chkDataKind10.Checked = true;
            this.chkDataKind10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind10.Location = new System.Drawing.Point(63, 62);
            this.chkDataKind10.Name = "chkDataKind10";
            this.chkDataKind10.Size = new System.Drawing.Size(48, 16);
            this.chkDataKind10.TabIndex = 9;
            this.chkDataKind10.Tag = "OMP-02";
            this.chkDataKind10.Text = "注射";
            this.chkDataKind10.UseVisualStyleBackColor = true;
            // 
            // chkDataKind9
            // 
            this.chkDataKind9.AutoSize = true;
            this.chkDataKind9.Checked = true;
            this.chkDataKind9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind9.Location = new System.Drawing.Point(9, 62);
            this.chkDataKind9.Name = "chkDataKind9";
            this.chkDataKind9.Size = new System.Drawing.Size(48, 16);
            this.chkDataKind9.TabIndex = 8;
            this.chkDataKind9.Tag = "OMP-01";
            this.chkDataKind9.Text = "処方";
            this.chkDataKind9.UseVisualStyleBackColor = true;
            // 
            // chkDataKind8
            // 
            this.chkDataKind8.AutoSize = true;
            this.chkDataKind8.Checked = true;
            this.chkDataKind8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind8.Location = new System.Drawing.Point(333, 40);
            this.chkDataKind8.Name = "chkDataKind8";
            this.chkDataKind8.Size = new System.Drawing.Size(48, 16);
            this.chkDataKind8.TabIndex = 7;
            this.chkDataKind8.Tag = "ADT-52";
            this.chkDataKind8.Text = "退院";
            this.chkDataKind8.UseVisualStyleBackColor = true;
            // 
            // chkDataKind7
            // 
            this.chkDataKind7.AutoSize = true;
            this.chkDataKind7.Checked = true;
            this.chkDataKind7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind7.Location = new System.Drawing.Point(249, 40);
            this.chkDataKind7.Name = "chkDataKind7";
            this.chkDataKind7.Size = new System.Drawing.Size(78, 16);
            this.chkDataKind7.TabIndex = 6;
            this.chkDataKind7.Tag = "ADT-42";
            this.chkDataKind7.Text = "転科・転棟";
            this.chkDataKind7.UseVisualStyleBackColor = true;
            // 
            // chkDataKind6
            // 
            this.chkDataKind6.AutoSize = true;
            this.chkDataKind6.Checked = true;
            this.chkDataKind6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind6.Location = new System.Drawing.Point(195, 40);
            this.chkDataKind6.Name = "chkDataKind6";
            this.chkDataKind6.Size = new System.Drawing.Size(48, 16);
            this.chkDataKind6.TabIndex = 5;
            this.chkDataKind6.Tag = "ADT-32";
            this.chkDataKind6.Text = "帰院";
            this.chkDataKind6.UseVisualStyleBackColor = true;
            // 
            // chkDataKind5
            // 
            this.chkDataKind5.AutoSize = true;
            this.chkDataKind5.Checked = true;
            this.chkDataKind5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind5.Location = new System.Drawing.Point(129, 40);
            this.chkDataKind5.Name = "chkDataKind5";
            this.chkDataKind5.Size = new System.Drawing.Size(60, 16);
            this.chkDataKind5.TabIndex = 4;
            this.chkDataKind5.Tag = "ADT-31";
            this.chkDataKind5.Text = "外出泊";
            this.chkDataKind5.UseVisualStyleBackColor = true;
            // 
            // chkDataKind3
            // 
            this.chkDataKind3.AutoSize = true;
            this.chkDataKind3.Checked = true;
            this.chkDataKind3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind3.Location = new System.Drawing.Point(9, 40);
            this.chkDataKind3.Name = "chkDataKind3";
            this.chkDataKind3.Size = new System.Drawing.Size(48, 16);
            this.chkDataKind3.TabIndex = 2;
            this.chkDataKind3.Tag = "ADT-22";
            this.chkDataKind3.Text = "入院";
            this.chkDataKind3.UseVisualStyleBackColor = true;
            // 
            // chkDataKind2
            // 
            this.chkDataKind2.AutoSize = true;
            this.chkDataKind2.Checked = true;
            this.chkDataKind2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind2.Location = new System.Drawing.Point(111, 18);
            this.chkDataKind2.Name = "chkDataKind2";
            this.chkDataKind2.Size = new System.Drawing.Size(96, 16);
            this.chkDataKind2.TabIndex = 1;
            this.chkDataKind2.Tag = "ADT-12";
            this.chkDataKind2.Text = "外来診察受付";
            this.chkDataKind2.UseVisualStyleBackColor = true;
            // 
            // chkDataKind4
            // 
            this.chkDataKind4.AutoSize = true;
            this.chkDataKind4.Checked = true;
            this.chkDataKind4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind4.Location = new System.Drawing.Point(63, 40);
            this.chkDataKind4.Name = "chkDataKind4";
            this.chkDataKind4.Size = new System.Drawing.Size(60, 16);
            this.chkDataKind4.TabIndex = 3;
            this.chkDataKind4.Tag = "ADT-01";
            this.chkDataKind4.Text = "担当医";
            this.chkDataKind4.UseVisualStyleBackColor = true;
            // 
            // chkDataKind1
            // 
            this.chkDataKind1.AutoSize = true;
            this.chkDataKind1.Checked = true;
            this.chkDataKind1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataKind1.Location = new System.Drawing.Point(9, 18);
            this.chkDataKind1.Name = "chkDataKind1";
            this.chkDataKind1.Size = new System.Drawing.Size(96, 16);
            this.chkDataKind1.TabIndex = 0;
            this.chkDataKind1.Tag = "ADT-00";
            this.chkDataKind1.Text = "患者基本情報";
            this.chkDataKind1.UseVisualStyleBackColor = true;
            // 
            // txtPatientIdList
            // 
            this.txtPatientIdList.Location = new System.Drawing.Point(437, 30);
            this.txtPatientIdList.Multiline = true;
            this.txtPatientIdList.Name = "txtPatientIdList";
            this.txtPatientIdList.Size = new System.Drawing.Size(205, 216);
            this.txtPatientIdList.TabIndex = 16;
            // 
            // lblPatientIdList
            // 
            this.lblPatientIdList.AutoSize = true;
            this.lblPatientIdList.Location = new System.Drawing.Point(435, 15);
            this.lblPatientIdList.Name = "lblPatientIdList";
            this.lblPatientIdList.Size = new System.Drawing.Size(42, 12);
            this.lblPatientIdList.TabIndex = 15;
            this.lblPatientIdList.Text = "患者ID:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 336);
            this.Controls.Add(this.lblPatientIdList);
            this.Controls.Add(this.txtPatientIdList);
            this.Controls.Add(this.grpDataKind);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblHashStretching);
            this.Controls.Add(this.txtHashStretching);
            this.Controls.Add(this.txtHashSalt);
            this.Controls.Add(this.lblHashSalt);
            this.Controls.Add(this.cmdCopyFolder);
            this.Controls.Add(this.txtCopyFolder);
            this.Controls.Add(this.lblCopyFolder);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblBefore);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.cmdStorage);
            this.Controls.Add(this.txtStorage);
            this.Controls.Add(this.lblStorage);
            this.Name = "frmMain";
            this.Text = "SS-MIX データコピー";
            this.grpDataKind.ResumeLayout(false);
            this.grpDataKind.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStorage;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label lblBefore;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdCopyFolder;
        private System.Windows.Forms.TextBox txtCopyFolder;
        private System.Windows.Forms.Label lblCopyFolder;
        private System.Windows.Forms.Label lblHashSalt;
        private System.Windows.Forms.TextBox txtHashSalt;
        private System.Windows.Forms.TextBox txtHashStretching;
        private System.Windows.Forms.Label lblHashStretching;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox grpDataKind;
        private System.Windows.Forms.CheckBox chkDataKind12;
        private System.Windows.Forms.CheckBox chkDataKind11;
        private System.Windows.Forms.CheckBox chkDataKind10;
        private System.Windows.Forms.CheckBox chkDataKind9;
        private System.Windows.Forms.CheckBox chkDataKind8;
        private System.Windows.Forms.CheckBox chkDataKind7;
        private System.Windows.Forms.CheckBox chkDataKind6;
        private System.Windows.Forms.CheckBox chkDataKind5;
        private System.Windows.Forms.CheckBox chkDataKind3;
        private System.Windows.Forms.CheckBox chkDataKind2;
        private System.Windows.Forms.CheckBox chkDataKind4;
        private System.Windows.Forms.CheckBox chkDataKind1;
        private System.Windows.Forms.TextBox txtPatientIdList;
        private System.Windows.Forms.Label lblPatientIdList;
    }
}

