using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Contract.Core
{
 public interface ISqlFactory
    {
        /// <summary>
        /// Creates a new, unopened <see cref="SqlConnection"/> object for the provided connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The created <see cref="SqlConnection"/> object.</returns>
        SqlConnection CreateConnection(
            string connectionString);

        /// <summary>
        /// Creates a new <see cref="SqlCommand"/> object based on the specified arguments.
        /// </summary>
        /// <param name="query">The query to be executed.</param>
        /// <param name="connection">The SQL connection to be used.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <returns>The created <see cref="SqlCommand"/> object.</returns>
        SqlCommand CreateCommand(
            string query,
            SqlConnection connection,
            CommandType commandType,
            IEnumerable<IDbDataParameter> parameters);
    }
}
