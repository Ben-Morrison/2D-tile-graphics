using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class DataManager
    {
        private string path;
        private FileStream file;

        public DataManager()
        {
            path = String.Empty;
        }

        public string Path
        {
            get { return this.path; }
        }

        public bool IsFileOpen()
        {
            return (file != null);
        }

        public bool CreateFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                this.path = path;

                return true;
            }
            catch (Exception e)
            {
                CloseFile();
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool OpenFile(string path)
        {
            return false;
        }

        public bool CloseFile()
        {
            if (file != null)
                file.Close();

            this.path = String.Empty;
            return false;
        }
    }
}
