using System;
using System.IO;
using System.Windows.Forms;

namespace DirectoryFileCount.Models
{
    [Serializable]
    public class Request
    {
        #region Fields
        private Guid _guid;
        private string _title;
        private string _path;
        private int _numberOfFiles;
        private int _numberOfDirectories;
        private long _sizeOfFiles;
        private string _data;
        private string _result;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public int NumberOfFiles
        {
            get { return _numberOfFiles; }
            set { _numberOfFiles = value; }
        }
        public int NumberOfDirectories
        {
            get { return _numberOfDirectories; }
            set { _numberOfDirectories = value; }
        }
        public long SizeOfFiles
        {
            get { return _sizeOfFiles; }
            set { _sizeOfFiles = value; }
        }
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
        #endregion

        #region Constructor
        public Request(string title, User user) : this()
        {
            _guid = Guid.NewGuid();
            _title = title;
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _path = folderBrowserDialog1.SelectedPath;
            }
            _sizeOfFiles = 0;
            try
            {
                DirectoryInfo di = new DirectoryInfo(_path);
                FileInfo[] fiArr = di.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                _numberOfDirectories = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories).Length;
                _numberOfFiles = fiArr.Length;
                foreach (FileInfo f in fiArr)
                    _sizeOfFiles += f.Length;
                _result = "Number of files: " + _numberOfFiles + " Number of directories: " + _numberOfDirectories + " Total size: " + _sizeOfFiles + " bytes";
            } catch (Exception e) {
                _numberOfDirectories = -1;
                _numberOfFiles = -1;
                _sizeOfFiles = -1;
                _result = e.ToString();
            }
            _data = DateTime.Now.ToString("dd MMMM yyyy");
            user.DirectoryFiles.Add(this);
        }

        private Request()
        {
        }
        #endregion
        public override string ToString()
        {
            return Path;
        }
    }   
}
