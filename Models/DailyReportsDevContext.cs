using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace vsc_webapi_dr.Models
{
    public partial class DailyReportsDevContext : DbContext
    {
        public virtual DbSet<BackupFile> BackupFile { get; set; }
        public virtual DbSet<Db> Db { get; set; }
        public virtual DbSet<Dbbackup> Dbbackup { get; set; }
        public virtual DbSet<Dbfile> Dbfile { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<SqlServer> SqlServer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer(@"Server=SK-SQLGENDB-01;Database=DailyReportsDev;Trusted_Connection=True;");
            //}
        }
        public DailyReportsDevContext(DbContextOptions<DailyReportsDevContext> options)
            : base(options)
            { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackupFile>(entity =>
            {
                entity.ToTable("BackupFile", "doc");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Directory)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LastWriteDate).HasColumnType("datetime");

                entity.Property(e => e.SizeMb).HasColumnName("SizeMB");
            });

            modelBuilder.Entity<Db>(entity =>
            {
                entity.ToTable("DB", "doc");

                entity.Property(e => e.DatabaseId).HasColumnName("database_id");

                entity.Property(e => e.Dbcollation)
                    .HasColumnName("DBCollation")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Dbcompatibility).HasColumnName("DBCompatibility");

                entity.Property(e => e.Dbcreation)
                    .HasColumnName("DBCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dbname)
                    .IsRequired()
                    .HasColumnName("DBName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Dbrecovery)
                    .HasColumnName("DBRecovery")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dbstate)
                    .HasColumnName("DBState")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DbuserAccess)
                    .HasColumnName("DBUserAccess")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsUserDb).HasColumnName("IsUserDB");

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.Db)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK__DB__InstanceId__0E391C95");
            });

            modelBuilder.Entity<Dbbackup>(entity =>
            {
                entity.ToTable("DBBackup", "doc");

                entity.Property(e => e.BackupEnd).HasColumnType("datetime");

                entity.Property(e => e.BackupStart).HasColumnType("datetime");

                entity.Property(e => e.BackupType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BackupUser)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Dbname)
                    .IsRequired()
                    .HasColumnName("DBName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLsn)
                    .HasColumnName("first_lsn")
                    .HasColumnType("numeric(25, 0)");

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.LastLsn)
                    .HasColumnName("last_lsn")
                    .HasColumnType("numeric(25, 0)");

                entity.Property(e => e.PhysicalFile)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveryModel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SizeMb)
                    .HasColumnName("SizeMB")
                    .HasColumnType("numeric(30, 2)");

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.Dbbackup)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK__DBBackup__Instan__18B6AB08");
            });

            modelBuilder.Entity<Dbfile>(entity =>
            {
                entity.ToTable("DBFile", "doc");

                entity.Property(e => e.Dbfile1)
                    .IsRequired()
                    .HasColumnName("DBFile")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Dbname)
                    .IsRequired()
                    .HasColumnName("DBName")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Growth)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.MaxSizeMb)
                    .HasColumnName("MaxSizeMB")
                    .HasColumnType("numeric(20, 2)");

                entity.Property(e => e.PhysicalDisk)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.SizeMb)
                    .HasColumnName("SizeMB")
                    .HasColumnType("numeric(20, 2)");

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.Dbfile)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK__DBFile__Instance__1209AD79");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device", "doc");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Antivirus).HasMaxLength(128);

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cpu)
                    .HasColumnName("CPU")
                    .HasMaxLength(128);

                entity.Property(e => e.DataImportUtc)
                    .HasColumnName("DataImportUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Domain).HasMaxLength(128);

                entity.Property(e => e.EngineVersion).HasMaxLength(20);

                entity.Property(e => e.InAd).HasColumnName("InAD");

                entity.Property(e => e.InSccm).HasColumnName("InSCCM");

                entity.Property(e => e.InVcenter).HasColumnName("InVCenter");

                entity.Property(e => e.LastActiveTime).HasColumnType("datetime");

                entity.Property(e => e.LastHwdScan).HasColumnType("datetime");

                entity.Property(e => e.LastLogon).HasColumnType("datetime");

                entity.Property(e => e.LastLogonDate).HasColumnType("datetime");

                entity.Property(e => e.LastScanDate).HasColumnType("datetime");

                entity.Property(e => e.LastSfwScan).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(128);

                entity.Property(e => e.Model).HasMaxLength(128);

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .HasMaxLength(128);

                entity.Property(e => e.PrimaryUser)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Savversion)
                    .HasColumnName("SAVVersion")
                    .HasMaxLength(20);

                entity.Property(e => e.SiteName).HasMaxLength(128);

                entity.Property(e => e.VirusDataVersion).HasMaxLength(20);
            });

            modelBuilder.Entity<SqlServer>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.ToTable("SqlServer", "doc");

                entity.Property(e => e.InstanceId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BackupPath).HasMaxLength(128);

                entity.Property(e => e.Collation).HasMaxLength(128);

                entity.Property(e => e.DataImportUtc)
                    .HasColumnName("DataImportUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataPath).HasMaxLength(128);

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdminDb).HasColumnName("IsAdminDB");

                entity.Property(e => e.IsAdtq).HasColumnName("IsADTQ");

                entity.Property(e => e.IsBo).HasColumnName("IsBO");

                entity.Property(e => e.IsOh).HasColumnName("IsOH");

                entity.Property(e => e.Level)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LogPath).HasMaxLength(128);

                entity.Property(e => e.Product)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ServerState)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceAccount)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.SqlServer)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK__SqlServer__Devic__0D44F85C");
            });
        }

        
    }
}
