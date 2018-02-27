using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class Dbbackup
    {
        public int Id { get; set; }
        public string InstanceId { get; set; }
        public int BackupId { get; set; }
        public string Dbname { get; set; }
        public string BackupUser { get; set; }
        public string PhysicalFile { get; set; }
        public decimal? SizeMb { get; set; }
        public int? DurationSec { get; set; }
        public DateTime? BackupStart { get; set; }
        public DateTime? BackupEnd { get; set; }
        public decimal? FirstLsn { get; set; }
        public decimal? LastLsn { get; set; }
        public string BackupType { get; set; }
        public string RecoveryModel { get; set; }

        public SqlServer Instance { get; set; }
    }
}
