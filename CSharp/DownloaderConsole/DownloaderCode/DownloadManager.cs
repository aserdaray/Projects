using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Test.DownloaderCode
{
	public class DownloadManager
	{
		public event EventHandler<FileDownloadCompletedEventArgs> FileDownloadCompleted;
		public event EventHandler<DownloadProgressEventArgs> DownloadProgress;
		public event EventHandler<DownloadCompletedEventArgs> DownloadCompleted;

		Queue<DownloadFileModel> DownloadList { get; set; }
		public int MaxConcurrentDownload { get; set; }
		public List<WebClient> Downloaders { get; set; }

		protected virtual void On_FileDownloadCompleted(FileDownloadCompletedEventArgs e)
		{
			if (this.FileDownloadCompleted != null)
			{
				this.FileDownloadCompleted(this, e);
			}

			this.Start();
		}

		protected virtual void On_DownloadProgressEventArgs(DownloadProgressEventArgs e)
		{
			if (this.DownloadProgress != null)
			{
				this.DownloadProgress(this, e);
			}
		}

		protected virtual void On_DownloadCompletedEventArgs(DownloadCompletedEventArgs e)
		{
			if (this.DownloadCompleted != null)
			{
				this.DownloadCompleted(this, e);
			}
		}

		public DownloadManager(int maxConcurrentDownload)
		{
			this.MaxConcurrentDownload = maxConcurrentDownload;
			
			this.DownloadList = new Queue<DownloadFileModel>();
			this.Downloaders = new List<WebClient>(maxConcurrentDownload);
			
			WebClient c;
			for (int i = 0; i < maxConcurrentDownload; i++)
			{
				c = new WebClient();
				c.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				c.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
				this.Downloaders.Add(c);
			}
		}

		public void EnqueueFile(DownloadFileModel file)
		{
			this.DownloadList.Enqueue(file);
		}

		internal void Start()
		{
			if (this.DownloadList.Count == 0)
			{
				// list emptied downloads will be finished soon. 
				return;
			}

			DownloadFileModel tmp;
			WebClient downloader = GetNextAvailableDownloader();
			while (downloader != null)
			{
                if (!(this.DownloadList.Count == 0))
				{
					// list emptied downloads will be finished soon. 
					return;
				}

                tmp = this.DownloadList.Dequeue();
				downloader.DownloadFileAsync(new Uri(tmp.URL), tmp.FileName, tmp);
				downloader = GetNextAvailableDownloader();
			}

            this.On_DownloadCompletedEventArgs(new DownloadCompletedEventArgs());
		}

		private WebClient GetNextAvailableDownloader()
		{
#if DEBUG
            Console.WriteLine("DownloadManager.GetNextAvailableDownloader");
#endif

			var e = from n in this.Downloaders where n.IsBusy == false select n;
			return e.FirstOrDefault();
		}

		void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			FileDownloadCompletedEventArgs ex = new FileDownloadCompletedEventArgs();
			ex.Cancelled = e.Cancelled;
			ex.Error = e.Error;
			ex.File = e.UserState as DownloadFileModel;

			this.On_FileDownloadCompleted(ex);
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			DownloadProgressEventArgs ex = new DownloadProgressEventArgs();
 			ex.BytesReceived = e.BytesReceived;
			ex.ProgressPercentage = e.ProgressPercentage;
			ex.TotalBytesToReceive = e.TotalBytesToReceive;
			ex.File = e.UserState as DownloadFileModel;

			this.On_DownloadProgressEventArgs(ex);
		}
	}

	public class DownloadProgressEventArgs : EventArgs
	{
		public long BytesReceived { get; set; }
		public int ProgressPercentage { get; set; }
		public long TotalBytesToReceive { get; set; }
		public DownloadFileModel File { get; set; }
	}

	public class DownloadCompletedEventArgs : EventArgs
	{

	}

	public class FileDownloadCompletedEventArgs : EventArgs
	{
		public bool Cancelled { get; set; }
		public Exception Error { get; set; }
		public DownloadFileModel File { get; set; }
	}

	public class DownloadFileModel
	{
		public string URL { get; set; }
		public string FileName { get; set; }
        public int ID { get; set; }

		public DownloadFileModel(int id, string url, string fileName)
		{
            this.ID = id;
			this.FileName = fileName;
			this.URL = url;
		}

		public DownloadFileModel()
		{

		}
    }
}
