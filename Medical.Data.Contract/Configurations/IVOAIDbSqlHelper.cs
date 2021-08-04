using IVOAI.Data.Contract.Configurations;
using IVOAI.Data.Contract.Core;
using IVOAI.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVOAI.Data.Configurations
{
    public class IVOAIDbSqlHelper: SqlHelper, IIVOAIDbSqlHelper 
    {
        public IVOAIDbSqlHelper(ISqlServerDataAccessConfiguration configuration, ISqlFactory sqlFactory)
              : base(ToSqlHelperConfiguration(configuration), sqlFactory)
        {
        }

        private static ISqlHelperConfiguration ToSqlHelperConfiguration(ISqlServerDataAccessConfiguration configuration)
        {
            return new SqlHelperConfiguration
            {
                ConnectionString = configuration.ConnectionStrings.IVOAIDb
            };
        }

    }
}
