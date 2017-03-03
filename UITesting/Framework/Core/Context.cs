﻿using System;
using System.Collections.Generic;

namespace UITesting.Framework.Core
{
	public class Context
	{
		private Context()
		{
		}
		private static Dictionary<String, Dictionary<String, Object>> contextVariables
			= new Dictionary<String, Dictionary<String, Object>>();
		public static void Put(String name, Object value)
		{
			Dictionary<String, Object> dataMap = new Dictionary<String, Object>();
			String threadName = Driver.GetThreadName();
			if (contextVariables.ContainsKey(threadName))
			{
				dataMap = contextVariables[threadName];
			}
			dataMap.Add(name, value);
			contextVariables.Add(threadName, dataMap);
		}
		public static Object Get(String name)
		{
			String threadName = Driver.GetThreadName();
			if (contextVariables.ContainsKey(threadName))
			{
				return contextVariables[threadName][name];
			}
			return null;
		}
		public static void ClearCurrent()
		{
			String threadName = Driver.GetThreadName();
			if (contextVariables.ContainsKey(threadName))
			{
				contextVariables.Remove(threadName);
			}
			contextVariables.Add(threadName, new Dictionary<String, Object>());
		}
	}
}
