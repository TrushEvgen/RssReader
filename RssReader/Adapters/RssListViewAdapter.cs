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
using Java.Lang;
using Android.Webkit;

namespace RssReader.Adapters
{
    class RssListViewAdapter : BaseAdapter
    {
        private Activity Activity;
        private List<RssObject> RssList;
        public RssListViewAdapter(Activity activity, List<RssObject> rssList)
        {
            Activity = activity;
            RssList = rssList;
        }

        public override int Count => RssList.Count;

        public override Java.Lang.Object GetItem(int position)
        {
           return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.RssViewDataTemplate, parent, false);
            var title = view.FindViewById<TextView>(Resource.Id.tvTitle);
            var pubDate = view.FindViewById<TextView>(Resource.Id.tvPubDate);
            var readMore = view.FindViewById<Button>(Resource.Id.btnReadMore);
            title.Text = RssList[position].Title;
            pubDate.Text = $"Дата публикаций:{RssList[position].PubDate.ToString("s")}";
            readMore.Click += delegate {
                var uri = Android.Net.Uri.Parse(RssList[position].Link); ;
                var intent = new Intent(Intent.ActionView, uri);
                Activity.StartActivity(intent);
            };
            
            //var name = view.FindViewById<TextView>(Resource.Id.tv_Name);
            //var phone = view.FindViewById<TextView>(Resource.Id.tv_phone);
            //name.Text = AccountList[position].Name;
            //phone.Text = AccountList[position].Phone;
            return view;

        }
    }

}