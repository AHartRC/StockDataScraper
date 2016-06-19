﻿#region Using Directives

using System;

#endregion

namespace StockDataScraper.Attributes
{
    public class HiddenAttribute : Attribute
    {
        public HiddenAttribute(bool isHidden = true)
        {
            IsHidden = isHidden;
        }

        public bool IsHidden { get; protected set; }
    }
}