using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCBO_Scraper
{

    public class Page
    {
        public int status { get; set; }
        public object message { get; set; }
        public Pager pager { get; set; }
        public Result[] result { get; set; }
        public object suggestion { get; set; }
    }

    public class Pager
    {
        public int records_per_page { get; set; }
        public int total_record_count { get; set; }
        public int current_page_record_count { get; set; }
        public bool is_first_page { get; set; }
        public bool is_final_page { get; set; }
        public int current_page { get; set; }
        public string current_page_path { get; set; }
        public int next_page { get; set; }
        public string next_page_path { get; set; }
        public object previous_page { get; set; }
        public object previous_page_path { get; set; }
        public int total_pages { get; set; }
        public string total_pages_path { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public bool is_dead { get; set; }
        public string name { get; set; }
        public string tags { get; set; }
        public bool is_discontinued { get; set; }
        public int price_in_cents { get; set; }
        public int regular_price_in_cents { get; set; }
        public int limited_time_offer_savings_in_cents { get; set; }
        public string limited_time_offer_ends_on { get; set; }
        public int bonus_reward_miles { get; set; }
        public string bonus_reward_miles_ends_on { get; set; }
        public string stock_type { get; set; }
        public string primary_category { get; set; }
        public string secondary_category { get; set; }
        public string origin { get; set; }
        public string package { get; set; }
        public string package_unit_type { get; set; }
        public int package_unit_volume_in_milliliters { get; set; }
        public int total_package_units { get; set; }
        public int volume_in_milliliters { get; set; }
        public int alcohol_content { get; set; }
        public int price_per_liter_of_alcohol_in_cents { get; set; }
        public int price_per_liter_in_cents { get; set; }
        public int inventory_count { get; set; }
        public int inventory_volume_in_milliliters { get; set; }
        public int inventory_price_in_cents { get; set; }
        public object sugar_content { get; set; }
        public string producer_name { get; set; }
        public string released_on { get; set; }
        public bool has_value_added_promotion { get; set; }
        public bool has_limited_time_offer { get; set; }
        public bool has_bonus_reward_miles { get; set; }
        public bool is_seasonal { get; set; }
        public bool is_vqa { get; set; }
        public bool is_ocb { get; set; }
        public bool is_kosher { get; set; }
        public string value_added_promotion_description { get; set; }
        public object description { get; set; }
        public string serving_suggestion { get; set; }
        public string tasting_note { get; set; }
        public DateTime updated_at { get; set; }
        public string image_thumb_url { get; set; }
        public string image_url { get; set; }
        public string varietal { get; set; }
        public string style { get; set; }
        public string tertiary_category { get; set; }
        public int? sugar_in_grams_per_liter { get; set; }
        public int clearance_sale_savings_in_cents { get; set; }
        public bool has_clearance_sale { get; set; }
        public int product_no { get; set; }
    }

}
