namespace TestXpApi
{
    partial class frmAdvance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendText = new System.Windows.Forms.Button();
            this.tbAppId = new System.Windows.Forms.TextBox();
            this.tbSecret = new System.Windows.Forms.TextBox();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnUpdateGroup = new System.Windows.Forms.Button();
            this.btnGetAllGroup = new System.Windows.Forms.Button();
            this.btnMoveUserGroup = new System.Windows.Forms.Button();
            this.btnSendGroupMessageByOpenId = new System.Windows.Forms.Button();
            this.btnMediaUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnNewsUpload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(31, 86);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 0;
            this.btnSendText.Text = "SentText";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // tbAppId
            // 
            this.tbAppId.Location = new System.Drawing.Point(31, 26);
            this.tbAppId.Name = "tbAppId";
            this.tbAppId.Size = new System.Drawing.Size(143, 21);
            this.tbAppId.TabIndex = 1;
            this.tbAppId.Text = "wx98e8c2b5fdb076a6";
            // 
            // tbSecret
            // 
            this.tbSecret.Location = new System.Drawing.Point(247, 26);
            this.tbSecret.Name = "tbSecret";
            this.tbSecret.Size = new System.Drawing.Size(143, 21);
            this.tbSecret.TabIndex = 2;
            this.tbSecret.Text = "a4210559561070cfb3f960275889666c";
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(113, 86);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(81, 23);
            this.btnCreateGroup.TabIndex = 3;
            this.btnCreateGroup.Text = "CreateGroup";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 4;
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.Location = new System.Drawing.Point(201, 86);
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateGroup.TabIndex = 5;
            this.btnUpdateGroup.Text = "UpdateGroup";
            this.btnUpdateGroup.UseVisualStyleBackColor = true;
            this.btnUpdateGroup.Click += new System.EventHandler(this.btnUpdateGroup_Click);
            // 
            // btnGetAllGroup
            // 
            this.btnGetAllGroup.Location = new System.Drawing.Point(283, 86);
            this.btnGetAllGroup.Name = "btnGetAllGroup";
            this.btnGetAllGroup.Size = new System.Drawing.Size(84, 23);
            this.btnGetAllGroup.TabIndex = 6;
            this.btnGetAllGroup.Text = "GetAllGroup";
            this.btnGetAllGroup.UseVisualStyleBackColor = true;
            this.btnGetAllGroup.Click += new System.EventHandler(this.btnGetAllGroup_Click);
            // 
            // btnMoveUserGroup
            // 
            this.btnMoveUserGroup.Location = new System.Drawing.Point(31, 115);
            this.btnMoveUserGroup.Name = "btnMoveUserGroup";
            this.btnMoveUserGroup.Size = new System.Drawing.Size(100, 23);
            this.btnMoveUserGroup.TabIndex = 7;
            this.btnMoveUserGroup.Text = "MoveUserGroup";
            this.btnMoveUserGroup.UseVisualStyleBackColor = true;
            this.btnMoveUserGroup.Click += new System.EventHandler(this.btnMoveUserGroup_Click);
            // 
            // btnSendGroupMessageByOpenId
            // 
            this.btnSendGroupMessageByOpenId.Location = new System.Drawing.Point(31, 165);
            this.btnSendGroupMessageByOpenId.Name = "btnSendGroupMessageByOpenId";
            this.btnSendGroupMessageByOpenId.Size = new System.Drawing.Size(163, 23);
            this.btnSendGroupMessageByOpenId.TabIndex = 8;
            this.btnSendGroupMessageByOpenId.Text = "SendGroupMessageByOpenId";
            this.btnSendGroupMessageByOpenId.UseVisualStyleBackColor = true;
            this.btnSendGroupMessageByOpenId.Click += new System.EventHandler(this.btnSendGroupMessageByOpenId_Click);
            // 
            // btnMediaUpload
            // 
            this.btnMediaUpload.Location = new System.Drawing.Point(181, 136);
            this.btnMediaUpload.Name = "btnMediaUpload";
            this.btnMediaUpload.Size = new System.Drawing.Size(95, 23);
            this.btnMediaUpload.TabIndex = 9;
            this.btnMediaUpload.Text = "MediaUpload";
            this.btnMediaUpload.UseVisualStyleBackColor = true;
            this.btnMediaUpload.Click += new System.EventHandler(this.btnMediaUpload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnNewsUpload
            // 
            this.btnNewsUpload.Location = new System.Drawing.Point(292, 136);
            this.btnNewsUpload.Name = "btnNewsUpload";
            this.btnNewsUpload.Size = new System.Drawing.Size(75, 23);
            this.btnNewsUpload.TabIndex = 10;
            this.btnNewsUpload.Text = "NewsUpload";
            this.btnNewsUpload.UseVisualStyleBackColor = true;
            this.btnNewsUpload.Click += new System.EventHandler(this.btnNewsUpload_Click);
            // 
            // frmAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 275);
            this.Controls.Add(this.btnNewsUpload);
            this.Controls.Add(this.btnMediaUpload);
            this.Controls.Add(this.btnSendGroupMessageByOpenId);
            this.Controls.Add(this.btnMoveUserGroup);
            this.Controls.Add(this.btnGetAllGroup);
            this.Controls.Add(this.btnUpdateGroup);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.tbSecret);
            this.Controls.Add(this.tbAppId);
            this.Controls.Add(this.btnSendText);
            this.Name = "frmAdvance";
            this.Text = "frmAdvance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.TextBox tbAppId;
        private System.Windows.Forms.TextBox tbSecret;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnUpdateGroup;
        private System.Windows.Forms.Button btnGetAllGroup;
        private System.Windows.Forms.Button btnMoveUserGroup;
        private System.Windows.Forms.Button btnSendGroupMessageByOpenId;
        private System.Windows.Forms.Button btnMediaUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnNewsUpload;

    }
}