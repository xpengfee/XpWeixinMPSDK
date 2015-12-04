using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xp.Weixin.MP.SDK;
using Xp.Weixin.MP.Common;
using System.IO;

namespace TestSDK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text");
            dt.Columns.Add("value");

            DataRow dr = dt.NewRow();
            dr[0] = "自开发API";
            dr[1] = "Xp.Weixin.MP.SDK.XpProvider";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Senparc";
            dr[1] = "Xp.Weixin.MP.SDK.SenparcProvider";
            dt.Rows.Add(dr);

            this.cbSDK.DataSource = dt;
            this.cbSDK.DisplayMember = "text";
            this.cbSDK.ValueMember = "value";
            this.cbSDK.SelectedValue = "Xp.Weixin.MP.SDK.SenparcProvider";
        }


        private void cbSDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbSDK.SelectedValue == "Xp.Weixin.MP.SDK.XpProvider")
            {
                tbUserName.Text = "qqdao@163.com";
                tbPassword.Text = "solution";
            }
            else
            {                
                tbUserName.Text = "cb58de24ed314ca49373468fd0fd7784";
                tbPassword.Text = "16245142c41f4517a15364f6eb70c727";            
            }
        }

        private void btnGetGroups_Click(object sender, EventArgs e)
        {
            GroupsResult result = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).GetGroups(tbUserName.Text, tbPassword.Text);
        }

        private void btnGetFriends_Click(object sender, EventArgs e)
        {
            FriendsResult result = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).GetFriends(tbUserName.Text, tbPassword.Text);
        }


        private void btnGetFriendsDetail_Click(object sender, EventArgs e)
        {
            long[] fakeids = new long[1] { 2508188462 };
            FriendsDetailResult result = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).GetFriendsDetail(tbUserName.Text, tbPassword.Text,fakeids);
        }


        private void btnGetFriendHeadImage_Click(object sender, EventArgs e)
        {
            long fakeid = 457222000;
            var friendsHeadResult = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).GetFriendHeadImage(tbUserName.Text, tbPassword.Text,fakeid);

            if (friendsHeadResult.Ret == ResultKind.成功)
            {
                byte[] imageBytes = Convert.FromBase64String(friendsHeadResult.Data.HeadImageBase64);

                MemoryStream ms = new MemoryStream(imageBytes);
                Bitmap bitmap = new Bitmap(ms);

                pbHeadImage.Image = (System.Drawing.Image)bitmap;
            }
            else
            {
                MessageBox.Show(friendsHeadResult.ErrorMessage);
            }
        }

        private void btnOrginNews_Click(object sender, EventArgs e)
        {
            Article article = new Article();
            article.Title = "北京欢迎你";
            article.Author = "xpengfee";
            article.Digest = "Welcome to BeiJing";
            article.Content = "北京欢迎你<br/>北京欢迎你<br/>";
            article.SourceUrl = "www.baidu.com";
            article.FileSrc = @"C:\Users\xp\Pictures\720400\20131011_OnePiece_Lufei.jpg";
            article.Show_cover_pic = 0;

            List<Article> listArticle = new List<Article>();
            listArticle.Add(article);

            OrginNewsResult result = ApiAccess.Create_MediaApi(this.cbSDK.SelectedValue.ToString()).OrginNews(tbUserName.Text, 
                tbPassword.Text,listArticle);
        }


        private void btnSendImageText_Click(object sender, EventArgs e)
        {
            var sendResult = ApiAccess.Create_MessageApi(this.cbSDK.SelectedValue.ToString()).SendImageTextMessage(tbUserName.Text,
                tbPassword.Text, "10014139", "2508188462");
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var sendResult = ApiAccess.Create_MessageApi(this.cbSDK.SelectedValue.ToString()).SendMessage(tbUserName.Text,
                tbPassword.Text,"文本信息", "2508188462");
        }

        private void btnGetAppMsg_Click(object sender, EventArgs e)
        {
            var result = ApiAccess.Create_MediaApi(this.cbSDK.SelectedValue.ToString()).GetAppMsgList(tbUserName.Text,
                tbPassword.Text);
        }

        private void btnFindFakeId_Click(object sender, EventArgs e)
        {
            var result = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).FindFakeid(tbUserName.Text,
                tbPassword.Text,"subscribe21100690820140410165633user");
        }

        private void btnFindFakeids_Click(object sender, EventArgs e)
        {
            //string[] keywords ={"subscribe21100354520140411112447user",
            //                    "subscribe21100354620140411112839user",
            //                    "subscribe21100354720140411113922user",
            //                    "subscribe21100019820140411114814user",
            //                    "subscribe21100354820140411121205user",
            //                    "subscribe21100354920140411122633user",
            //                    "subscribe21100355020140411123500user",
            //                    "subscribe21100355120140411124124user",
            //                    "subscribe21100355220140411133246user"};
            string[] keywords = { "subscribe211007316201404131335581011user" };
            var result = ApiAccess.Create_FriendApi(this.cbSDK.SelectedValue.ToString()).FindFakeids(tbUserName.Text,
                tbPassword.Text, keywords);
        }



    }
}
