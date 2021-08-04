using Medical.Data.Contract.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Core
{
    public class SqlHelperConfiguration : ISqlHelperConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
