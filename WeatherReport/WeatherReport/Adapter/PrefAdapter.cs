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
using WeatherReport.Model;

namespace WeatherReport.Adapter
{
    public class PrefAdapter : BaseAdapter<Model.Pref>
    {
        private Activity context;
        private List<Model.Pref> pref_list;

        #region コンストラクタ
        public PrefAdapter(Activity con, List<Model.Pref> list)
        {
            this.context = con;
            this.pref_list = list;
        }
        #endregion

        #region 抽象メソッドの実装
        public override Pref this[int position]
        {
            get { return this.pref_list[position]; }
        }

        public override int Count
        {
            get { return this.pref_list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var vi = convertView;
            var pref = this.pref_list[position];
            if(vi == null)
            {
                vi = this.context.LayoutInflater.Inflate(Resource.Layout.PrefRow, null);
            }
            vi.FindViewById<TextView>(Resource.Id.PrefName).Text = pref.PrefName;
            vi.FindViewById<TextView>(Resource.Id.RegionCount).Text = pref.Regions.Count + "都市";

            return vi;
        }
        #endregion
    }
}