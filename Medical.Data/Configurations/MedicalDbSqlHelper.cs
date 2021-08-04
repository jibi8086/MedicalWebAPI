
using Medical.Data.Contract.Configurations;
using Medical.Data.Contract.Core;
using Medical.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Configurations
{
    public class MedicalDbSqlHelper : SqlHelper, IMedicalDbSqlHelper
    {
        public MedicalDbSqlHelper(ISqlServerDataAccessConfiguration configuration, ISqlFactory sqlFactory)
           : base(ToSqlHelperConfiguration(configuration), sqlFactory)
        {
        }

        private static ISqlHelperConfiguration ToSqlHelperConfiguration(ISqlServerDataAccessConfiguration configuration)
        {
            return new SqlHelperConfiguration
            {
                ConnectionString = configuration.ConnectionStrings.MedicalDB
            };
        }
    }
}
