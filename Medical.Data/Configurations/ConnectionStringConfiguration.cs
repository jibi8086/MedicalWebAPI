using Medical.Data.Contract.Configurations;
using Medical.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Configurations
{
    public class ConnectionStringConfiguration : IConnectionStringConfiguration
    {
        private readonly ConnectionStringSettings _connectionStringSettings;


        public ConnectionStringConfiguration(IOptions<ConnectionStringSettings> connectionStringSettings)
        {
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException(nameof(connectionStringSettings));
            }



            _connectionStringSettings = connectionStringSettings.Value;
        }

        public string MedicalDB => _connectionStringSettings.DefaultConnection;

    }
}
