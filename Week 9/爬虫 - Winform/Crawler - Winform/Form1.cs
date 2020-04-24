using SimpleCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Crawler___Winform
{
    public partial class Form1 : Form
    {
        BindingSource resultBindingSource = new BindingSource();
        Crawler Crawler = new Crawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            ResultGridView.DataSource = resultBindingSource;
            Crawler.PageDownloaded += PageDownloaded;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            resultBindingSource.Clear();
            Crawler.startUrl = txtUrl.Text;

            if (thread != null)
            {
                thread.Abort();
            }
            Crawler.urls.Add(Crawler.startUrl, false);//加入初始页面
            thread = new Thread(Crawler.Crawl);
            thread.Start();
        }


        private void PageDownloaded(Crawler crawler, string url)
        {
            var pageInfo = new { Index = resultBindingSource.Count + 1, URL = url };
            Action action = () => { resultBindingSource.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
