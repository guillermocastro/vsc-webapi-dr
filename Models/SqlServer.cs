using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class SqlServer
    {
        public SqlServer()
        {
            Db = new HashSet<Db>();
            Dbbackup = new HashSet<Dbbackup>();
            Dbfile = new HashSet<Dbfile>();
        }

        public string InstanceId { get; set; }
        public string DeviceId { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string Level { get; set; }
        public string UpdateLevel { get; set; }
        public string ServiceAccount { get; set; }
        public string DataPath { get; set; }
        public string LogPath { get; set; }
        public string BackupPath { get; set; }
        public string ServerState { get; set; }
        public bool? IsAdminDb { get; set; }
        public bool? IsOh { get; set; }
        public bool? IsBo { get; set; }
        public bool? IsAdtq { get; set; }
        public bool? IsCmdShell { get; set; }
        public bool? IsMail { get; set; }
        public bool? IsOperator { get; set; }
        public string Collation { get; set; }
        public DateTime? DataImportUtc { get; set; }

        public Device Device { get; set; }
        public ICollection<Db> Db { get; set; }
        public ICollection<Dbbackup> Dbbackup { get; set; }
        public ICollection<Dbfile> Dbfile { get; set; }
    }
}
