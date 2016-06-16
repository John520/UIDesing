using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing.dataSql.config
{
    public class feedConfig: EntityTypeConfiguration<Feed_data>
    {
        public feedConfig()
        {
          //  HasMany(t => t.).WithOptional(t => t.Cate_data);
        
        
        
        }
        
    }
}
