using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class Dbfile
    {
        public int Id { get; set; }
        public string InstanceId { get; set; }
        public string Dbname { get; set; }
        public string Dbfile1 { get; set; }
        public string FileType { get; set; }
        public string PhysicalDisk { get; set; }
        public decimal? SizeMb { get; set; }
        public decimal? MaxSizeMb { get; set; }
        public string Growth { get; set; }

        public SqlServer Instance { get; set; }
    }
}
