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
    public class Pref
    {
        #region プロパティ
        public string PrefName { get; private set; }

        public List<Region> Regions { get; set; }
        #endregion

        #region コンストラクタ
        public Pref(string name)
        {
            this.PrefName = name;
            this.Regions = new List<Region>();
        }
        #endregion
    }
}