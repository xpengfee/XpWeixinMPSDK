namespace TestXpApi
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetGroups = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetFriends = new System.Windows.Forms.Button();
            this.btnGetFriendsDetail = new System.Windows.Forms.Button();
            this.btnGetFriendHeadImage = new System.Windows.Forms.Button();
            this.pbHeadImage = new System.Windows.Forms.PictureBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSendImageText = new System.Windows.Forms.Button();
            this.btnOrginNews = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetFriendsDetailByOpenid = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFindFakeId = new System.Windows.Forms.Button();
            this.btnFindFakeids = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetGroups
            // 
            this.btnGetGroups.Location = new System.Drawing.Point(12, 63);
            this.btnGetGroups.Name = "btnGetGroups";
            this.btnGetGroups.Size = new System.Drawing.Size(75, 23);
            this.btnGetGroups.TabIndex = 0;
            this.btnGetGroups.Text = "GetGroups";
            this.btnGetGroups.UseVisualStyleBackColor = true;
            this.btnGetGroups.Click += new System.EventHandler(this.btnGetGroups_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(67, 13);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Text = "qqdao@163.com";
            this.tbUserName.TextChanged += new System.EventHandler(this.tbUserName_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(232, 13);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "solution";
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密 码：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnGetFriends
            // 
            this.btnGetFriends.Location = new System.Drawing.Point(104, 63);
            this.btnGetFriends.Name = "btnGetFriends";
            this.btnGetFriends.Size = new System.Drawing.Size(75, 23);
            this.btnGetFriends.TabIndex = 5;
            this.btnGetFriends.Text = "GetFriends";
            this.btnGetFriends.UseVisualStyleBackColor = true;
            this.btnGetFriends.Click += new System.EventHandler(this.btnGetFriends_Click);
            // 
            // btnGetFriendsDetail
            // 
            this.btnGetFriendsDetail.Location = new System.Drawing.Point(200, 63);
            this.btnGetFriendsDetail.Name = "btnGetFriendsDetail";
            this.btnGetFriendsDetail.Size = new System.Drawing.Size(110, 23);
            this.btnGetFriendsDetail.TabIndex = 6;
            this.btnGetFriendsDetail.Text = "GetFriendsDetail";
            this.btnGetFriendsDetail.UseVisualStyleBackColor = true;
            this.btnGetFriendsDetail.Click += new System.EventHandler(this.btnGetFriendsDetail_Click);
            // 
            // btnGetFriendHeadImage
            // 
            this.btnGetFriendHeadImage.Location = new System.Drawing.Point(405, 63);
            this.btnGetFriendHeadImage.Name = "btnGetFriendHeadImage";
            this.btnGetFriendHeadImage.Size = new System.Drawing.Size(131, 23);
            this.btnGetFriendHeadImage.TabIndex = 7;
            this.btnGetFriendHeadImage.Text = "GetFriendHeadImage";
            this.btnGetFriendHeadImage.UseVisualStyleBackColor = true;
            this.btnGetFriendHeadImage.Click += new System.EventHandler(this.btnGetFriendHeadImage_Click);
            // 
            // pbHeadImage
            // 
            this.pbHeadImage.Location = new System.Drawing.Point(405, 92);
            this.pbHeadImage.Name = "pbHeadImage";
            this.pbHeadImage.Size = new System.Drawing.Size(100, 50);
            this.pbHeadImage.TabIndex = 8;
            this.pbHeadImage.TabStop = false;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(13, 148);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 9;
            this.btnSendMessage.Text = "SendMessage";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSendImageText
            // 
            this.btnSendImageText.Location = new System.Drawing.Point(104, 148);
            this.btnSendImageText.Name = "btnSendImageText";
            this.btnSendImageText.Size = new System.Drawing.Size(91, 23);
            this.btnSendImageText.TabIndex = 10;
            this.btnSendImageText.Text = "SendImageText";
            this.btnSendImageText.UseVisualStyleBackColor = true;
            this.btnSendImageText.Click += new System.EventHandler(this.btnSendImageText_Click);
            // 
            // btnOrginNews
            // 
            this.btnOrginNews.Location = new System.Drawing.Point(163, 203);
            this.btnOrginNews.Name = "btnOrginNews";
            this.btnOrginNews.Size = new System.Drawing.Size(75, 23);
            this.btnOrginNews.TabIndex = 11;
            this.btnOrginNews.Text = "OrginNews";
            this.btnOrginNews.UseVisualStyleBackColor = true;
            this.btnOrginNews.Click += new System.EventHandler(this.btnOrginNews_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "GetAppMsg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetFriendsDetailByOpenid
            // 
            this.btnGetFriendsDetailByOpenid.Location = new System.Drawing.Point(200, 92);
            this.btnGetFriendsDetailByOpenid.Name = "btnGetFriendsDetailByOpenid";
            this.btnGetFriendsDetailByOpenid.Size = new System.Drawing.Size(140, 23);
            this.btnGetFriendsDetailByOpenid.TabIndex = 13;
            this.btnGetFriendsDetailByOpenid.Text = "GetFriendsDetail_openid";
            this.btnGetFriendsDetailByOpenid.UseVisualStyleBackColor = true;
            this.btnGetFriendsDetailByOpenid.Click += new System.EventHandler(this.btnGetFriendsDetailByOpenid_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(13, 203);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFile.TabIndex = 14;
            this.btnUploadFile.Text = "UploadFile";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFindFakeId
            // 
            this.btnFindFakeId.Location = new System.Drawing.Point(13, 92);
            this.btnFindFakeId.Name = "btnFindFakeId";
            this.btnFindFakeId.Size = new System.Drawing.Size(75, 23);
            this.btnFindFakeId.TabIndex = 15;
            this.btnFindFakeId.Text = "FindFakeId";
            this.btnFindFakeId.UseVisualStyleBackColor = true;
            this.btnFindFakeId.Click += new System.EventHandler(this.btnFindFakeId_Click);
            // 
            // btnFindFakeids
            // 
            this.btnFindFakeids.Location = new System.Drawing.Point(104, 92);
            this.btnFindFakeids.Name = "btnFindFakeids";
            this.btnFindFakeids.Size = new System.Drawing.Size(90, 23);
            this.btnFindFakeids.TabIndex = 16;
            this.btnFindFakeids.Text = "FindFakeids";
            this.btnFindFakeids.UseVisualStyleBackColor = true;
            this.btnFindFakeids.Click += new System.EventHandler(this.btnFindFakeids_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 337);
            this.Controls.Add(this.btnFindFakeids);
            this.Controls.Add(this.btnFindFakeId);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.btnGetFriendsDetailByOpenid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOrginNews);
            this.Controls.Add(this.btnSendImageText);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.pbHeadImage);
            this.Controls.Add(this.btnGetFriendHeadImage);
            this.Controls.Add(this.btnGetFriendsDetail);
            this.Controls.Add(this.btnGetFriends);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.btnGetGroups);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetGroups;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetFriends;
        private System.Windows.Forms.Button btnGetFriendsDetail;
        private System.Windows.Forms.Button btnGetFriendHeadImage;
        private System.Windows.Forms.PictureBox pbHeadImage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSendImageText;
        private System.Windows.Forms.Button btnOrginNews;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetFriendsDetailByOpenid;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFindFakeId;
        private System.Windows.Forms.Button btnFindFakeids;
    }
}

