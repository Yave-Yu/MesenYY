using System;
using System.Reflection;

namespace Mesen.Utilities
{
	public static class EnumExtensions
	{
		public static T? GetAttribute<T>(this Enum val) where T : Attribute
		{
			return val.GetType().GetMember(val.ToString())[0].GetCustomAttribute<T>();
		}
	}
}
