using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using Medical.Data.Contract.Core;
using Medical.Data.Core.Extensions;

namespace Medical.Data.Core
{
    public class DataRecordMappingHelper : IDataRecordMappingHelper
    {
        public bool GetBoolean(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is bool)
            {
                return (bool)value;
            }

            int integerValue;

            if (int.TryParse(value.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out integerValue))
            {
                switch (integerValue)
                {
                    case 0:
                        return false;

                    case 1:
                        return true;
                }
            }

            return bool.Parse(value.ToString());
        }

        /// <inheritdoc />
        public byte GetByte(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is byte)
            {
                return (byte)value;
            }

            return byte.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public short GetShort(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is short)
            {
                return (short)value;
            }

            return short.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public int GetInteger(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is int)
            {
                return (int)value;
            }

            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public long GetLong(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is long)
            {
                return (long)value;
            }

            return long.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public double GetDouble(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is double)
            {
                return (double)value;
            }

            return double.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public Guid GetGuid(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is Guid)
            {
                return (Guid)value;
            }

            return Guid.Parse(value.ToString());
        }

        /// <inheritdoc />
        public DateTime GetDateTime(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is DateTime)
            {
                return (DateTime)value;
            }

            return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public DateTimeOffset GetDateTimeOffset(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            ValidateNotNullableValue(value, columnName);

            if (value is DateTimeOffset)
            {
                return (DateTimeOffset)value;
            }

            return DateTimeOffset.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public string GetString(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (value == null)
            {
                return null;
            }

            return value.ToString().Trim();
        }

        /// <inheritdoc />
        public bool? GetNullableBoolean(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is bool)
            {
                return (bool)value;
            }

            int integerValue;

            if (int.TryParse(value.ToString(), NumberStyles.None, CultureInfo.InvariantCulture, out integerValue))
            {
                switch (integerValue)
                {
                    case 0:
                        return false;

                    case 1:
                        return true;
                }
            }

            return bool.Parse(value.ToString());
        }

        /// <inheritdoc />
        public byte? GetNullableByte(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is byte)
            {
                return (byte)value;
            }

            return byte.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public short? GetNullableShort(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is short)
            {
                return (short)value;
            }

            return short.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public int? GetNullableInteger(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is int)
            {
                return (int)value;
            }

            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public long? GetNullableLong(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is long)
            {
                return (long)value;
            }

            return long.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public double? GetNullableDouble(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is double)
            {
                return (double)value;
            }

            return double.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public Guid? GetNullableGuid(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is Guid)
            {
                return (Guid)value;
            }

            return Guid.Parse(value.ToString());
        }

        /// <inheritdoc />
        public DateTime? GetNullableDateTime(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is DateTime)
            {
                return (DateTime)value;
            }

            return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public DateTimeOffset? GetNullableDateTimeOffset(IDataRecord dataRecord, string columnName)
        {
            ValidateParameters(dataRecord, columnName);

            var value = dataRecord.SafeGetValue(columnName);

            if (IsEmpty(value))
            {
                return null;
            }

            if (value is DateTimeOffset)
            {
                return (DateTimeOffset)value;
            }

            return DateTimeOffset.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        private static bool IsEmpty(object value)
            => value == null || string.IsNullOrWhiteSpace(value.ToString());

        private static void ValidateParameters(IDataRecord dataRecord, string columnName)
        {
            if (dataRecord == null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "\"{0}\" is an invalid column name.",
                        columnName),
                    nameof(columnName));
            }
        }

        private static void ValidateNotNullableValue(object value, string columnName)
        {
            if (IsEmpty(value))
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Empty value \"{0}\" is not expected for column \"{1}\".",
                        value,
                        columnName));
            }
        }
    }
}
