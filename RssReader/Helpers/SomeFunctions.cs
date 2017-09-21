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

namespace RssReader.Helpers
{
    public static class SomeFunctions
    {
        public static DateTime DateTimeParse(this string value)
        {
            DateTime retDt;
            if (!DateTime.TryParse(value, out retDt))
                retDt = DateTime.MinValue;

            return retDt;
        }
    }
}