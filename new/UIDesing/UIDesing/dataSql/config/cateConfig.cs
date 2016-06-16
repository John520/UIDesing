using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql.config
{
    public class cateConfig : EntityTypeConfiguration<Cate_data>
    {
        public cateConfig() {

            HasMany(t => t.PlugDatas).WithRequired(t => t.Cate_data).WillCascadeOnDelete();
        
        
        }
    }
}
