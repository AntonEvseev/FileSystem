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
            //new
            DirectoryInfo directory = new DirectoryInfo(id);
            foreach (FileInfo file in directory.GetFiles())
            {
                li.Add(new FileInfoData { FileName = file.Name, Puth = file.DirectoryName});
            }
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
                    filesTop = root.EnumerateFiles(".", SearchOption.TopDirectoryOnly);
                    li.Add(new FileInfoData { SizeSmall = filesTop.Count() });
                }
            }
            catch (UnauthorizedAccessException) { }
















                                           //start ols code
            ////Вывод списка файлов в каталоге
            //DriveInfo di = new DriveInfo(sDir);
            //DirectoryInfo dirInfo = di.RootDirectory;
            //FileInfo[] fileNames = dirInfo.GetFiles("*.*");
            //foreach (System.IO.FileInfo fi in fileNames)
            //{
            //    li.Add(new FileInfoData { FileName = fi.Name });
            //}



            //Подсчет файлов
            //var filesTop = Enumerable.Empty<FileInfo>();
            //var filesAll = Enumerable.Empty<FileInfo>();
            //try
            //{
            //    var root = new DirectoryInfo(sDir);
            //    if (sDir.Count() > 3)
            //    {
            //        filesTop = root.EnumerateFiles(".", SearchOption.AllDirectories);
            //        var filesSmall = filesTop.Where(fi => fi.Length <= 10485760).Count();
            //        var filesBig = filesTop.Where(fi => fi.Length > 104857600).Count();
            //        var filesMiddle = filesTop.Where(fi => fi.Length > 10485760 && fi.Length < 52428800).Count();

            //        li.Add(new FileInfoData { SizeSmall = filesSmall, SizeBig = filesBig, SizeMiddle = filesMiddle });
            //    }
            //    else
            //    {
            //        filesTop = root.EnumerateFiles(".", SearchOption.TopDirectoryOnly);
            //        li.Add(new FileInfoData { SizeSmall = filesTop.Count() });
            //    }
            //}
            //catch (UnauthorizedAccessException) { }
                                                 //end old code!


            
            //DirectoryInfo direc = new DirectoryInfo(sDir);
            ////Вывод списка файлов в каталоге
            //DirectoryInfo[] directories = direc.GetDirectories(".");
            //foreach (DirectoryInfo subDirectory in directories)
            //{

            //    FileInfo[] filesSubDir = subDirectory.GetFiles("*.*");
            //    foreach (FileInfo fi in filesSubDir)
            //    {

            //        li.Add(new FileInfoData { FileName = fi.Name });
            //    }

            //}
            //DriveInfo di = new DriveInfo(sDir);
            //DirectoryInfo dirInfo = di.RootDirectory;
            //FileInfo[] fileNames = dirInfo.GetFiles("*.*");
            //foreach (System.IO.FileInfo fi in fileNames)
            //{
            //    li.Add(new FileInfoData { SizeSmall = fi.Length.ToString()});
            //}
            //System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
            //string currentDirName = System.IO.Directory.GetCurrentDirectory();
            //string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");
            //foreach (string s in files)
            //{
            //    // Create the FileInfo object only when needed to ensure
            //    // the information is as current as possible.
            //    System.IO.FileInfo fi = null;
            //    try
            //    {
            //        fi = new System.IO.FileInfo(s);
                    
            //    }
            //    catch (System.IO.FileNotFoundException e)
            //    {
                    
            //        continue;
            //    }
               
            //    li.Add(new FileInfoData { SizeMiddle = fi.Length, SizeSmall = files.Length });
            //}
            //try
            //{
            //    var direct = new DirectoryInfo(sDir);
            //    var filesSmall = direct.EnumerateFiles(".", SearchOption.AllDirectories).Where(fi => fi.Length < 10485760);
            //    var filesBig = direct.EnumerateFiles(".", SearchOption.AllDirectories).Where(fi => fi.Length > 104857600);
            //    var filesMiddle = direct.EnumerateFiles(".", SearchOption.AllDirectories).Where(fi => fi.Length > 10485760 && fi.Length < 52428800);
            //    li.Add(new FileInfoData { SizeSmall = filesSmall.Count(), SizeBig = filesBig.Count(), SizeMiddle = filesMiddle.Count() });
            //}
            //catch (System.Exception excpt)
            //{
            //    li.Add(new FileInfoData { Error = "dfdf" });
            //}
           //подсчет файлов в каталоге


            //рабочий код
            //var filesTop = Enumerable.Empty<FileInfo>();
            //var filesAll = Enumerable.Empty<FileInfo>();
            //try
            //{
            //    var root = new DirectoryInfo(sDir);
            //    filesAll = root.EnumerateFiles(".", SearchOption.AllDirectories);
            //    filesTop = root.EnumerateFiles(".", SearchOption.TopDirectoryOnly);
            //    var filesSmall = (filesTop.Where(fi => fi.Length < 10485760)).Count() + (filesAll.Where(fi => fi.Length < 10485760)).Count();
            //    var filesBig = (filesTop.Where(fi => fi.Length > 104857600)).Count() + (filesAll.Where(fi => fi.Length > 104857600)).Count();
            //    var filesMiddle = (filesTop.Where(fi => fi.Length > 10485760 && fi.Length < 52428800)).Count() + (filesAll.Where(fi => fi.Length > 10485760 && fi.Length < 52428800)).Count();
            //    //var filesSmall2 =
            //    //var filesBig2 = ;
            //    //var filesMiddle2 = ;
            //    li.Add(new FileInfoData { SizeSmall = filesSmall, SizeBig = filesBig, SizeMiddle = filesMiddle });
            //}
            //catch (UnauthorizedAccessException) { }

          

            

            //var direct = new DirectoryInfo(sDir);
            //var files = direct.EnumerateFiles(".").Where(fi => fi.Length > 100000);
            //li.Add(new FileInfoData { SizeSmall = files.Count() });

            
            //var files = direc.EnumerateFiles("*.").Where(fi => fi.Length > 100000);
            //li.Add(new FileInfoData { SizeSmall = files.Count() });



           
            
            //DirectoryInfo[] directories = direc.GetFiles();
            //foreach (DirectoryInfo subDirectory in directories)
            //{

            //    FileInfo[] filesSubDir = subDirectory.GetFiles("*.*");
            //    foreach (FileInfo fi in filesSubDir)
            //    {

            //        li.Add(new FileInfoData { FileName = fi.Name });
            //    }

            //}
            return li;
        }

       

        //public static int GetAllF(string sDir)
        //{
        //    int a = 0;
        //    foreach (string dir in Directory.GetDirectories(sDir))
        //    {
        //        try
        //        {
        //            foreach (string file in Directory.GetFiles(dir, ".", SearchOption.AllDirectories))
        //            {
                        
        //              a = file.Count();
                       
        //            }
        //            GetAllF(dir);
        //        }
        //        catch (UnauthorizedAccessException)
        //        {

        //        }
                
        //    }
        //    return a;
        //}
        
        
       
        
    }
}