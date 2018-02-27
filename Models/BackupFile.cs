using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class BackupFile
    {
        public int Id { get; set; }
        public string Directory { get; set; }
        public string FileName { get; set; }
        public long? SizeMb { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastWriteDate { get; set; }
        public string Extension { get; set; }
    }
}
