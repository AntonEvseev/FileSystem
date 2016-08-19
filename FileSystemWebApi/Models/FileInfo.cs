using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileSystemWebApi.Models
{
    public class FileInfoData
    {
        public string DirectoryName { get; set; }
        public int SizeSmall { get; set; }
        public int SizeBig { get; set; }
        public int SizeMiddle { get; set; }
        public string Puth { get; set; }
        public string FileName { get; set; }
        public string Error { get; set; }
        public string BackStap { get; set; }
    }
}