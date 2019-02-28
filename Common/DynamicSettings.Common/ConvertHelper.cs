using System;

namespace DynamicSettings.Common
{
	public static class ConvertHelper
	{
		public static int? ToInteger(Object obj, int? defaultValue = null)
		{
			if (obj != null && int.TryParse(obj.ToString().Trim(), out var result))
			{
				return result;
			}

			return defaultValue;
		}

		public static bool? ToBoolean(object obj, bool? defaultValue = null)
		{
			if (obj != null && bool.TryParse(obj.ToString().Trim(), out var result))
			{
				return result;
			}

			return defaultValue;
		}

		public static Guid? ToGuid(object obj, Guid? defaultValue = null)
		{
			if (obj != null && Guid.TryParse(obj.ToString().Trim(), out var result))
			{
				return result;
			}

			return defaultValue;
		}
	}
}
