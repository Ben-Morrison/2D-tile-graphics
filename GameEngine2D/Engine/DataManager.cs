using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public class DataManager
    {
        private ISave save;

        private string path;
        private FileStream file;

        public DataManager(ISave save)
        {
            this.save = save;
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

                file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

                save.SaveGame(file, new SaveClass(Engine.game, Engine.ContentManager.Textures));

                this.path = path;

                return true;
            }
            catch (Exception e)
            {
                while(e.Message != null)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show(e.StackTrace);

                    if(e.InnerException != null)
                        e = e.InnerException;
                }

                return false;
            }
        }

        public SaveClass OpenFile(string path)
        {
            SaveClass newgame = null;

            try
            {
                if (File.Exists(path))
                {

                    file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                    newgame = save.LoadGame(file);
                    this.path = path;

                    return newgame;
                }
                else
                {
                    CloseFile();
                    return null;
                }
            }
            catch (Exception e)
            {
                CloseFile();

                while (e.Message != null)
                {
                    MessageBox.Show(e.Message);
                    MessageBox.Show(e.StackTrace);

                    if (e.InnerException != null)
                        e = e.InnerException;
                }

                return null;
            }
        }

        public void CloseFile()
        {
            if (file != null)
            {
                file.Close();
                file.Dispose();
            }

            this.path = String.Empty;
        }
    }
}
