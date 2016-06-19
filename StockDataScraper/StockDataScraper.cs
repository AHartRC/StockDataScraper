#region Using Directives

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using StockDataScraper.Extensions;
using StockDataScraper.Helpers;

#endregion

namespace StockDataScraper
{
    public class StockDataScraper
    {
        #region Constructors

        static StockDataScraper()
        {
            #region CSI Data Map

            CSIDataMap = new[]
            {
                new object[] {CSIDataType.cash, null, null},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, (CSIDataExchange) 74},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, (CSIDataExchange) 75},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, CSIDataExchange.BDP},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, CSIDataExchange.MEFF},
                new object[] {CSIDataType.commodity, (CSIDataCategory) 25, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Chemicals, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Chemicals, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Diff, CSIDataExchange.MEFF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Diff, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, (CSIDataExchange) 94},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ACCESS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CCFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CLEAR},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.DGCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.DME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.EEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ICEUK},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.KCBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.MCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.MGE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.NFX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.NYMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.RTS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.SHFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.TCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, CSIDataExchange.ZCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Energy, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.ETF, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.ETF, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.ETF, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.AEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.BMF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.CCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.CLEAR},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.DC},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.EEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ICECA},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ICEUK},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.LCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.MATIF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.MCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.MGE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.NCDEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ODE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.OME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.RMX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.SHFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.SICOM},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.TCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.TGE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.YCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, CSIDataExchange.ZCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Food_and_Fiber, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, (CSIDataExchange) 30},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, (CSIDataExchange) 49},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, (CSIDataExchange) 94},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, (CSIDataExchange) 95},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.BMF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.DGCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.EOE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.HKEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.KOFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.MEFF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.NSI},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.PBOT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.RTS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.TFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, CSIDataExchange.TFX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Forex_Currencies, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Bonds, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Notes, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, (CSIDataExchange) 70},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.LIFFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, CSIDataExchange.ME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Rates, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Govt_Stock, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.CCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.DC},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.EOE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.ICECA},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.LCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.MATIF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.MDEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.MGE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.NCDEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.ODE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.RMX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.SAFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, CSIDataExchange.ZCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Grains_and_Oilseeds, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Index, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.CBOE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.CFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.CFFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.HKEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.KSE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.MDEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.OSE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.TAIFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, CSIDataExchange.TFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Asian, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Australian, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Australian, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Australian, CSIDataExchange.NZFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Australian, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Australian, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Canadian, (CSIDataExchange) 58},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Canadian, CSIDataExchange.ME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Canadian, CSIDataExchange.TFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Canadian, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, CSIDataExchange.ODE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Commodity, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 100},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 107},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 2},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 28},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 30},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, (CSIDataExchange) 49},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.ADEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.BDP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.BELFOX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.BUD},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.COMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.DTB},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.EOE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.EUREX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.LCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.LIFFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.LME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.MATIF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.MEFF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.MIF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.OSLO},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.OTOB},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.RTS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.TDE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, CSIDataExchange.WSE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_European, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Housing, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Housing, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Housing, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Indian_Stocks, CSIDataExchange.BSE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Indian_Stocks, CSIDataExchange.NSI},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Indian_Stocks, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Mexican, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Mexican, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Mexican, CSIDataExchange.MEXDER},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_Mexican, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_African, CSIDataExchange.SAFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_African, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_American, CSIDataExchange.BMF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_American, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_American, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_S_American, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, (CSIDataExchange) 30},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, (CSIDataExchange) 49},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.ACCESS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.CBOE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.CFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.KCBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, CSIDataExchange.NYMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US_Bonds, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US_Bonds, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Indexes_US_Bonds, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Industrial_Indexes, CSIDataExchange.EUREX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Industrial_Indexes, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, (CSIDataExchange) 100},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, (CSIDataExchange) 107},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, (CSIDataExchange) 94},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.BELFOX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.DTB},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.HKEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.ICEUK},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.LIFFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.MATIF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, CSIDataExchange.SOFFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Interest_Rates, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, (CSIDataExchange) 72},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.AEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.BMF},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.LCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.RMX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Livestock_and_Meats, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, (CSIDataExchange) 72},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, (CSIDataExchange) 94},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.CLEAR},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.COMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.DC},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.DGCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.HKEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.ICECA},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.KOFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.LME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.MCX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.NYMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.OME},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.RTS},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.SHFE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.TAIFEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, CSIDataExchange.TCE},
                new object[] {CSIDataType.commodity, CSIDataCategory.Metals, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, (CSIDataExchange) 72},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, CSIDataExchange.DC},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, CSIDataExchange.NYMEX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, CSIDataCategory.Petroleum, null},
                new object[] {CSIDataType.commodity, CSIDataCategory.Real_Estate, (CSIDataExchange) 107},
                new object[] {CSIDataType.commodity, CSIDataCategory.Real_Estate, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, CSIDataCategory.Real_Estate, null},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 0},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 100},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 107},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 2},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 28},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 30},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 49},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 58},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 70},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 72},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 73},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 74},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 75},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 94},
                new object[] {CSIDataType.commodity, null, (CSIDataExchange) 95},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ACCESS},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ADEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.AEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ASX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ASXGROUP},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BALTEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BDP},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BELFOX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BMF},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BRIESE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BSE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.BUD},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CBOE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CBT},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CCFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CCX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CFFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CFTC},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CLEAR},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CME},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.CMEGROUP},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.COMEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.DC},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.DGCX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.DME},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.DTB},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.EEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ELX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.EOE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.EUREX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.EURONEXT},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.EUS},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.GLBX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.HKEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ICE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ICECA},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ICEUK},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ICEUS},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.KCBT},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.KOFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.KSE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.LCE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.LIFFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.LME},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MACE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MATIF},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MCX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MDEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ME},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MEFF},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MEXDER},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MGE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.MIF},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.NCDEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.NFX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.NSI},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.NYMEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.NZFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ODE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.OME},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.OSE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.OSLO},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.OTOB},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.PBOT},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.RMX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.RTS},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SAFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SGX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SHFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SICOM},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.SOFFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TAIFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TCE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TDE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TFE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TFEX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TFX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TGE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.TSX},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.WSE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.YCE},
                new object[] {CSIDataType.commodity, null, CSIDataExchange.ZCE},
                new object[] {CSIDataType.commodity, null, null},
                new object[] {CSIDataType.commodityoption, null, null},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 79},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 80},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 81},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 83},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 84},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 85},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 86},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 87},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 88},
                new object[] {CSIDataType.stock, null, (CSIDataExchange) 89},
                new object[] {CSIDataType.stock, null, CSIDataExchange.TSX},
                new object[] {CSIDataType.stock, null, null},
                new object[] {CSIDataType.stockoption, null, null}
            };

            #endregion CSI Data Map
        }

        #endregion Constructors

        #region Stock Details

        public static void GetStockDetails()
        {
            Console.WriteLine("Retrieving Stock Details");

            var sw = new Stopwatch();
            sw.Start();

            var db = new StockDataEntities();
            var dateThreshold = DateTime.UtcNow.AddDays(-7);

            var searches = db.CSIDataCSVRecords
                .Where(w => w.Exchange != null && w.Symbol != null && w.EndDate > dateThreshold)
                .Select(s => new {s.Exchange, s.Symbol})
                .Distinct()
                .OrderBy(o => o.Exchange)
                .ThenBy(t => t.Symbol)
                .ToArray();

            decimal total = searches.Length;
            var responses =
                searches.Select((s, i) => new StockResponse(s.Exchange, s.Symbol, i, total)).OrderBy(o => o.Index);

            var exchangeGroup = responses.GroupBy(g => g.Exchange);

            foreach (var exchange in exchangeGroup)
            {
                foreach (var symbol in exchange.Take(100))
                {
                    var sw2 = new Stopwatch();
                    sw2.Start();
                    symbol.GetResponse();
                    var averageTicks = sw.Elapsed.Ticks/(symbol.Index + 1);
                    var remainingTicks = (long) (averageTicks*symbol.Remaining);
                    var average = new TimeSpan(averageTicks).ToString();
                    var remaining = new TimeSpan(remainingTicks).ToString();
                    sw2.Stop();
                    symbol.Elapsed = sw2.Elapsed;
                    Console.Write(" | {0} | {1} | {2} | {3} Remaining\t\t", sw2.Elapsed, sw.Elapsed, average, remaining);
                }
            }
            sw.Stop();

            var schema = JsonHelper.OutputGlobalSchema();
            Console.WriteLine("\r\n{0} records processed in {1}\r\n\r\n{2}", total, sw.Elapsed, schema);
        }

        #endregion Stock Details

        #region Properties

        public static DateTime currentTime { get; set; }
        private static Dictionary<string, int> maxLengths { get; set; }

        public static long currentTicks
        {
            get { return currentTime.Ticks; }
        }

        public static object[][] CSIDataMap { get; }

        #endregion Properties

        #region CSI Data

        public static void GetAllCSIData(bool writeToFile = false)
        {
            maxLengths = new Dictionary<string, int>();
            currentTime = DateTime.UtcNow;

            foreach (var type in default(CSIDataType).GetEnums())
            {
                int iMax;
                int jMax;

                switch (type)
                {
                    case CSIDataType.commodity:
                        iMax = 32;
                        jMax = 119;
                        break;
                    case CSIDataType.stock:
                        iMax = 0;
                        jMax = 89;
                        break;
                    case CSIDataType.cash:
                    case CSIDataType.commodityoption:
                    case CSIDataType.stockoption:
                        iMax = 0;
                        jMax = 0;
                        break;
                    default:
                        //iMax = 500;
                        //jMax = 500;
                        throw new ArgumentOutOfRangeException("type", "Unknown CSI Data Type!");
                }

                var url = string.Format(StockResponse.CSIDataUrlTemplateD, type);
                ProcessResponse(url, type, null, null, writeToFile);

                if (iMax > 0)
                {
                    for (var i = 0; i <= iMax; i++)
                    {
                        url = string.Format(StockResponse.CSIDataUrlTemplateA, type, i);
                        ProcessResponse(url, type, (CSIDataCategory) i, null, writeToFile);
                    }
                }

                if (jMax > 0)
                {
                    for (var j = 0; j <= jMax; j++)
                    {
                        url = string.Format(StockResponse.CSIDataUrlTemplateB, type, null, j);
                        ProcessResponse(url, type, null, (CSIDataExchange) j, writeToFile);
                    }
                }

                if (iMax > 0 && jMax > 0)
                {
                    for (var i = 0; i <= iMax; i++)
                    {
                        for (var j = 0; j <= jMax; j++)
                        {
                            url = string.Format(StockResponse.CSIDataUrlTemplateC, type, i, j);
                            ProcessResponse(url, type, (CSIDataCategory) i, (CSIDataExchange) j, writeToFile);
                        }
                    }
                }
            }
        }

        private static void ProcessResponse(string url, CSIDataType? type = null, CSIDataCategory? category = null,
            CSIDataExchange? exchange = null, bool writeToFile = false)
        {
            var response = Traffic.HTTPGET(url);

            if (string.IsNullOrWhiteSpace(response))
                return;

            Console.Write("\r{0}\t\t\t\t\t", url);

            var filePath = string.Format("F:\\Output\\CSIData\\{0}\\{1}_{2}_{3}.csv", currentTicks,
                type.ToString().IfNullOrWhiteSpace("NULL"), category.ToString().IfNullOrWhiteSpace("NULL"),
                exchange.ToString().IfNullOrWhiteSpace("NULL"));

            var rows = response.Split('\n').Select(s => s.Trim()).Where(w => !w.IsNullOrWhiteSpace()).ToArray();

            if (rows.Length <= 1)
                return;

            //var columns = rows[0].SplitCSV().ToArray();

            //var recordRows = rows.Skip(1).ToArray();

            //for (int i = 0; i < columns.Length; i++)
            //{
            //    var column = columns[i];
            //    var values = recordRows.Select(s => s.SplitCSV().ToArray()[i].Trim());
            //    var maxLength = values.Max(m => m.Length);

            //    if (maxLengths.ContainsKey(column))
            //    {
            //        if (maxLengths[column] < maxLength)
            //            maxLengths[column] = maxLength;
            //    }
            //    else
            //    {
            //        maxLengths.Add(column, maxLength);
            //    }
            //}

            var record = new CSIDataRecord
            {
                Url = url,
                DataType = type,
                Category = category,
                Exchange = exchange,
                DateCreated = currentTime,
                FilePath = writeToFile ? filePath : null
            };

            ProcessCSIDataFile(ref record, rows);

            //foreach (var maxLength in maxLengths.OrderBy(o => o.Key))
            //{
            //    Console.WriteLine("\r{0} | {1}\t\t\t\t\t\t\t\t\t\t\t\t", maxLength.Key, maxLength.Value);
            //}

            using (var db = new StockDataEntities())
            {
                var result = 0;
                try
                {
                    db.CSIDataRecords.Add(record);
                    result = db.SaveChanges();
                }
                catch (DbEntityValidationException dbevex)
                {
                    foreach (
                        var validationError in
                            dbevex.EntityValidationErrors.SelectMany(
                                validationErrors => validationErrors.ValidationErrors))
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                        Console.WriteLine("{0} | {1} | {2}", validationError.PropertyName,
                            maxLengths[validationError.PropertyName], validationError.ErrorMessage);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("\r{0} Results from {1}\t\t\t\t\t", result, url);
            }

            if (writeToFile)
            {
                var fileInfo = new FileInfo(filePath);
                FileHelper.WriteToFile(fileInfo, response);
                record.FilePath = filePath;
            }
        }

        private static void ProcessCSIDataFile(ref CSIDataRecord record, string[] rows)
        {
            var headers = rows.First().SplitCSV().ToArray();

            var recordRows = rows.Skip(1);

            foreach (var row in recordRows)
            {
                var dataRecord = new CSIDataCSVRecord();
                var columns = row.SplitCSV().ToArray();

                if (columns.Length != headers.Length)
                    continue;

                for (var i = 0; i < headers.Length; i++)
                {
                    var prop = dataRecord.GetType().GetProperty(headers[i], BindingFlags.Public | BindingFlags.Instance);

                    if (prop != null && prop.CanWrite && !columns[i].IsNullOrWhiteSpace())
                    {
                        var value = columns[i].Trim();
                        var length = value.Length;

                        if (maxLengths.ContainsKey(prop.Name))
                        {
                            if (maxLengths[prop.Name] < length)
                                maxLengths[prop.Name] = length;
                        }
                        else
                        {
                            maxLengths.Add(prop.Name, length);
                        }

                        if (value.IsNullOrWhiteSpace())
                            continue;

                        var t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                        // CSI Data has 0 and 1 for false and true values
                        // Normally not needed but is in this circumstance
                        if (t == typeof (bool))
                            value = (value != "0" && value.ToLower() != "false").ToString();

                        // CSI Data may include scientific notation in decimals.
                        // We need to make sure all decimals are clean before parsing
                        if (t == typeof (decimal))
                            value = decimal.Parse(value, NumberStyles.Any).ToString(CultureInfo.InvariantCulture);

                        var safeValue = Convert.ChangeType(value, t, CultureInfo.InvariantCulture);
                        prop.SetValue(dataRecord, safeValue, null);
                    }
                }
                record.CSIDataCSVRecords.Add(dataRecord);
            }
        }

        public static void GetCSIData(bool writeToFile = false)
        {
            maxLengths = new Dictionary<string, int>();
            currentTime = DateTime.UtcNow;

            foreach (var map in CSIDataMap)
            {
                var type = (CSIDataType) map[0];
                var category = (CSIDataCategory?) map[1];
                var exchange = (CSIDataExchange?) map[2];

                string template;

                if (category == null && exchange == null)
                {
                    template = StockResponse.CSIDataUrlTemplateD;
                }
                else if (category != null && exchange != null)
                {
                    template = StockResponse.CSIDataUrlTemplateC;
                }
                else if (category == null)
                {
                    template = StockResponse.CSIDataUrlTemplateB;
                }
                else
                {
                    template = StockResponse.CSIDataUrlTemplateA;
                }

                var url = string.Format(template, type, (int?) category, (int?) exchange);
                ProcessResponse(url, type, category, exchange, writeToFile);
            }
        }

        public static void ParseCSIData(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
                return;

            var directory = new DirectoryInfo(folder);

            if (!directory.Exists)
                return;

            IEnumerable<FileInfo> files = directory.EnumerateFiles("*.csv", SearchOption.AllDirectories).ToArray();

            if (!files.Any())
                return;

            foreach (var file in files)
            {
                var name = file.Name.Replace(".csv", "");
                var typeString = name.Split('_').First();
                var exchangeString = name.Split('_').Last();
                var categoryString = name.Replace(typeString, "").Replace(exchangeString, "").Trim('_').Trim();

                if (string.IsNullOrWhiteSpace(categoryString))
                    categoryString = "NULL";
                if (string.IsNullOrWhiteSpace(exchangeString))
                    exchangeString = "NULL";

                var type =
                    (CSIDataType?) (typeString.Equals("NULL") ? null : Enum.Parse(typeof (CSIDataType), typeString));
                var category =
                    (CSIDataCategory?)
                        (categoryString.Equals("NULL") ? null : Enum.Parse(typeof (CSIDataCategory), categoryString));
                var exchange =
                    (CSIDataExchange?)
                        (exchangeString.Equals("NULL") ? null : Enum.Parse(typeof (CSIDataExchange), exchangeString));

                var rows = File.ReadAllLines(file.FullName);


                var record = new CSIDataRecord
                {
                    DataType = type,
                    Category = category,
                    Exchange = exchange,
                    FilePath = file.FullName,
                    DateCreated = currentTime
                };

                ProcessCSIDataFile(ref record, rows);

                using (var db = new StockDataEntities())
                {
                    db.CSIDataRecords.Add(record);
                    var result = db.SaveChanges();
                    Console.WriteLine("\r{0} Results from {1}\t\t\t\t\t", result, file.FullName);
                }
            }
        }

        public static void ParseCSIDataHeaders(string folder)
        {
            //if (string.IsNullOrWhiteSpace(folder))
            //    return;

            //DirectoryInfo directory = new DirectoryInfo(folder);

            //if (!directory.Exists)
            //    return;

            //var files = directory.EnumerateFiles("*.csv", SearchOption.AllDirectories).ToArray();

            //if (!files.Any())
            //    return;

            //Dictionary<string, List<Type>> allFields = new Dictionary<string, List<Type>>();

            //foreach (FileInfo file in files)
            //{
            //    Console.Write("\r{0}\t\t\t", file.FullName);
            //    //string name = file.Name.Replace(".csv", "");
            //    //string typeString = name.Split('_').First();
            //    //string exchangeString = name.Split('_').Last();
            //    //string categoryString = name.Replace(typeString, "").Replace(exchangeString, "").Trim('_').Trim();

            //    //if (string.IsNullOrWhiteSpace(categoryString))
            //    //    categoryString = "NULL";
            //    //if (string.IsNullOrWhiteSpace(exchangeString))
            //    //    exchangeString = "NULL";

            //    //var exchange = exchangeString.Equals("NULL") ? null : Enum.Parse(typeof(CSIDataExchange), exchangeString);
            //    //var type = typeString.Equals("NULL") ? null : Enum.Parse(typeof(CSIDataType), typeString);
            //    //var category = categoryString.Equals("NULL") ? null : Enum.Parse(typeof(CSIDataCategory), categoryString);

            //    string[] rows = File.ReadAllLines(file.FullName).Where(w => !w.IsNullOrWhiteSpace()).ToArray();
            //    string[] headers = rows[0].SplitCSV().ToArray();
            //    string[] recordRows = rows.Where(w => !w.IsNullOrWhiteSpace()).Skip(1).ToArray();

            //    for (int i = 0; i < headers.Length; i++)
            //    {
            //        var values = recordRows.Select(s => s.SplitCSV().ToArray()[i]).ToArray();
            //        var cleanValues = values.Where(w => !w.IsNullOrWhiteSpace()).ToArray();
            //        bool nullable = values.Any(a => a.IsNullOrWhiteSpace());

            //        if (!cleanValues.Any())
            //            continue;

            //        Type valueType = typeof(string);
            //        DateTime testDateTime;
            //        decimal testDecimal;
            //        ushort testUShort;
            //        uint testUInt;
            //        ulong testULong;
            //        short testShort;
            //        int testInt;
            //        long testLong;

            //        List<Type> types = new List<Type>(){typeof(string)};
            //        if (cleanValues.All(a => DateTime.TryParse(a, out testDateTime)))
            //        {
            //            //valueType = nullable ? typeof(DateTime?) : typeof (DateTime);
            //            types.Add(nullable ? typeof(DateTime?) : typeof(DateTime));
            //        }
            //        if (cleanValues.Any(a => a.Contains(".") || a.ToLower().Contains("e-")) && cleanValues.All(a => decimal.TryParse(a, NumberStyles.Any, CultureInfo.InvariantCulture, out testDecimal)))
            //        {
            //            //valueType = nullable ? typeof(decimal?) : typeof(decimal);
            //            types.Add(nullable ? typeof(decimal?) : typeof(decimal));
            //        }
            //        if (cleanValues.All(a => a.Equals("0") || a.Equals("1") || a.Equals("true") || a.Equals("false")))
            //        {
            //            //valueType = nullable ? typeof(bool?) : typeof(bool);
            //            types.Add(nullable ? typeof(bool?) : typeof(bool));
            //        }
            //        if (cleanValues.All(a => ushort.TryParse(a, out testUShort)))
            //        {
            //            //valueType = nullable ? typeof(ushort?) : typeof(ushort);
            //            types.Add(nullable ? typeof(ushort?) : typeof(ushort));
            //        }
            //        if (cleanValues.All(a => uint.TryParse(a, out testUInt)))
            //        {
            //            //valueType = nullable ? typeof(uint?) : typeof(uint);
            //            types.Add(nullable ? typeof(uint?) : typeof(uint));
            //        }
            //        if (cleanValues.All(a => ulong.TryParse(a, out testULong)))
            //        {
            //            //valueType = nullable ? typeof(ulong?) : typeof(ulong);
            //            types.Add(nullable ? typeof(ulong?) : typeof(ulong));
            //        }
            //        if (cleanValues.All(a => short.TryParse(a, out testShort)))
            //        {
            //            //valueType = nullable ? typeof(short?) : typeof(short);
            //            types.Add(nullable ? typeof(short?) : typeof(short));
            //        }
            //        if (cleanValues.All(a => int.TryParse(a, out testInt)))
            //        {
            //            //valueType = nullable ? typeof(int?) : typeof(int);
            //            types.Add(nullable ? typeof(int?) : typeof(int));
            //        }
            //        if (cleanValues.All(a => long.TryParse(a, out testLong)))
            //        {
            //            //valueType = nullable ? typeof(long?) : typeof(long);
            //            types.Add(nullable ? typeof(long?) : typeof(long));
            //        }

            //        foreach (var t in types)
            //        {
            //            if (allFields.ContainsKey(headers[i]))
            //                allFields[headers[i]].Add(t);
            //            else
            //                allFields.Add(headers[i], new List<Type> { t });
            //        }

            //        var list = allFields[headers[i]].Distinct();
            //        allFields[headers[i]] = list.ToList();
            //    }
            //}

            //IEnumerable<string> fields = allFields.Distinct().OrderBy(o => o.Key).SelectMany(sm => sm.Value.Select(s => string.Format("\t\tpublic {0} {1} {{ get; set; }}", s, sm.Key)));
            //FileInfo fileInfo = new FileInfo("F:\\Output\\CSIData\\CSIDataCSVRecord.cs");

            //WriteToFile(fileInfo, "namespace Sandbox");
            //AppendToFile(fileInfo, "{");
            //AppendToFile(fileInfo, "\tpublic class CSIDataCSVRecord");
            //AppendToFile(fileInfo, "\t{");
            //AppendToFile(fileInfo, string.Join("\r\n", fields));
            //AppendToFile(fileInfo, "\t}");
            //AppendToFile(fileInfo, "}");
        }

        //private static Type RankTypes(Type a, Type b)
        //{
        //    if (a == typeof(DateTime) || a == typeof(DateTime?))
        //    {
        //        return a;
        //    }

        //    if (a == typeof(decimal) || a == typeof(decimal?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(bool) || a == typeof(bool?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(short) || a == typeof(short?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(int) || a == typeof(int?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(long) || a == typeof(long?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?) ||
        //            b == typeof(int) || b == typeof(int?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(ushort) || a == typeof(ushort?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?) ||
        //            b == typeof(int) || b == typeof(int?) ||
        //            b == typeof(long) || b == typeof(long?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(uint) || a == typeof(uint?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?) ||
        //            b == typeof(int) || b == typeof(int?) ||
        //            b == typeof(long) || b == typeof(long?) ||
        //            b == typeof(ushort) || b == typeof(ushort?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(ulong) || a == typeof(ulong?))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?) ||
        //            b == typeof(int) || b == typeof(int?) ||
        //            b == typeof(long) || b == typeof(long?) ||
        //            b == typeof(ushort) || b == typeof(ushort?) ||
        //            b == typeof(uint) || b == typeof(uint?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    if (a == typeof(string))
        //    {
        //        if (b == typeof(DateTime) || b == typeof(DateTime?) ||
        //            b == typeof(decimal) || b == typeof(decimal?) ||
        //            b == typeof(bool) || b == typeof(bool?) ||
        //            b == typeof(short) || b == typeof(short?) ||
        //            b == typeof(int) || b == typeof(int?) ||
        //            b == typeof(long) || b == typeof(long?) ||
        //            b == typeof(ushort) || b == typeof(ushort?) ||
        //            b == typeof(uint) || b == typeof(uint?) ||
        //            b == typeof(ushort) || b == typeof(ushort?) ||
        //            b == typeof(ulong) || b == typeof(ulong?))
        //        {
        //            return b;
        //        }
        //        return a;
        //    }

        //    return a;
        //}

        //public static void RecordCSIData()
        //{
        //    var connString =
        //        "Data Source=ANTHONY-PC;Initial Catalog=StockData;Integrated Security=True;MultipleActiveResultSets=true;";


        //    foreach (var data in CSIData)
        //    {
        //        Console.Write("\r{0} | {1} | {2} | {3} Records", data.DataType, data.Category, data.Exchange, data.CSIDataCSVRecords.Count);
        //        StockDataEntities db = new StockDataEntities();
        //        db.CSIData.Add(data);
        //        var count = db.SaveChanges();
        //        Console.WriteLine(" {0} Records insert into database");
        //    }

        //    var firstRecord = CSIData.First();
        //    var firstRecordDataType = firstRecord.GetType();
        //    var firstRecordDataProperties = firstRecordDataType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var firstDataRecord = firstRecord.CSIDataCSVRecords.First();
        //    var firstDataRecordDataType = firstDataRecord.GetType();
        //    var firstDataRecordDataProperties = firstDataRecordDataType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        using (SqlBulkCopy sbcA = new SqlBulkCopy(conn) { BatchSize = 10000, BulkCopyTimeout = 60, DestinationTableName = "dbo.CSIDataRecord" })
        //        {
        //            using (SqlBulkCopy sbcB = new SqlBulkCopy(conn) { BatchSize = 10000, BulkCopyTimeout = 60, DestinationTableName = "dbo.CSIDataCSVRecord" })
        //            {

        //                foreach (var dataProperty in firstRecordDataProperties)
        //                {
        //                    sbcA.ColumnMappings.Add(dataProperty.Name, dataProperty.Name);
        //                }
        //                foreach (var dataProperty in firstDataRecordDataProperties)
        //                {
        //                    sbcB.ColumnMappings.Add(dataProperty.Name, dataProperty.Name);
        //                }

        //                foreach (var data in CSIData)
        //                {
        //                }


        //            }
        //        }
        //    }
        //}

        #endregion CSI Data
    }
}