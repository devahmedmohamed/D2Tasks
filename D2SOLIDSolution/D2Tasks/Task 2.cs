using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2Tasks
{
    #region Before Requirement
    //public interface IFileHandler
    //{
    //    string LoadText();
    //    void SaveText(string content);
    //}

    //public class SqlFile : IFileHandler
    //{
    //    public string FilePath { get; set; }
    //    public string FileText { get; set; }

    //    public string LoadText()
    //    {
    //        FileText = File.ReadAllText(FilePath);
    //        return FileText;
    //    }

    //    public void SaveText(string content)
    //    {
    //        File.WriteAllText(FilePath, content);
    //    }
    //}

    //public class SqlFileManager
    //{
    //    private readonly List<IFileHandler> _files;

    //    public SqlFileManager(List<IFileHandler> files)
    //    {
    //        _files = files;
    //    }

    //    public string GetTextFromFiles()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        foreach (var file in _files)
    //        {
    //            sb.Append(file.LoadText());
    //        }
    //        return sb.ToString();
    //    }

    //    public void SaveTextIntoFiles(string content)
    //    {
    //        foreach (var file in _files)
    //        {
    //            file.SaveText(content);
    //        }
    //    }
    //}
    #endregion

    #region After Requirement
    public interface IFileHandler
    {
        string LoadText();
    }

    public interface IWritableFileHandler : IFileHandler
    {
        void SaveText(string content);
    }

    public class SqlFile : IWritableFileHandler
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public string LoadText()
        {
            return File.ReadAllText(FilePath);
        }

        public void SaveText(string content)
        {
            File.WriteAllText(FilePath, content);
        }
    }

    public class ReadOnlySqlFile : IFileHandler
    {
        public string FilePath { get; set; }

        public string LoadText()
        {
            return File.ReadAllText(FilePath);
        }
    }

    public class SqlFileManager
    {
        private readonly List<IFileHandler> _files;

        public SqlFileManager(List<IFileHandler> files)
        {
            _files = files;
        }

        public string GetTextFromFiles()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var file in _files)
            {
                sb.Append(file.LoadText());
            }
            return sb.ToString();
        }

        public void SaveTextIntoFiles(string content)
        {
            foreach (var file in _files)
            {
                if (file is IWritableFileHandler writableFile)
                {
                    writableFile.SaveText(content);
                }
            }
        }
    }

    #endregion
}
