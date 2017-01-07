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
    public class RegionAdapter : BaseAdapter<Model.Region>
    {
        private Activity context;
        private List<Region> region_list;

        #region コンストラクタ
        public RegionAdapter(Activity contex, List<Region> regions)
        {
            this.context = contex;
            this.region_list = regions;
        }
        #endregion

        #region 抽象メソッドの実装
        public override Region this[int position]
        {
            get { return this.region_list[position]; }
        }

        public override int Count
        {
            get { return this.region_list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.region_list[position];
            var vi = convertView;
            if(vi == null)
            {
                vi = this.context.LayoutInflater.Inflate(Resource.Layout.RegionRow, null);
            }
            vi.FindViewById<TextView>(Resource.Id.RegionName).Text = item.RegionName;

            return vi;
        }
        #endregion
    }
}