using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Test.Code
{
	public static class DataExtractor
	{
		public static object GetGuid(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? null : dr.GetValue(ordinal);
		}

		public static Guid GetValue(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? Guid.Empty : dr.GetGuid(ordinal);
		}

		public static byte[] GetByte(IDataReader dr, string columnName, int length)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			byte[] buffer = null;

			if (!isDbNull)
			{
				buffer = new byte[length];
				dr.GetBytes(ordinal, 0, buffer, 0, length);
			}

			return buffer;
		}

		public static byte GetByte(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? default(byte) : dr.GetByte(ordinal);
		}

		public static double GetDouble(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? double.NaN : dr.GetDouble(ordinal);
		}

		public static decimal GetDecimal(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? decimal.Zero : dr.GetDecimal(ordinal);
		}

		public static string GetString(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? "" : dr.GetString(ordinal);
		}

		public static DateTime GetDateTime(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? DateTime.MinValue : dr.GetDateTime(ordinal);
		}

		public static long GetInt64(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? 0 : dr.GetInt64(ordinal);
		}

		public static int GetInt32(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? 0 : dr.GetInt32(ordinal);
		}

		public static short GetInt16(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? ((short)0) : dr.GetInt16(ordinal);
		}

		public static bool GetBoolean(IDataReader dr, string columnName)
		{
			int ordinal = dr.GetOrdinal(columnName);
			bool isDbNull = dr.IsDBNull(ordinal);

			return isDbNull ? false : dr.GetBoolean(ordinal);
		}
	}
}
