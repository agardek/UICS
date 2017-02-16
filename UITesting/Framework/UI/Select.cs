﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITesting.Framework.UI
{
	public class SelectList : Control
	{
		public SelectElement Select
		{
			get
			{
				return new SelectElement(base.Element);
			}
		}
		public new String Text
		{ 
			get
			{
				return base.Text;
			}
			set
			{
				this.Select.SelectByText(value);
			}
		}
		public SelectList(IWebDriver driverValue, By locatorValue) : base(driverValue, locatorValue)
		{
		}
	}
}
