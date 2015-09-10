using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.DownloaderCode;
using Test.DB.Model;
using System.IO;
using Test;
using Test.DB.DAL;
using System.Xml.Serialization;
using System.Xml;
using MySql.Data.MySqlClient;

namespace DownloaderConsole
{
    public class ImagesModel
    {
        public int id { get; set; }
        public string keyw { get; set; }
        public string title { get; set; }
        public string FileName { get; set; }
        public string img_url { get; set; }
        public string Url { get; set; }
        public string provider { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "export")
            {
                imagesDal imgDal = new imagesDal();
                List<ImagesModel> lst = GetList(); // imgDal.getImages();

                XmlSerializer ser = new XmlSerializer(typeof(List<ImagesModel>));
                XmlWriterSettings newXmlWriterSettings = new XmlWriterSettings();
                newXmlWriterSettings.OmitXmlDeclaration = true;

                XmlWriter wr = XmlTextWriter.Create("output.xml", newXmlWriterSettings);

                ser.Serialize(wr, lst);
            }
            else if (args[0] == "import")
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<ImagesModel>));
                XmlReaderSettings newXmlReaderSettings = new XmlReaderSettings();

                XmlReader rd = XmlReader.Create(File.OpenRead("output.xml"), newXmlReaderSettings);

                List<ImagesModel> lst = ser.Deserialize(rd) as List<ImagesModel>;
            }
            else
            {
                Console.WriteLine("Starting...");
                Downloader d = new Downloader();
                d.Start();
            }
        }

        private static List<ImagesModel> GetList()
        {
            var list = new List<ImagesModel>();

            MysqlCon db = new MysqlCon();
            MySqlConnection conn = db.connect();

            MySqlCommand command = new MySqlCommand("select * from images where isdownload=0;", conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ImagesModel { FileName = reader.GetString("filename"), Url = reader.GetString("img_url"), title = reader.GetString("title"), keyw = reader.GetString("keyw") });
            }

            reader.Close();
            db.disconnect(conn);

            return list;



        }

        public class Downloader
        {
            public DownloadManager Manager { get; set; }
            List<string> downloadExceptions = new List<string>();
            int success = 0;
            int failed = 0;
            List<imagesModel> list = new List<imagesModel>();
            // imagesDal imgDal = new imagesDal();

            int pos = 0;
            bool stop = false;

            public Downloader()
            {
                this.Manager = new DownloadManager(20);
            }

            public void Start()
            {
                list = GetImages();
                StartLoadDummyDownloadList();
                // lbl_total.Text = list.Count.ToString();
                pos = 0;
                this.Manager.DownloadCompleted += new EventHandler<DownloadCompletedEventArgs>(Manager_DownloadCompleted);
                this.Manager.DownloadProgress += new EventHandler<DownloadProgressEventArgs>(Manager_DownloadProgress);
                this.Manager.FileDownloadCompleted += new EventHandler<FileDownloadCompletedEventArgs>(Manager_FileDownloadCompleted);

                this.Manager.Start();
            }

            private List<imagesModel> GetImages()
            {
                return new List<imagesModel>(); // imgDal.getImages();
            }

            void Manager_FileDownloadCompleted(object sender, FileDownloadCompletedEventArgs e)
            {
                // consider locking here
                // this.downloadUIsPanel.Controls.Remove(this.DownloadUIs[e.File.ID]);
                // this.DownloadUIs.Remove(e.File.ID);

                string exceptionLogFormat = "{0}|{1}|{2}";
                if (e.Error == null && !e.Cancelled)
                {
                    setDownloaded(e.File.ID);
                    success++;

                }
                else
                {
                    downloadExceptions.Add(string.Format(exceptionLogFormat, e.File.ID, e.File.URL, e.Error.Message));
                    failed++;
                }

                refStats();
                if (!stop)
                {
                    LoadDummyDownloadList();
                }
            }

            void Manager_DownloadProgress(object sender, DownloadProgressEventArgs e)
            {
                //if (this.DownloadUIs.ContainsKey(e.File.ID))
                //{
                //    //DownloadUI ui = this.DownloadUIs[e.File.ID];
                //    //ui.Percentage = e.ProgressPercentage;
                //}
            }

            void Manager_DownloadCompleted(object sender, DownloadCompletedEventArgs e)
            {
                // MessageBox.Show("All downloaded");
            }

            private void StartLoadDummyDownloadList()
            {

                for (int pos = 0; pos < 19; pos++)
                {


                    string folder = list[pos].getKeyw().Trim().Replace(' ', '-');
                    DirectoryInfo dir = new DirectoryInfo("C:\\DownloadTest\\" + folder + "\\");
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }

                    this.Manager.EnqueueFile(new DownloadFileModel(list[pos].getId(), list[pos].getImg_url(), dir + "\\" + list[pos].getFilename()));
                    // setDownloaded(list[pos].getId());
                    list.RemoveAt(pos);
                }
            }
            private void LoadDummyDownloadList()
            {


                string folder = list[0].getKeyw().Trim().Replace(' ', '-');
                DirectoryInfo dir = new DirectoryInfo("C:\\DownloadTest\\" + folder + "\\");
                if (!dir.Exists)
                {
                    dir.Create();
                }

                this.Manager.EnqueueFile(new DownloadFileModel(list[0].getId(), list[0].getImg_url(), dir + "\\" + list[0].getFilename()));
                // setDownloaded(list[0].getId());
                list.RemoveAt(0);



                // this can be triggered with a timer later on. 

                //	this.EnqueueFile(new DownloadFileModel("http://download.thinkbroadband.com/5MB.zip", "c:\\DownloadTest\\2.zip"));

            }

            private void setDownloaded(int fileID)
            {
                //MysqlCon db = new MysqlCon();
                //MySqlConnection conn = db.connect();

                //MySqlCommand command = new MySqlCommand("Update images set isdownload=1 where id=" + fileID, conn);
                //command.ExecuteNonQuery();

                //db.disconnect(conn);

            }

            void refStats()
            {
                // lbl_attempt.Text = (Convert.ToInt32(lbl_total.Text.ToString()) - Convert.ToInt32(list.Count.ToString())).ToString();
                // lbl_success.Text = success.ToString();
                // lbl_failed.Text = failed.ToString();
                Console.WriteLine("Success : " + success.ToString() + " - Failed : " + failed.ToString());
            }
        }
    }
}
