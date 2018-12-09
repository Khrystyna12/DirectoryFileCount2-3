using System;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DirectoryFileCount.DBModels
{
    [DataContract(IsReference = true)]
    public class Request
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _title;
        [DataMember]
        private string _path;
        [DataMember]
        private int _numberOfFiles;
        [DataMember]
        private int _numberOfDirectories;
        [DataMember]
        private long _sizeOfFiles;
        [DataMember]
        private string _data;
        [DataMember]
        private string _result;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;
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
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        public User User
        {
            get { return _user; }
            private set { _user = value; }
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
            DoRequest(user);
        }

        private async void DoRequest(User user)
        {
            //LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    _sizeOfFiles = 0;
                    DirectoryInfo di = new DirectoryInfo(_path);
                    FileInfo[] fiArr = di.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                    _numberOfDirectories = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories).Length;
                    _numberOfFiles = fiArr.Length;
                    foreach (FileInfo f in fiArr)
                        _sizeOfFiles += f.Length;
                    _result = "Number of files: " + _numberOfFiles + " Number of directories: " + _numberOfDirectories + " Total size: " + _sizeOfFiles + " bytes";
                    _data = DateTime.Now.ToString("dd MMMM yyyy");
                    user.Requests.Add(this);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return true;
            });
            //LoaderManager.Instance.HideLoader();
        }
        private Request()
        {
        }
        #endregion
        public override string ToString()
        {
            return Path;
        }

        #region EntityFrameworkConfiguration
        public class RequestEntityConfiguration : EntityTypeConfiguration<Request>
        {
            public RequestEntityConfiguration()
            {
                ToTable("Request");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                Property(s => s.Path)
                    .HasColumnName("Path")
                    .IsRequired();
                Property(s => s.Result)
                    .HasColumnName("Result")
                    .IsRequired();
            }
        }
        #endregion

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}
