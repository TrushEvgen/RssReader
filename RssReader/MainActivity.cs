using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.Collections.Generic;

namespace RssReader
{
    [Activity(Label = "RssReader", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView listViewData;
        List<ContentListClass> ContentList;
        List<RssObject> AutoRssList = new List<RssObject>();
        List<RssObject> PeopleRssList = new List<RssObject>();//https://people.onliner.by/feed
        List<RssObject> TechRssList = new List<RssObject>(); //https://tech.onliner.by/feed
        List<RssObject> RealtRssList = new List<RssObject>();//https://realt.onliner.by/feed
        int listPosition = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ContentList = new List<ContentListClass>()
            {
                new ContentListClass() {Name = "Люди",rssObject = PeopleRssList},
                new ContentListClass() {Name = "Авто",rssObject = AutoRssList},
                new ContentListClass() {Name = "Технологии",rssObject = TechRssList},
                new ContentListClass() {Name = "Недвижимость",rssObject = RealtRssList}
            };
            AutoRssList.AddRange(new RssReader().ReadRss(@"https://auto.onliner.by/feed"));
            listViewData = FindViewById<ListView>(Resource.Id.listView1);

            LoadData(listPosition);
            PeopleRssList.AddRange(new RssReader().ReadRss(@"https://people.onliner.by/feed"));
            TechRssList.AddRange(new RssReader().ReadRss(@"https://tech.onliner.by/feed"));
            RealtRssList.AddRange(new RssReader().ReadRss(@"https://realt.onliner.by/feed"));

            FindViewById<Button>(Resource.Id.button1).Click += delegate {
                LoadData(listPosition-1);
                    };
            FindViewById<Button>(Resource.Id.button2).Click += delegate { LoadData(listPosition+1); };
        }

        private void LoadData(int position)
        {
            var rssList = ContentList[position].rssObject;
            string backButton = null;
            backButton = (position - 1 >= 0) ?  (ContentList[position - 1].Name) : null;
            FindViewById<Button>(Resource.Id.button1).Text = backButton;
            FindViewById<Button>(Resource.Id.button1).Enabled = backButton != null;

            FindViewById<TextView>(Resource.Id.textView1).Text = ContentList[position].Name;

            string forward = (position + 1 <= (ContentList.Count - 1)) ? ContentList[position + 1].Name : null;


            FindViewById<Button>(Resource.Id.button2).Text = forward;
            FindViewById<Button>(Resource.Id.button2).Enabled = forward != null;

            var adapter = new Adapters.RssListViewAdapter(this, rssList);
            listViewData.Adapter = adapter;
            listPosition = position;
        }
    }

    public class ContentListClass
    {
        public string Name;
        public List<RssObject> rssObject;
    }
}

