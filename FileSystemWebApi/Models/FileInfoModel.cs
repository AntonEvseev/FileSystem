using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace FileSystemWebApi.Models
{
    public class FileInfoDataModel
    {
        public List<FileInfoData> findAll()
        {
            List<FileInfoData> li = new List<FileInfoData>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Fixed)
                {
                    li.Add(new FileInfoData { DirectoryName = d.Name, Puth = "" });
                }
            }
            return li;
        }

        public List<FileInfoData> findAll(string id)
        {
            List<FileInfoData> li = new List<FileInfoData>();
            string sDir = id;
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(sDir));
            foreach (var dir in dirs)
                    {
                        li.Add(new FileInfoData { Puth = sDir + "/",  DirectoryName = dir.Substring(dir.LastIndexOf("\\") + 1) });
                    }
            DirectoryInfo directory = new DirectoryInfo(id);
            try
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    li.Add(new FileInfoData { FileName = file.Name, Puth = file.DirectoryName });
                }
            }
            catch (UnauthorizedAccessException) { li.Add(new FileInfoData { Error = "Доступ к этой папке закрыт!Для просмотра этой папки нужны права администратора!" }); }
            //подсчет файлов
            var filesTop = Enumerable.Empty<FileInfo>();
            var filesAll = Enumerable.Empty<FileInfo>();
            try
            {
                var root = new DirectoryInfo(sDir);
                if (sDir.Count() > 3)
                {
                    filesTop = root.EnumerateFiles(".", SearchOption.AllDirectories);
                    var filesSmall = filesTop.Where(fi => fi.Length <= 10485760).Count();
                    var filesBig = filesTop.Where(fi => fi.Length > 104857600).Count();
                    var filesMiddle = filesTop.Where(fi => fi.Length > 10485760 && fi.Length < 52428800).Count();
                    li.Add(new FileInfoData { SizeSmall = filesSmall, SizeBig = filesBig, SizeMiddle = filesMiddle });
                }
                else
                {
                    IEnumerable<string> files = EnumerateAllFiles(sDir, ".");
                    int countSmall = 0;
                    int countMiddle = 0;
                    int countBig = 0;
                    
                        foreach (string file in files)
                        {
                            FileInfo fi = new FileInfo(file);
                            
                            try
                            {
                                if (fi.Length < 10485760)
                                {
                                    countSmall++;
                                }
                                if (fi.Length > 10485760 && fi.Length < 52428800)
                                {
                                    countMiddle++;
                                }
                                if (fi.Length > 104857600)
                                {
                                    countBig++;
                                }
                            }
                            catch { }
                        }
                        li.Add(new FileInfoData { SizeSmall = countSmall, SizeMiddle = countMiddle, SizeBig = countBig });
                        }  
            }
            catch (UnauthorizedAccessException) { li.Add(new FileInfoData { Error = "Доступ к этой папке закрыт!Для просмотра этой папки нужны права администратора!" }); }
            return li;
        }

        public static IEnumerable<string> EnumerateAllFiles(string path, string pattern)
        {
            IEnumerable<string> files = null;
            try { files = Directory.EnumerateFiles(path, pattern); }
            catch { }
            if (files != null)
            {
                foreach (var file in files) yield return file;
            }
            IEnumerable<string> directories = null;
            try { directories = Directory.EnumerateDirectories(path); }
            catch { }
            if (directories != null)
            {
                foreach (var file in directories.SelectMany(d => EnumerateAllFiles(d, pattern)))
                {
                    yield return file;
                }
            }
        }

        








       
   }
}