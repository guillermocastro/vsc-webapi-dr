using System;
using System.Collections.Generic;

namespace vsc_webapi_dr.Models
{
    public partial class Db
    {
        public int Id { get; set; }
        public string InstanceId { get; set; }
        public string Dbname { get; set; }
        public bool? IsUserDb { get; set; }
        public string Dbstate { get; set; }
        public string DbuserAccess { get; set; }
        public string Dbrecovery { get; set; }
        public string Dbcollation { get; set; }
        public int? Dbcompatibility { get; set; }
        public DateTime? Dbcreation { get; set; }
        public int? DatabaseId { get; set; }

        public SqlServer Instance { get; set; }
    }
}
