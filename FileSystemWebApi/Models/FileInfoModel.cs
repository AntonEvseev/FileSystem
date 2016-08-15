using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace FileSystemWebApi.Models
{
    public class FileInfoModel
    {
        public List<FileInfo> findAll()
        {
            List<FileInfo> li =new List<FileInfo>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Fixed)
                {
                    li.Add(new FileInfo { Name = d.Name});
                }
            }

            //string sDir = @"D:\";
            //string[] ReultSearch = Directory.GetDirectories(sDir);
            //foreach (string f in ReultSearch)
            //{
            //    li.Add(new FileInfo { Name = f });
            //}
            //li.Add(new FileInfo { SizeSmall = ReultSearch.Length, Puth = sDir });
              

            //return li;}
            //public List<FileInfo> DirSearch(string sDir)
            //{
            //    List<FileInfo> li =new List<FileInfo>();
            //    try
            //    {
            //        foreach (string d in Directory.GetDirectories(sDir))
            //        {
            //            foreach (string f in Directory.GetFiles(d, "."))
            //            {
            //                li.Add(new FileInfo { Name = f, SizeSmall = f.Length }); 
            //            }
            //            DirSearch(d);
            //        }
            //    }
            //    catch (System.Exception excpt)
            //    {
            //        Console.WriteLine(excpt.Message);
            //    }
            //    return li;
            //}

            //try
            //{
            //    //System.IO.DirectoryInfo number = new System.IO.DirectoryInfo(@"D:\");
            //    //string sourceDirectory = @"D:\Фото бабушка";
            //    var files = Directory.EnumerateFiles(@"D:\Фото бабушка", "*.", SearchOption.AllDirectories);
                
            //    //int count = number.GetFiles(".", SearchOption.AllDirectories).Length;
            //    string[] dirs = Directory.GetFiles(@"D:\Фото бабушка", "*.", SearchOption.AllDirectories);
            //li.Add(new FileInfo {Name = "qwe", SizeSmall = files.Count()  }); 
            //}
            //catch { }

            
            //foreach (DriveInfo d in allDrives)
            //{
            //    if(d.DriveType == DriveType.Fixed){

            //        System.IO.DirectoryInfo number = new System.IO.DirectoryInfo(@d.Name);
            //        int count = number.GetFiles().Length;
            //        string[] dirs = Directory.GetFiles(@"c:\", ".", SearchOption.AllDirectories);
            //        string[] dirs = Directory.GetFiles(@"D:\", "*.", SearchOption.AllDirectories);
            //    li.Add(new FileInfo { Name = d.Name, SizeSmall = dirs.Length, Puth = d.Name});
            //    }
            //}
            
            //string[] dirs = Directory.GetFiles(@"d:\Фото бабушка");
            //foreach (string dir in dirs)
            //{
                
            //        li.Add(new FileInfo { SizeSmall = dirs.Length });
                
            //}
            //foreach (DriveInfo d in allDrives)
            //{
            //    try
            //    {
            //       li.Add( new FileInfo {SizeSmall = (d.Name, "*.*").Count});
            //    }
            //    catch (Exception err) { e.Result = err.Message; }
            //}
            
            
            
            return li;
        }


        public List<FileInfo> findAll(string id)
        {
            List<FileInfo> li = new List<FileInfo>();
            string sDir = id;

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(sDir));
            foreach (var dir in dirs)
                    {
                        li.Add(new FileInfo { Puth = id, Name = dir.Substring(dir.LastIndexOf("\\") + 1) });
                    }
            return li;
        }
    }
}