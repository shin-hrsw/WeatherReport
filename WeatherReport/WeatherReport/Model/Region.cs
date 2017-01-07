using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherReport.Model
{
    public class Region
    {
        #region プロパティ
        public string RegionId { get; set; }

        public string RegionName { get; set; }
        #endregion

        #region コンストラクタ
        public Region(string name, string id)
        {
            this.RegionName = name;
            this.RegionId = id;
        }
        #endregion
    }
}