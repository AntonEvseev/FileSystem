using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSystemWebApi.Controllers;
using FileSystemWebApi.Models;
//using System.IO;

namespace FileSystemWebApi.Controllers
{
    public class FileInfoesController : ApiController
    {
        // GET: api/FileInfoes
        public IEnumerable<FileInfo> Get()
        {
            FileInfoModel fim = new FileInfoModel();
            return fim.findAll().AsEnumerable();
        }

        // GET: api/FileInfoes/5
        public IEnumerable<FileInfo> Get(string id)
        {
            List<FileInfo> li = new List<FileInfo>();
            FileInfoModel fim = new FileInfoModel();
            return fim.findAll(id).AsEnumerable();






    //        string[] fullfilesPath =
    //Directory.GetFiles(id, "*.*",
    //     SearchOption.AllDirectories); 
            //string sDir = @"D:\";
            //string[] ReultSearch = Directory.GetDirectories(sDir);
            //foreach (string f in ReultSearch)
            //{
            //    li.Add(new FileInfo { Name = f });
            //}
            //li.Add(new FileInfo { SizeSmall = ReultSearch.Length, Puth = sDir });
           
            //FileInfoModel fim = new FileInfoModel();
            //return fim.findAll().AsEnumerable();
            
        }

        
    }
}
