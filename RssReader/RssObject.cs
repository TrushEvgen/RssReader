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
using System.Xml.Linq;
using RssReader.Helpers;

namespace RssReader
{
    public class RssReader
    {
        readonly XNamespace dcNamespace = "{http://purl.org/dc/elements/1.1/}";
        public List<RssObject> ReadRss(string url)
        {
            var rssFeed = XDocument.Load(url);
            var posts = (from item in rssFeed.Descendants("item")
                         select new RssObject
                         {
                             Title = item.Element("title").Value,
                             Link = item.Element("link").Value,
                             PubDate = item.Element("pubDate").Value.DateTimeParse(),
                             Creator = item.Element($"{dcNamespace}creator").Value,
                            //Creator = item.Element("{http://purl.org/dc/elements/1.1/}creator").Value,
                            Category = item.Element("category").Value,
                            Description = item.Element("description").Value
                        }).ToList();

            return posts;
        }
    }
    public class RssObject
    {
        public string Title;
        public string Link;
        public DateTime PubDate;
        public string Creator;
        public string Category;
        public string Description;
        public string ImageUrl;
    }
}