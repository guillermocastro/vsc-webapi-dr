using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class Device
    {
        public Device()
        {
            SqlServer = new HashSet<SqlServer>();
        }

        public string DeviceId { get; set; }
        public string Manufacturer { get; set; }
        public string Os { get; set; }
        public string Domain { get; set; }
        public string SiteName { get; set; }
        public DateTime? LastLogonDate { get; set; }
        public string Antivirus { get; set; }
        public string Savversion { get; set; }
        public string EngineVersion { get; set; }
        public string VirusDataVersion { get; set; }
        public bool? InSccm { get; set; }
        public bool? InSophos { get; set; }
        public bool? InVcenter { get; set; }
        public bool? InAd { get; set; }
        public bool? InAudit { get; set; }
        public bool? IsVirtual { get; set; }
        public DateTime? LastScanDate { get; set; }
        public string Cpu { get; set; }
        public string Model { get; set; }
        public int? NumOfProcs { get; set; }
        public string Category { get; set; }
        public DateTime? DataImportUtc { get; set; }
        public DateTime? LastLogon { get; set; }
        public DateTime? LastHwdScan { get; set; }
        public DateTime? LastSfwScan { get; set; }
        public DateTime? LastActiveTime { get; set; }
        public string PrimaryUser { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Comments { get; set; }

        public ICollection<SqlServer> SqlServer { get; set; }
    }
}
