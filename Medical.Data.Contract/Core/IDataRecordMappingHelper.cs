using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Contract.Core
{
 public interface IDataRecordMappingHelper
    {
        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="bool"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="bool"/>.</returns>
        bool GetBoolean(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="byte"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="int"/>.</returns>
        byte GetByte(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="short"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="int"/>.</returns>
        short GetShort(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="int"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="int"/>.</returns>
        int GetInteger(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="long"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="long"/>.</returns>
        long GetLong(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="double"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="double"/>.</returns>
        double GetDouble(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Guid"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Guid"/>.</returns>
        Guid GetGuid(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="DateTime"/>.</returns>
        DateTime GetDateTime(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="DateTimeOffset"/>.</returns>
        DateTimeOffset GetDateTimeOffset(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="string"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="String"/>.</returns>
        string GetString(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Boolean}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Boolean}"/>.</returns>
        bool? GetNullableBoolean(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Byte}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Int32}"/>.</returns>
        byte? GetNullableByte(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Int16}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Int32}"/>.</returns>
        short? GetNullableShort(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Int32}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Int32}"/>.</returns>
        int? GetNullableInteger(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Int64}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Int64}"/>.</returns>
        long? GetNullableLong(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Double}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Double}"/>.</returns>
        double? GetNullableDouble(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{Guid}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{Guid}"/>.</returns>
        Guid? GetNullableGuid(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{DateTime}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{DateTime}"/>.</returns>
        DateTime? GetNullableDateTime(IDataRecord dataRecord, string columnName);

        /// <summary>
        /// Gets a value from the <paramref name="dataRecord"/> by the <paramref name="columnName">column name</paramref>
        /// and converts it to <see cref="Nullable{DateTimeOffset}"/>.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the data record column converted to <see cref="Nullable{DateTimeOffset}"/>.</returns>
        DateTimeOffset? GetNullableDateTimeOffset(IDataRecord dataRecord, string columnName);
    }
}
