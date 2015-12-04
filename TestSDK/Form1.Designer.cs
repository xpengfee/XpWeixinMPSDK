namespace TestSDK
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSDK = new System.Windows.Forms.ComboBox();
            this.btnGetGroups = new System.Windows.Forms.Button();
            this.btnGetAppMsg = new System.Windows.Forms.Button();
            this.btnOrginNews = new System.Windows.Forms.Button();
            this.btnSendImageText = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.pbHeadImage = new System.Windows.Forms.PictureBox();
            this.btnGetFriendHeadImage = new System.Windows.Forms.Button();
            this.btnGetFriendsDetail = new System.Windows.Forms.Button();
            this.btnGetFriends = new System.Windows.Forms.Button();
            this.btnFindFakeId = new System.Windows.Forms.Button();
            this.btnFindFakeids = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密 码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名：";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(234, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = "solution";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(69, 5);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 5;
            this.tbUserName.Text = "qqdao@163.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "SDK";
            // 
            // cbSDK
            // 
            this.cbSDK.FormattingEnabled = true;
            this.cbSDK.Location = new System.Drawing.Point(387, 6);
            this.cbSDK.Name = "cbSDK";
            this.cbSDK.Size = new System.Drawing.Size(121, 20);
            this.cbSDK.TabIndex = 10;
            this.cbSDK.SelectedIndexChanged += new System.EventHandler(this.cbSDK_SelectedIndexChanged);
            // 
            // btnGetGroups
            // 
            this.btnGetGroups.Location = new System.Drawing.Point(14, 53);
            this.btnGetGroups.Name = "btnGetGroups";
            this.btnGetGroups.Size = new System.Drawing.Size(75, 23);
            this.btnGetGroups.TabIndex = 11;
            this.btnGetGroups.Text = "GetGroups";
            this.btnGetGroups.UseVisualStyleBackColor = true;
            this.btnGetGroups.Click += new System.EventHandler(this.btnGetGroups_Click);
            // 
            // btnGetAppMsg
            // 
            this.btnGetAppMsg.Location = new System.Drawing.Point(135, 193);
            this.btnGetAppMsg.Name = "btnGetAppMsg";
            this.btnGetAppMsg.Size = new System.Drawing.Size(75, 23);
            this.btnGetAppMsg.TabIndex = 20;
            this.btnGetAppMsg.Text = "GetAppMsg";
            this.btnGetAppMsg.UseVisualStyleBackColor = true;
            this.btnGetAppMsg.Click += new System.EventHandler(this.btnGetAppMsg_Click);
            // 
            // btnOrginNews
            // 
            this.btnOrginNews.Location = new System.Drawing.Point(28, 193);
            this.btnOrginNews.Name = "btnOrginNews";
            this.btnOrginNews.Size = new System.Drawing.Size(75, 23);
            this.btnOrginNews.TabIndex = 19;
            this.btnOrginNews.Text = "OrginNews";
            this.btnOrginNews.UseVisualStyleBackColor = true;
            this.btnOrginNews.Click += new System.EventHandler(this.btnOrginNews_Click);
            // 
            // btnSendImageText
            // 
            this.btnSendImageText.Location = new System.Drawing.Point(119, 138);
            this.btnSendImageText.Name = "btnSendImageText";
            this.btnSendImageText.Size = new System.Drawing.Size(91, 23);
            this.btnSendImageText.TabIndex = 18;
            this.btnSendImageText.Text = "SendImageText";
            this.btnSendImageText.UseVisualStyleBackColor = true;
            this.btnSendImageText.Click += new System.EventHandler(this.btnSendImageText_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(28, 138);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 17;
            this.btnSendMessage.Text = "SendMessage";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // pbHeadImage
            // 
            this.pbHeadImage.Location = new System.Drawing.Point(343, 83);
            this.pbHeadImage.Name = "pbHeadImage";
            this.pbHeadImage.Size = new System.Drawing.Size(100, 50);
            this.pbHeadImage.TabIndex = 16;
            this.pbHeadImage.TabStop = false;
            // 
            // btnGetFriendHeadImage
            // 
            this.btnGetFriendHeadImage.Location = new System.Drawing.Point(343, 53);
            this.btnGetFriendHeadImage.Name = "btnGetFriendHeadImage";
            this.btnGetFriendHeadImage.Size = new System.Drawing.Size(131, 23);
            this.btnGetFriendHeadImage.TabIndex = 15;
            this.btnGetFriendHeadImage.Text = "GetFriendHeadImage";
            this.btnGetFriendHeadImage.UseVisualStyleBackColor = true;
            this.btnGetFriendHeadImage.Click += new System.EventHandler(this.btnGetFriendHeadImage_Click);
            // 
            // btnGetFriendsDetail
            // 
            this.btnGetFriendsDetail.Location = new System.Drawing.Point(215, 53);
            this.btnGetFriendsDetail.Name = "btnGetFriendsDetail";
            this.btnGetFriendsDetail.Size = new System.Drawing.Size(110, 23);
            this.btnGetFriendsDetail.TabIndex = 14;
            this.btnGetFriendsDetail.Text = "GetFriendsDetail";
            this.btnGetFriendsDetail.UseVisualStyleBackColor = true;
            this.btnGetFriendsDetail.Click += new System.EventHandler(this.btnGetFriendsDetail_Click);
            // 
            // btnGetFriends
            // 
            this.btnGetFriends.Location = new System.Drawing.Point(119, 53);
            this.btnGetFriends.Name = "btnGetFriends";
            this.btnGetFriends.Size = new System.Drawing.Size(75, 23);
            this.btnGetFriends.TabIndex = 13;
            this.btnGetFriends.Text = "GetFriends";
            this.btnGetFriends.UseVisualStyleBackColor = true;
            this.btnGetFriends.Click += new System.EventHandler(this.btnGetFriends_Click);
            // 
            // btnFindFakeId
            // 
            this.btnFindFakeId.Location = new System.Drawing.Point(12, 83);
            this.btnFindFakeId.Name = "btnFindFakeId";
            this.btnFindFakeId.Size = new System.Drawing.Size(75, 23);
            this.btnFindFakeId.TabIndex = 21;
            this.btnFindFakeId.Text = "FindFakeId";
            this.btnFindFakeId.UseVisualStyleBackColor = true;
            this.btnFindFakeId.Click += new System.EventHandler(this.btnFindFakeId_Click);
            // 
            // btnFindFakeids
            // 
            this.btnFindFakeids.Location = new System.Drawing.Point(104, 83);
            this.btnFindFakeids.Name = "btnFindFakeids";
            this.btnFindFakeids.Size = new System.Drawing.Size(90, 23);
            this.btnFindFakeids.TabIndex = 22;
            this.btnFindFakeids.Text = "FindFakeids";
            this.btnFindFakeids.UseVisualStyleBackColor = true;
            this.btnFindFakeids.Click += new System.EventHandler(this.btnFindFakeids_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 410);
            this.Controls.Add(this.btnFindFakeids);
            this.Controls.Add(this.btnFindFakeId);
            this.Controls.Add(this.btnGetAppMsg);
            this.Controls.Add(this.btnOrginNews);
            this.Controls.Add(this.btnSendImageText);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.pbHeadImage);
            this.Controls.Add(this.btnGetFriendHeadImage);
            this.Controls.Add(this.btnGetFriendsDetail);
            this.Controls.Add(this.btnGetFriends);
            this.Controls.Add(this.btnGetGroups);
            this.Controls.Add(this.cbSDK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSDK;
        private System.Windows.Forms.Button btnGetGroups;
        private System.Windows.Forms.Button btnGetAppMsg;
        private System.Windows.Forms.Button btnOrginNews;
        private System.Windows.Forms.Button btnSendImageText;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.PictureBox pbHeadImage;
        private System.Windows.Forms.Button btnGetFriendHeadImage;
        private System.Windows.Forms.Button btnGetFriendsDetail;
        private System.Windows.Forms.Button btnGetFriends;
        private System.Windows.Forms.Button btnFindFakeId;
        private System.Windows.Forms.Button btnFindFakeids;
    }
}

