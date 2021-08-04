using IVOAI.Data.Contract.Configurations;
using IVOAI.Infrastruture.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVOAI.Data.Configurations
{
    public class SqlServerDataAccessConfiguration: ISqlServerDataAccessConfiguration
    {
        private readonly IConnectionStringConfiguration _connectionStrings;

        public SqlServerDataAccessConfiguration(IOptions<ConnectionStringSettings> connectionStringSettings)
        {
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException(nameof(connectionStringSettings));
            }

            _connectionStrings = new ConnectionStringConfiguration(connectionStringSettings);
        }

        public IConnectionStringConfiguration ConnectionStrings
        {
            get
            {
                return _connectionStrings;
            }
        }
    }
}
