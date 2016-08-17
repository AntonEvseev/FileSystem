using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSystemWebApi.Controllers;
using FileSystemWebApi.Models;


namespace FileSystemWebApi.Controllers
{
    public class FileInfoDataesController : ApiController
    {
        // GET: api/FileInfoes
        public IEnumerable<FileInfoData> Get()
        {
            FileInfoDataModel fidm = new FileInfoDataModel();
            return fidm.findAll().AsEnumerable();
        }

        // GET: api/FileInfoes/5
        public IEnumerable<FileInfoData> Get(string id)
        {
            List<FileInfoData> li = new List<FileInfoData>();
            FileInfoDataModel fidm = new FileInfoDataModel();
            return fidm.findAll(id).AsEnumerable();






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
        //public IEnumerable<FileInfoData> Post(string id)
        //{
        //    FileInfoDataModel fidm = new FileInfoDataModel();
        //    return fidm.findAllP(id).AsEnumerable();
        //}
        
    }
}
