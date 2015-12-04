using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Xp.Weixin.MP.SDK.Api.CommonAPIs;
using Xp.Weixin.MP.SDK.Api.AdvancedAPIs;
using Xp.Weixin.MP.Common;

namespace TestXpApi
{
    public partial class frmAdvance : Form
    {
        public frmAdvance()
        {
            InitializeComponent();
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {

            try
            {
                string msg = string.Format("我是{0},你好", string.Format("<a href=\"{0}\">baidu</a>","www.baidu.com"));
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = Custom.SendText(accessToken, "oerBeuJ4JtXG5bgPijfFVVIIYEOg", msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = Groups.Create(accessToken, textBox1.Text);
                MessageBox.Show(result.errcode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = Groups.Update(accessToken, 106, textBox1.Text);
                MessageBox.Show(result.errcode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetAllGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = Groups.Get(accessToken);
                MessageBox.Show(result.errcode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMoveUserGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = Groups.MemberUpdate(accessToken, "oerBeuFSqrleZj_A6OHDX2uASsZM", 106);
                MessageBox.Show(result.errcode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendGroupMessageByOpenId_Click(object sender, EventArgs e)
        {
            try
            {
                string[] openids = new string[1] { "oerBeuJ4JtXG5bgPijfFVVIIYEOg" };
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                var result = GroupMessage.SendGroupMessageByOpenId(accessToken, "200119749", openids);
                MessageBox.Show(result.errcode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMediaUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);

                    var result = Media.Upload(accessToken, UploadMediaFileType.image, openFileDialog1.FileName);
                    MessageBox.Show(result.errcode.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewsUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var accessToken = AccessTokenContainer.TryGetToken(tbAppId.Text, tbSecret.Text);
                NewsModel news = new NewsModel();
                news.author = "爱玛";
                news.content = "hhhhh测试一下了啦啦啦似的看法空房";
                news.content_source_url = "www.baidu.com";
                news.digest = "摘要";
                news.thumb_media_id = "t3vzdnxkTVDJ9Ji4mtnqgbk-GJwCwLrCOq_bg3GKuXHYaj0wC6zObdxPjuU0hQBW";
                news.title = "测试一下";

                var result = Media.UploadNews(accessToken, news);
                MessageBox.Show(result.media_id.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
