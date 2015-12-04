using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xp.Weixin.MP.SDK.Api;
using Xp.Weixin.MP.Common;
using System.IO;

namespace TestXpApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetGroups_Click(object sender, EventArgs e)
        {
            var groupResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.GetGroups();
        }

        private void btnGetFriends_Click(object sender, EventArgs e)
        {
            var friendsResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.GetFriends();
        }

        private void btnGetFriendsDetail_Click(object sender, EventArgs e)
        {
            long[] fakeids = new long[1] { 2508188462 };
            var friendsDetailResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.GetFriendsDetail(fakeids);
        }

        private void btnGetFriendHeadImage_Click(object sender, EventArgs e)
        {
            long fakeid = 457222000;
            var friendsHeadResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.GetFriendHeadImage(fakeid);

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

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var sendResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).MessageApi.SendMessage("文本信息","2508188462");
        }

        private void btnSendImageText_Click(object sender, EventArgs e)
        {
            var sendResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).MessageApi.SendImageTextMessage("10014139", "2508188462");
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
            article.Show_cover_pic = 0;//0不显示在正文中，1显示

            List<Article> listArticle = new List<Article>();
            listArticle.Add(article);

            var result = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).MediaApi.OrginNews(listArticle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).MediaApi.GetAppMsgList();
        }

        private void btnGetFriendsDetailByOpenid_Click(object sender, EventArgs e)
        {
            string[] openids = new string[1] { "oerBeuEIN-VsJUi6gr7zbMONjRZk" };
            var friendsDetailResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.GetFriendsDetail(openids);
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var uploadResult = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).MediaApi.UploadFile(openFileDialog1.FileName);
            }
        }

        private void btnFindFakeId_Click(object sender, EventArgs e)
        {
            var result = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.FindFakeid("subscribe21100356420140411173142user");
        }

        private void btnFindFakeids_Click(object sender, EventArgs e)
        {
            string[] keywords ={"subscribe211016523201407111058138296user",
                                "subscribe211016524201407111058273721user",
                                "subscribe211016525201407111059063421user",
                                "subscribe211016526201407111059143371user"};
            var result = SdkManager.GetApiContainer(tbUserName.Text, tbPassword.Text).FriendApi.FindFakeids(keywords);
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
