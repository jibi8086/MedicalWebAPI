using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IVOAI.Data.Contract.Core;

namespace IVOAI.Data.Core
{
    public class SqlFactory : ISqlFactory
    {
        public SqlConnection CreateConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return new SqlConnection(connectionString);
        }

        public SqlCommand CreateCommand(
            string query,
            SqlConnection connection,
            CommandType commandType,
            IEnumerable<IDbDataParameter> parameters)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var command = new SqlCommand(query, connection)
            {
                CommandType = commandType
            };

            foreach (IDbDataParameter parameter in parameters)
            {
                if (parameter == null)
                {
                    throw new ArgumentException("parameters collection cannot contain null values.", nameof(parameters));
                }

                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }

                command.Parameters.Add(parameter);
            }

            return command;
        }
    }
}
