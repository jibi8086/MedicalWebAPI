using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IVOAI.Data.Contract.Core;

namespace IVOAI.Data.Core
{
    public class SqlHelper : ISqlHelper
    {
        #region Fields

        private readonly ISqlHelperConfiguration _configuration;

        private readonly ISqlFactory _sqlFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlHelper" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="sqlFactory">The SQL factory.</param>
        /// <exception cref="ArgumentNullException">connectionString</exception>
        protected SqlHelper(
            ISqlHelperConfiguration configuration,
            ISqlFactory sqlFactory)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (sqlFactory == null)
            {
                throw new ArgumentNullException(nameof(sqlFactory));
            }

            _configuration = configuration;
            _sqlFactory = sqlFactory;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="SqlHelper"/> configuration.
        /// </summary>
        /// <value>
        /// The <see cref="SqlHelper"/> configuration.
        /// </value>
        public ISqlHelperConfiguration Configuration => _configuration;

        #endregion

        #region Public Methods

        #region GetScalarAsync

        /// <inheritdoc />
        public Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction)
            => GetScalarAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            CancellationToken cancellationToken)
            => GetScalarAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            => GetScalarAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
        {
            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                if (mapperFunction == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                object value;

                using (var connection = _sqlFactory.CreateConnection(_configuration.ConnectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                        value = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                return mapperFunction(value);
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetFirstAsync

        /// <inheritdoc />
        public Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class
            => GetFirstAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class
            => GetFirstAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class
            => GetFirstAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                if (mapperFunction == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                var result = await GetFirstOrDefaultAsync(
                    storedProcedureName,
                    mapperFunction,
                    storedProcedureArguments,
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    throw new InvalidOperationException("The result set is empty, but at least one result was expected.");
                }

                return result;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetFirstOrDefaultAsync

        /// <inheritdoc />
        public Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class
            => GetFirstOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class
            => GetFirstOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class
            => GetFirstOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                var mapperFunctionCopy = mapperFunction;

                if (mapperFunctionCopy == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                T result;

                using (var dataReader = await GetDataReaderAsync(
                    storedProcedureName,
                    storedProcedureArguments,
                    cancellationToken)
                    .ConfigureAwait(false))
                {
                    if (!await dataReader.ReadAsync(cancellationToken).ConfigureAwait(false))
                    {
                        return null;
                    }

                    result = mapperFunctionCopy(dataReader);
                }

                return result;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetSingleAsync

        /// <inheritdoc />
        public Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class
            => GetSingleAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class
            => GetSingleAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class
            => GetSingleAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                if (mapperFunction == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                var result = await GetSingleOrDefaultAsync(
                    storedProcedureName,
                    mapperFunction,
                    storedProcedureArguments,
                    cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    throw new InvalidOperationException("The result set is empty, but a single was expected.");
                }

                return result;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetSingleOrDefaultAsync

        /// <inheritdoc />
        public Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class
            => GetSingleOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class
            => GetSingleOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class
            => GetSingleOrDefaultAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                var mapperFunctionCopy = mapperFunction;

                if (mapperFunctionCopy == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                T result;

                using (var dataReader = await GetDataReaderAsync(
                    storedProcedureName,
                    storedProcedureArguments,
                    cancellationToken)
                    .ConfigureAwait(false))
                {
                    if (!await dataReader.ReadAsync(cancellationToken).ConfigureAwait(false))
                    {
                        return null;
                    }

                    result = mapperFunctionCopy(dataReader);

                    if (await dataReader.ReadAsync(cancellationToken).ConfigureAwait(false))
                    {
                        throw new InvalidOperationException("The result set contains multiple records, but only a single was expected.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetAllAsync

        /// <inheritdoc />
        public Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class
            => GetAllAsync(
                storedProcedureName,
                mapperFunction,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class
            => GetAllAsync(
                storedProcedureName,
                mapperFunction,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class
            => GetAllAsync(
                storedProcedureName,
                mapperFunction,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                var mapperFunctionCopy = mapperFunction;

                if (mapperFunctionCopy == null)
                {
                    throw new ArgumentNullException(nameof(mapperFunction));
                }

                var results = new List<T>();

                using (var dataReader = await GetDataReaderAsync(
                    storedProcedureName,
                    storedProcedureArguments,
                    cancellationToken)
                    .ConfigureAwait(false))
                {
                    while (await dataReader.ReadAsync(cancellationToken).ConfigureAwait(false))
                    {
                        results.Add(mapperFunctionCopy(dataReader));
                    }
                }

                return results;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetDataReaderAsync

        /// <inheritdoc />
        public Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName)
            => GetDataReaderAsync(
                storedProcedureName,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            CancellationToken cancellationToken)
            => GetDataReaderAsync(
                storedProcedureName,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments)
            => GetDataReaderAsync(
                storedProcedureName,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
        {
            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                var connection = _sqlFactory.CreateConnection(_configuration.ConnectionString);

                using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                {
                    await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

                    return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region GetDataTableAsync

        /// <inheritdoc />
        public Task<DataTable> GetDataTableAsync(
            string storedProcedureName)
            => GetDataTableAsync(
                storedProcedureName,
                CancellationToken.None);

        /// <inheritdoc />
        public Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            CancellationToken cancellationToken)
            => GetDataTableAsync(
                storedProcedureName,
                new IDbDataParameter[0],
                cancellationToken);

        /// <inheritdoc />
        public Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments)
            => GetDataTableAsync(
                storedProcedureName,
                storedProcedureArguments,
                CancellationToken.None);

        /// <inheritdoc />
        public async Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
        {
            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                var dataTable = new DataTable();

                using (var connection = _sqlFactory.CreateConnection(_configuration.ConnectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                            adapter.Fill(dataTable);
                        }
                    }
                }

                return dataTable;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        #endregion

        #region ExecuteNonQueryAsync

        /// <inheritdoc />
        public Task<int> ExecuteNonQueryAsync(
            string storedProcedureName)
            => ExecuteNonQueryAsync(
                storedProcedureName,
                CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
    string connectionString,
    string storedProcedureName)
    => ExecuteNonQueryAsync(
        connectionString,
        storedProcedureName,
        CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
    string storedProcedureName,
    int commandTimeout)
    => ExecuteNonQueryAsync(
        storedProcedureName,
        commandTimeout,
        CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
string connectionString,
string storedProcedureName,
int commandTimeout)
=> ExecuteNonQueryAsync(
connectionString,
storedProcedureName,
commandTimeout,
CancellationToken.None);

        /// <inheritdoc />
        public Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            CancellationToken cancellationToken)
            => ExecuteNonQueryAsync(
                storedProcedureName,
                new IDbDataParameter[0],
                cancellationToken);

        public Task<int> ExecuteNonQueryAsync(
    string connectionString,
    string storedProcedureName,
    CancellationToken cancellationToken)
    => ExecuteNonQueryAsync(
        connectionString,
        storedProcedureName,
        new IDbDataParameter[0],
        cancellationToken);

        public Task<int> ExecuteNonQueryAsync(
    string storedProcedureName,
    int commandTimeout,
    CancellationToken cancellationToken)
    => ExecuteNonQueryAsync(
        storedProcedureName,
        new IDbDataParameter[0],
        commandTimeout,
        cancellationToken);

        public Task<int> ExecuteNonQueryAsync(
 string connectionString,
string storedProcedureName,
int commandTimeout,
CancellationToken cancellationToken)
=> ExecuteNonQueryAsync(
connectionString,
storedProcedureName,
new IDbDataParameter[0],
commandTimeout,
cancellationToken);

        /// <inheritdoc />
        public Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments)
            => ExecuteNonQueryAsync(
                storedProcedureName,
                storedProcedureArguments,
                CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
    string connectionString,
    string storedProcedureName,
    IDbDataParameter[] storedProcedureArguments)
    => ExecuteNonQueryAsync(
        connectionString,
        storedProcedureName,
        storedProcedureArguments,
        CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            int commandTimeout)
            => ExecuteNonQueryAsync(
                storedProcedureName,
                storedProcedureArguments,
                commandTimeout,
                CancellationToken.None);

        public Task<int> ExecuteNonQueryAsync(
    string connectionString,
    string storedProcedureName,
    IDbDataParameter[] storedProcedureArguments,
    int commandTimeout)
    => ExecuteNonQueryAsync(
        connectionString,
        storedProcedureName,
        storedProcedureArguments,
        commandTimeout,
        CancellationToken.None);

        /// <inheritdoc />
        public async Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            int commandTimeout,
            CancellationToken cancellationToken)
        {
            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                int returnValue;

                using (var connection = _sqlFactory.CreateConnection(_configuration.ConnectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        command.CommandTimeout = commandTimeout;

                        await connection.OpenAsync().ConfigureAwait(false);
                        returnValue = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                return returnValue;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        public async Task<int> ExecuteNonQueryAsync(
     string connectionString,
    string storedProcedureName,
    IDbDataParameter[] storedProcedureArguments,
    int commandTimeout,
    CancellationToken cancellationToken)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                int returnValue;

                using (var connection = _sqlFactory.CreateConnection(connectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        command.CommandTimeout = commandTimeout;

                        await connection.OpenAsync().ConfigureAwait(false);
                        returnValue = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                return returnValue;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        public async Task<int> ExecuteNonQueryAsync(
    string storedProcedureName,
    IDbDataParameter[] storedProcedureArguments,
    CancellationToken cancellationToken)
        {
            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                int returnValue;

                using (var connection = _sqlFactory.CreateConnection(_configuration.ConnectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        returnValue = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                return returnValue;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        public async Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            try
            {
                ValidateArguments(storedProcedureName, storedProcedureArguments);

                int returnValue;

                using (var connection = _sqlFactory.CreateConnection(connectionString))
                {
                    using (var command = _sqlFactory.CreateCommand(storedProcedureName, connection, CommandType.StoredProcedure, storedProcedureArguments))
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        returnValue = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    }
                }

                return returnValue;
            }
            catch (Exception exception)
            {
                AddMetadataToException(
                    exception,
                    storedProcedureName,
                    storedProcedureArguments);
                throw;
            }
        }

        private static void ValidateArguments(string storedProcedureName, IDbDataParameter[] storedProcedureArguments)
        {
            if (storedProcedureName == null)
            {
                throw new ArgumentNullException(nameof(storedProcedureName));
            }

            if (storedProcedureArguments == null)
            {
                throw new ArgumentNullException(nameof(storedProcedureArguments));
            }

            if (storedProcedureArguments.Any(arg => arg == null))
            {
                throw new ArgumentException("Stored procedure arguments collection cannot contain null values.", nameof(storedProcedureArguments));
            }
        }

        #endregion

        #endregion

        #region Private Methods

        private static void AddMetadataToException(
            Exception exception,
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments)
        {
            exception.Data["StoredProcedureName"] = storedProcedureName;

            if (storedProcedureArguments != null)
            {
                foreach (var argument in storedProcedureArguments)
                {
                    if (argument != null && argument.ParameterName != null)
                    {
                        exception.Data["@" + argument.ParameterName] = argument.Value != null
                            ? "<value>" // Non-null values are excluded for security reasons
                            : null;
                    }
                }
            }
        }

        #endregion
    }
}
