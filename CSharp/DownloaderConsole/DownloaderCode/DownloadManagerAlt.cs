using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test.DownloaderCode
{
    public partial class DownloadManagerAlt
    {
        public class FileDownloadCompletedEventArgs : EventArgs
        {
            public int FileID { get; set; }
        }

        public event EventHandler<FileDownloadCompletedEventArgs> FileDownloaded;

        public virtual void OnFileDownloaded(FileDownloadCompletedEventArgs args)
        {
            if (this.FileDownloaded != null)
            {
                this.FileDownloaded(this, args);
            }
        }
    }

    public partial class DownloadManagerAlt
    {
        public void DownloaderFunction()
        {
            int readBytes = 0;
            int downloadBytes = 5000;
            while (readBytes <= downloadBytes)
            {
                readBytes += 5;
            }

            var e = new FileDownloadCompletedEventArgs();
            e.FileID = 5;
            this.OnFileDownloaded(e);
        }
    }

    public class DownloaderForm
    {
        public DownloadManagerAlt DManager { get; set; }

        public DownloaderForm()
        {
            this.DManager = new DownloadManagerAlt();
            this.DManager.FileDownloaded += new EventHandler<DownloadManagerAlt.FileDownloadCompletedEventArgs>(DManager_FileDownloaded);
        }

        void DManager_FileDownloaded(object sender, DownloadManagerAlt.FileDownloadCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
