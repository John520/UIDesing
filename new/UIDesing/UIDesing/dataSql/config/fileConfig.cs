using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql.config
{
    public class fileConfig : EntityTypeConfiguration<File_data>
    {
        public fileConfig()
        {
            ToTable("files");
            HasKey(t => t.FileId);
            Property(t => t.FileName).HasColumnName("FileName").HasMaxLength(20);
            HasMany(t => t.CateDatas).WithRequired(t => t.File_data).WillCascadeOnDelete();
            HasMany(t => t.MarkDatas).WithRequired(t=>t.File_data).WillCascadeOnDelete();
            HasMany(t => t.FeedDatas).WithRequired(t => t.File_data).WillCascadeOnDelete();
            HasMany(t => t.PCBDatas).WithRequired(t => t.File_data).WillCascadeOnDelete();

        }
    }
}
