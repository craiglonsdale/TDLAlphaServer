/*
 * Code radically written by: Kira Qian (Person way smarter than me) 
 * From:
 * http://social.msdn.microsoft.com/Forums/en/winforms/thread/19230fe5-b158-4a5c-979f-583cd5887bb4
 *
 * No license given, so no license is implied, do with this code as you wish... i guess???'
 * Updated by Craig Lonsdale to log individual files rather than a single file in a directory - 9/11/2012
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace TDL_Alpha_Server
{
    public class LogFileNotifier : INotifyPropertyChanged
    {
        public Control BindingControl
        {
            get;
            private set;
        }

        public string Path
        {
            get;
            private set;
        }

        private string fileContent;
        public string FileContent
        {
            get { return fileContent; }
            set
            {
                fileContent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FileContent"));
            }
        }

        private FileSystemWatcher watcher;

        public LogFileNotifier(string path, Control bindingControl)
        {
            Path = path;
            BindingControl = bindingControl;

            fileContent = File.ReadAllText(path);
            this.PropertyChanged = new PropertyChangedEventHandler(OnContentChanged);
            this.setValue = new SetValueDlg(SetContentValue);

            watcher = new FileSystemWatcher();
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.Path = System.IO.Path.GetDirectoryName(path);
            watcher.Filter = System.IO.Path.GetFileName(path);
            watcher.EnableRaisingEvents = true;
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            BindingControl.Invoke(setValue, e.FullPath);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnContentChanged(object sender, PropertyChangedEventArgs e)
        {}
        #endregion

        public delegate void SetValueDlg(string fileName);
        private SetValueDlg setValue;
        private void SetContentValue(string fileName)
        {
            this.FileContent = File.ReadAllText(fileName);
        }
    }
}
