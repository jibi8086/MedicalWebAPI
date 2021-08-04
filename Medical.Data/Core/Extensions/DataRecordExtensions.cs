using System;
using System.Data;

namespace Medical.Data.Core.Extensions
{
 public static class DataRecordExtensions
    {
        /// <summary>
        /// To workaround a DataReader limitation of not being able to know if a column exists or not on the DataReader,
        /// this extension provides a way to get the value safely (without getting an exception), even if the column is not there.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The value of the column or null.</returns>
        /// <exception cref="ArgumentNullException">dataRecord or columnName</exception>
        public static object SafeGetValue(this IDataRecord dataRecord, string columnName)
        {
            if (dataRecord == null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            if (columnName == null)
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            try
            {
                return dataRecord[columnName] is DBNull ? null : dataRecord[columnName];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
