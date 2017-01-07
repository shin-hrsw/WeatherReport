using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WeatherReport
{
    [Activity(Label = "WeatherReport", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView lv;
        private List<Model.Pref> pref_list;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // メイン画面は県の情報を表示する
            SetContentView(Resource.Layout.Main);
            this.lv = FindViewById<ListView>(Resource.Id.PrefList);

            CreatePrefList();
        }

        #region メソッド(private)
        private void CreatePrefList()
        {
            this.pref_list = new List<Model.Pref>();

            var area = RequestPrimaryArea().Result;

            var xml = XDocument.Parse(area);
            var pref_query = xml.Descendants("pref");
            foreach(var p in pref_query)
            {
                var pr = new Model.Pref(p.Attributes("title").First().Value);
                foreach(var c in p.Descendants("city"))
                {
                    string name = c.Attributes("title").First().Value;
                    string id = c.Attributes("id").First().Value;
                    pr.Regions.Add(new Model.Region(name, id));
                }
                this.pref_list.Add(pr);
            }

            this.lv.Adapter = new Adapter.PrefAdapter(this, pref_list);
        }

        private async Task<string> RequestPrimaryArea()
        {
            // ライブドアのお天気Webサービスから全国の地点定義表
            // (http://weather.livedoor.com/forecast/rss/primary_area.xml)を取得
            var client = new HttpClient();
            return await client.GetStringAsync("http://weather.livedoor.com/forecast/rss/primary_area.xml")
                .ConfigureAwait(false);
        }
        #endregion
    }
}

