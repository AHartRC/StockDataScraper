using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockDataScraper
{
    public class StockData
    {
        [JsonProperty(PropertyName = "avvo")]
        public string V_avvo { get; set; }

        [JsonProperty(PropertyName = "beta")]
        public string V_beta { get; set; }

        [JsonProperty(PropertyName = "c")]
        public string V_c { get; set; }

        [JsonProperty(PropertyName = "ccol")]
        public string V_ccol { get; set; }

        [JsonProperty(PropertyName = "cp")]
        public string V_cp { get; set; }

        [JsonProperty(PropertyName = "dy")]
        public string V_dy { get; set; }

        [JsonProperty(PropertyName = "e")]
        public string V_e { get; set; }

        [JsonProperty(PropertyName = "eo")]
        public string V_eo { get; set; }

        [JsonProperty(PropertyName = "eps")]
        public string V_eps { get; set; }

        [JsonProperty(PropertyName = "exchange")]
        public string V_exchange { get; set; }

        [JsonProperty(PropertyName = "expense_ratio")]
        public string V_expense_ratio { get; set; }

        [JsonProperty(PropertyName = "f_annual_date")]
        public string V_f_annual_date { get; set; }

        [JsonProperty(PropertyName = "f_recent_quarter_date")]
        public string V_f_recent_quarter_date { get; set; }

        [JsonProperty(PropertyName = "f_reuters_url")]
        public string V_f_reuters_url { get; set; }

        [JsonProperty(PropertyName = "f_ttm_date")]
        public string V_f_ttm_date { get; set; }

        [JsonProperty(PropertyName = "fwpe")]
        public string V_fwpe { get; set; }

        [JsonProperty(PropertyName = "hi")]
        public string V_hi { get; set; }

        [JsonProperty(PropertyName = "hi52")]
        public string V_hi52 { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string V_id { get; set; }

        [JsonProperty(PropertyName = "iid")]
        public string V_iid { get; set; }

        [JsonProperty(PropertyName = "iname")]
        public string V_iname { get; set; }

        [JsonProperty(PropertyName = "instown")]
        public string V_instown { get; set; }

        [JsonProperty(PropertyName = "kr_annual_date")]
        public string V_kr_annual_date { get; set; }

        [JsonProperty(PropertyName = "kr_recent_quarter_date")]
        public string V_kr_recent_quarter_date { get; set; }

        [JsonProperty(PropertyName = "kr_ttm_date")]
        public string V_kr_ttm_date { get; set; }

        [JsonProperty(PropertyName = "l")]
        public string V_l { get; set; }

        [JsonProperty(PropertyName = "ldiv")]
        public string V_ldiv { get; set; }

        [JsonProperty(PropertyName = "lo")]
        public string V_lo { get; set; }

        [JsonProperty(PropertyName = "lo52")]
        public string V_lo52 { get; set; }

        [JsonProperty(PropertyName = "mc")]
        public string V_mc { get; set; }

        [JsonProperty(PropertyName = "morningstar_rating")]
        public string V_morningstar_rating { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "nav_c")]
        public string V_nav_c { get; set; }

        [JsonProperty(PropertyName = "nav_cp")]
        public string V_nav_cp { get; set; }

        [JsonProperty(PropertyName = "nav_prior")]
        public string V_nav_prior { get; set; }

        [JsonProperty(PropertyName = "nav_time")]
        public string V_nav_time { get; set; }

        [JsonProperty(PropertyName = "net_assets")]
        public string V_net_assets { get; set; }

        [JsonProperty(PropertyName = "num")]
        public string V_num { get; set; }

        [JsonProperty(PropertyName = "num_all_results")]
        public string V_num_all_results { get; set; }

        [JsonProperty(PropertyName = "num_company_results")]
        public string V_num_company_results { get; set; }

        [JsonProperty(PropertyName = "num_mf_results")]
        public string V_num_mf_results { get; set; }

        [JsonProperty(PropertyName = "op")]
        public string V_op { get; set; }

        [JsonProperty(PropertyName = "original_query")]
        public string V_original_query { get; set; }

        [JsonProperty(PropertyName = "pe")]
        public string V_pe { get; set; }

        [JsonProperty(PropertyName = "query_for_display")]
        public string V_query_for_display { get; set; }

        [JsonProperty(PropertyName = "results_type")]
        public string V_results_type { get; set; }

        [JsonProperty(PropertyName = "return_ytd")]
        public string V_return_ytd { get; set; }

        [JsonProperty(PropertyName = "shares")]
        public string V_shares { get; set; }

        [JsonProperty(PropertyName = "sid")]
        public string V_sid { get; set; }

        [JsonProperty(PropertyName = "sname")]
        public string V_sname { get; set; }

        [JsonProperty(PropertyName = "start")]
        public string V_start { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string V_summary { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string V_symbol { get; set; }

        [JsonProperty(PropertyName = "t")]
        public string V_t { get; set; }

        [JsonProperty(PropertyName = "vo")]
        public string V_vo { get; set; }

        [JsonProperty(PropertyName = "yield_percent")]
        public string V_yield_percent { get; set; }

        [JsonProperty(PropertyName = "advisors")]
        public Collection<advisors> V_advisorsArray { get; set; }

        [JsonProperty(PropertyName = "events")]
        public Collection<events> V_eventsArray { get; set; }

        [JsonProperty(PropertyName = "financials")]
        public Collection<financials> V_financialsArray { get; set; }

        [JsonProperty(PropertyName = "keyratios")]
        public Collection<keyratios> V_keyratiosArray { get; set; }

        [JsonProperty(PropertyName = "keystatistics")]
        public Collection<keystatistics> V_keystatisticsArray { get; set; }

        [JsonProperty(PropertyName = "management")]
        public Collection<management> V_managementArray { get; set; }

        [JsonProperty(PropertyName = "managers")]
        public Collection<managers> V_managersArray { get; set; }

        [JsonProperty(PropertyName = "mf_searchresults")]
        public Collection<mf_searchresults> V_mf_searchresultsArray { get; set; }

        [JsonProperty(PropertyName = "moreresources")]
        public Collection<moreresources> V_moreresourcesArray { get; set; }

        [JsonProperty(PropertyName = "performance")]
        public Collection<performance> V_performanceArray { get; set; }

        [JsonProperty(PropertyName = "purchaseinfo")]
        public Collection<purchaseinfo> V_purchaseinfoArray { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public Collection<rating> V_ratingArray { get; set; }

        [JsonProperty(PropertyName = "related")]
        public Collection<related> V_relatedArray { get; set; }

        [JsonProperty(PropertyName = "risk")]
        public Collection<risk> V_riskArray { get; set; }

        [JsonProperty(PropertyName = "searchresults")]
        public Collection<searchresults> V_searchresultsArray { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Collection<summary> V_summaryArray { get; set; }

        [JsonProperty(PropertyName = "topholdings")]
        public Collection<topholdings> V_topholdingsArray { get; set; }
    }
    public class financials
    {
        [JsonProperty(PropertyName = "f_type")]
        public string V_f_type { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string V_url { get; set; }

        [JsonProperty(PropertyName = "f_figures")]
        public Collection<f_figures> V_f_figuresArray { get; set; }
    }
    public class f_figures
    {
        [JsonProperty(PropertyName = "annual")]
        public string V_annual { get; set; }

        [JsonProperty(PropertyName = "recent_quarter")]
        public string V_recent_quarter { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string V_title { get; set; }

        [JsonProperty(PropertyName = "ttm")]
        public string V_ttm { get; set; }
    }
    public class keyratios
    {
        [JsonProperty(PropertyName = "annual")]
        public string V_annual { get; set; }

        [JsonProperty(PropertyName = "recent_quarter")]
        public string V_recent_quarter { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string V_title { get; set; }

        [JsonProperty(PropertyName = "ttm")]
        public string V_ttm { get; set; }
    }
    public class related
    {
        [JsonProperty(PropertyName = "c")]
        public string V_c { get; set; }

        [JsonProperty(PropertyName = "ccol")]
        public string V_ccol { get; set; }

        [JsonProperty(PropertyName = "cp")]
        public string V_cp { get; set; }

        [JsonProperty(PropertyName = "e")]
        public string V_e { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string V_id { get; set; }

        [JsonProperty(PropertyName = "l")]
        public string V_l { get; set; }

        [JsonProperty(PropertyName = "mc")]
        public string V_mc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "t")]
        public string V_t { get; set; }
    }
    public class summary
    {
        [JsonProperty(PropertyName = "address")]
        public string V_address { get; set; }

        [JsonProperty(PropertyName = "fax")]
        public string V_fax { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string V_overview { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string V_phone { get; set; }

        [JsonProperty(PropertyName = "reuters_url")]
        public string V_reuters_url { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string V_url { get; set; }

        [JsonProperty(PropertyName = "sitelinks")]
        public Collection<sitelinks> V_sitelinksArray { get; set; }
    }
    public class management
    {
        [JsonProperty(PropertyName = "age")]
        public string V_age { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string V_title { get; set; }
    }
    public class moreresources
    {
        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string V_url { get; set; }
    }
    public class events
    {
        [JsonProperty(PropertyName = "future")]
        public int? V_future { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string V_date { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string V_desc { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string V_time { get; set; }

        [JsonProperty(PropertyName = "webcasturl")]
        public string V_webcasturl { get; set; }
    }
    public class sitelinks
    {
        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string V_url { get; set; }
    }
    public class searchresults
    {
        [JsonProperty(PropertyName = "exchange")]
        public string V_exchange { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string V_id { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public string V_is_active { get; set; }

        [JsonProperty(PropertyName = "is_supported_exchange")]
        public string V_is_supported_exchange { get; set; }

        [JsonProperty(PropertyName = "local_currency_symbol")]
        public string V_local_currency_symbol { get; set; }

        [JsonProperty(PropertyName = "ticker")]
        public string V_ticker { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string V_title { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public string V_columns { get; set; }

        [NotMapped]
        public string[] V_columnsValues { get { return V_columns.Split(','); } set { V_columns = string.Join(", ", value); } }
    }
    public class mf_searchresults
    {
        [JsonProperty(PropertyName = "exchange")]
        public string V_exchange { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string V_id { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public string V_is_active { get; set; }

        [JsonProperty(PropertyName = "is_supported_exchange")]
        public string V_is_supported_exchange { get; set; }

        [JsonProperty(PropertyName = "local_currency_symbol")]
        public string V_local_currency_symbol { get; set; }

        [JsonProperty(PropertyName = "ticker")]
        public string V_ticker { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string V_title { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public string V_columns { get; set; }

        [NotMapped]
        public string[] V_columnsValues { get { return V_columns.Split(','); } set { V_columns = string.Join(", ", value); } }
    }
    public class managers
    {
        [JsonProperty(PropertyName = "familyname")]
        public string V_familyname { get; set; }

        [JsonProperty(PropertyName = "givenname")]
        public string V_givenname { get; set; }

        [JsonProperty(PropertyName = "startdate")]
        public string V_startdate { get; set; }
    }
    public class advisors
    {
        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }
    }
    public class purchaseinfo
    {
        [JsonProperty(PropertyName = "additional")]
        public string V_additional { get; set; }

        [JsonProperty(PropertyName = "address1")]
        public string V_address1 { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string V_address2 { get; set; }

        [JsonProperty(PropertyName = "address3")]
        public string V_address3 { get; set; }

        [JsonProperty(PropertyName = "address4")]
        public string V_address4 { get; set; }

        [JsonProperty(PropertyName = "aipadditional")]
        public string V_aipadditional { get; set; }

        [JsonProperty(PropertyName = "aipinitial")]
        public string V_aipinitial { get; set; }

        [JsonProperty(PropertyName = "fax")]
        public string V_fax { get; set; }

        [JsonProperty(PropertyName = "homepage")]
        public string V_homepage { get; set; }

        [JsonProperty(PropertyName = "initial")]
        public string V_initial { get; set; }

        [JsonProperty(PropertyName = "iraadditional")]
        public string V_iraadditional { get; set; }

        [JsonProperty(PropertyName = "irainitial")]
        public string V_irainitial { get; set; }

        [JsonProperty(PropertyName = "brokerageavailability")]
        public Collection<brokerageavailability> V_brokerageavailabilityArray { get; set; }
    }
    public class brokerageavailability
    {
        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }
    }
    public class keystatistics
    {
        [JsonProperty(PropertyName = "aabonds")]
        public string V_aabonds { get; set; }

        [JsonProperty(PropertyName = "aacash")]
        public string V_aacash { get; set; }

        [JsonProperty(PropertyName = "aaconvertible")]
        public string V_aaconvertible { get; set; }

        [JsonProperty(PropertyName = "aaother")]
        public string V_aaother { get; set; }

        [JsonProperty(PropertyName = "aapreferred")]
        public string V_aapreferred { get; set; }

        [JsonProperty(PropertyName = "aastocks")]
        public string V_aastocks { get; set; }

        [JsonProperty(PropertyName = "deferredload")]
        public string V_deferredload { get; set; }

        [JsonProperty(PropertyName = "expenseratio")]
        public string V_expenseratio { get; set; }

        [JsonProperty(PropertyName = "frontlaod")]
        public string V_frontlaod { get; set; }

        [JsonProperty(PropertyName = "fundfamily")]
        public string V_fundfamily { get; set; }

        [JsonProperty(PropertyName = "morningstarcategory")]
        public string V_morningstarcategory { get; set; }

        [JsonProperty(PropertyName = "morningstarrating")]
        public string V_morningstarrating { get; set; }

        [JsonProperty(PropertyName = "totalassets")]
        public string V_totalassets { get; set; }
    }
    public class performance
    {
        [JsonProperty(PropertyName = "ann5yret")]
        public string V_ann5yret { get; set; }

        [JsonProperty(PropertyName = "asof")]
        public string V_asof { get; set; }

        [JsonProperty(PropertyName = "best3monthret")]
        public string V_best3monthret { get; set; }

        [JsonProperty(PropertyName = "ttr1day")]
        public string V_ttr1day { get; set; }

        [JsonProperty(PropertyName = "ttr1week")]
        public string V_ttr1week { get; set; }

        [JsonProperty(PropertyName = "ttr1year")]
        public string V_ttr1year { get; set; }

        [JsonProperty(PropertyName = "ttr3month")]
        public string V_ttr3month { get; set; }

        [JsonProperty(PropertyName = "ttr3yearann")]
        public string V_ttr3yearann { get; set; }

        [JsonProperty(PropertyName = "ttr4week")]
        public string V_ttr4week { get; set; }

        [JsonProperty(PropertyName = "ttr5yearann")]
        public string V_ttr5yearann { get; set; }

        [JsonProperty(PropertyName = "ttrytd")]
        public string V_ttrytd { get; set; }

        [JsonProperty(PropertyName = "worst3monthret")]
        public string V_worst3monthret { get; set; }

        [JsonProperty(PropertyName = "ytdret")]
        public string V_ytdret { get; set; }
    }
    public class risk
    {
        [JsonProperty(PropertyName = "alpha")]
        public Collection<alpha> V_alphaArray { get; set; }

        [JsonProperty(PropertyName = "beta")]
        public Collection<beta> V_betaArray { get; set; }

        [JsonProperty(PropertyName = "meanannualreturn")]
        public Collection<meanannualreturn> V_meanannualreturnArray { get; set; }

        [JsonProperty(PropertyName = "rsquared")]
        public Collection<rsquared> V_rsquaredArray { get; set; }

        [JsonProperty(PropertyName = "sharperatio")]
        public Collection<sharperatio> V_sharperatioArray { get; set; }

        [JsonProperty(PropertyName = "stddev")]
        public Collection<stddev> V_stddevArray { get; set; }
    }
    public class alpha
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class beta
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class meanannualreturn
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class rsquared
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class stddev
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class sharperatio
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "3y")]
        public string V_3y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }
    }
    public class rating
    {
        [JsonProperty(PropertyName = "morningstarrating")]
        public Collection<morningstarrating> V_morningstarratingArray { get; set; }

        [JsonProperty(PropertyName = "morningstarreturn")]
        public Collection<morningstarreturn> V_morningstarreturnArray { get; set; }

        [JsonProperty(PropertyName = "morningstarrisk")]
        public Collection<morningstarrisk> V_morningstarriskArray { get; set; }
    }
    public class morningstarreturn
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }

        [JsonProperty(PropertyName = "overall")]
        public string V_overall { get; set; }
    }
    public class morningstarrisk
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }

        [JsonProperty(PropertyName = "overall")]
        public string V_overall { get; set; }
    }
    public class morningstarrating
    {
        [JsonProperty(PropertyName = "10y")]
        public string V_10y { get; set; }

        [JsonProperty(PropertyName = "1y")]
        public string V_1y { get; set; }

        [JsonProperty(PropertyName = "5y")]
        public string V_5y { get; set; }

        [JsonProperty(PropertyName = "overall")]
        public string V_overall { get; set; }
    }
    public class topholdings
    {
        [JsonProperty(PropertyName = "name")]
        public string V_name { get; set; }

        [JsonProperty(PropertyName = "t")]
        public string V_t { get; set; }

        [JsonProperty(PropertyName = "weighting")]
        public string V_weighting { get; set; }
    }


}
