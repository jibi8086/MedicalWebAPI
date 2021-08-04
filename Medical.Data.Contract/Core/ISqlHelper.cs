using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medical.Data.Contract.Core
{
 public interface ISqlHelper
    {

        #region GetScalarAsync

        /// <summary>
        /// Executes a query and returns the first column of the first row in the result set,
        /// converted to a correct type using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>The first column of the first row in the result set converted to type <typeparamref name="T"/>.</returns>
        Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction);

        /// <summary>
        /// Executes a query and returns the first column of the first row in the result set,
        /// converted to a correct type using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The first column of the first row in the result set converted to type <typeparamref name="T"/>.</returns>
        Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query and returns the first column of the first row in the result set,
        /// converted to a correct type using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>The first column of the first row in the result set converted to type <typeparamref name="T"/>.</returns>
        Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments);

        /// <summary>
        /// Executes a query and returns the first column of the first row in the result set,
        /// converted to a correct type using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The first column of the first row in the result set converted to type <typeparamref name="T"/>.</returns>
        Task<T> GetScalarAsync<T>(
            string storedProcedureName,
            Func<object, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken);

        #endregion

        #region GetSingleAsync

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty or contains more than one record.</exception>
        Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty or contains more than one record.</exception>
        Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty or contains more than one record.</exception>
        Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty or contains more than one record.</exception>
        Task<T> GetSingleAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class;

        #endregion

        #region GetSingleOrDefaultAsync

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        /// <exception cref="InvalidOperationException">The result set contains more than one record.</exception>
        Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        /// <exception cref="InvalidOperationException">The result set contains more than one record.</exception>
        Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        /// <exception cref="InvalidOperationException">The result set contains more than one record.</exception>
        Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class;

        /// <summary>
        /// Executes a query and returns a single result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        /// <exception cref="InvalidOperationException">The result set contains more than one record.</exception>
        Task<T> GetSingleOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class;

        #endregion

        #region GetFirstAsync

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty.</exception>
        Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty.</exception>
        Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty.</exception>
        Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">The result set is empty.</exception>
        Task<T> GetFirstAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class;

        #endregion

        #region GetFirstOrDefaultAsync

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class;

        /// <summary>
        /// Executes a query and returns the first result already mapped to a business object
        /// using the <paramref name="mapperFunction"/> or null.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single result mapped to an object of type <typeparamref name="T"/> or null.</returns>
        Task<T> GetFirstOrDefaultAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class;

        #endregion

        #region GetAllAsync

        /// <summary>
        /// Executes a query and returns the results already mapped to business objects
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <returns>A list of results mapped to objects of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using <see cref="GetDataReaderAsync(string)"/> instead.
        /// </para>
        /// </remarks>
        Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction)
            where T : class;

        /// <summary>
        /// Executes a query and returns the results already mapped to business objects
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of results mapped to objects of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, CancellationToken)"/> instead.
        /// </para>
        /// </remarks>
        Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            CancellationToken cancellationToken)
            where T : class;

        /// <summary>
        /// Executes a query and returns the results already mapped to business objects
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A list of results mapped to objects of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, IDbDataParameter[])"/> instead.
        /// </para>
        /// </remarks>
        Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments)
            where T : class;

        /// <summary>
        /// Executes a query and returns the results already mapped to business objects
        /// using the <paramref name="mapperFunction"/>.
        /// </summary>
        /// <typeparam name="T">The result type to be returned.</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="mapperFunction">The mapper function.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of results mapped to objects of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, IDbDataParameter[], CancellationToken)"/> instead.
        /// </para>
        /// </remarks>
        Task<IList<T>> GetAllAsync<T>(
            string storedProcedureName,
            Func<IDataRecord, T> mapperFunction,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken)
            where T : class;

        #endregion

        #region GetDataReaderAsync

        /// <summary>
        /// Executes a query and returns the results as a <see cref="SqlDataReader"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns>A <see cref="SqlDataReader"/> that allows the caller to iterate over the query results.</returns>
        Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="SqlDataReader"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="SqlDataReader"/> that allows the caller to iterate over the query results.</returns>
        Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="SqlDataReader"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A <see cref="SqlDataReader"/> that allows the caller to iterate over the query results.</returns>
        Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="SqlDataReader"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="SqlDataReader"/> that allows the caller to iterate over the query results.</returns>
        Task<SqlDataReader> GetDataReaderAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken);

        #endregion

        #region GetDataTableAsync

        /// <summary>
        /// Executes a query and returns the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string)"/> instead.
        /// </para>
        /// </remarks>
        Task<DataTable> GetDataTableAsync(
            string storedProcedureName);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, CancellationToken)"/> instead.
        /// </para>
        /// </remarks>
        Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, IDbDataParameter[])"/> instead.
        /// </para>
        /// </remarks>
        Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments);

        /// <summary>
        /// Executes a query and returns the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results.</returns>
        /// <remarks>
        /// <para>
        ///     Warning: This method will load all results into memory.
        ///     If you only want to iterate over a large result set, consider using
        ///     <see cref="GetDataReaderAsync(string, IDbDataParameter[], CancellationToken)"/> instead.
        /// </para>
        /// </remarks>
        Task<DataTable> GetDataTableAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken);

        #endregion

        #region ExecuteNonQueryAsync

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string storedProcedureName);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="connectionString"></param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync(
                  string storedProcedureName,
                  int commandTimeout);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync(
                  string connectionString,
                  string storedProcedureName,
                  int commandTimeout);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync(
    string storedProcedureName,
    int commandTimeout,
    CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQueryAsync(
    string connectionString,
    string storedProcedureName,
    int commandTimeout,
    CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            int commandTimeout);

        /// <summary>
        /// Executes a query that does not return any results with specified command timeout.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="commandTimeout"></param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            int commandTimeout);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that does not return any results.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureArguments">The stored procedure arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteNonQueryAsync(
            string connectionString,
            string storedProcedureName,
            IDbDataParameter[] storedProcedureArguments,
            CancellationToken cancellationToken);

        Task<int> ExecuteNonQueryAsync(
           string storedProcedureName,
           IDbDataParameter[] storedProcedureArguments,
           int commandTimeout,
           CancellationToken cancellationToken);

        Task<int> ExecuteNonQueryAsync(
           string connectionString,
           string storedProcedureName,
           IDbDataParameter[] storedProcedureArguments,
           int commandTimeout,
           CancellationToken cancellationToken);

        #endregion
    }
}
