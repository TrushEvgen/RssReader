//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.Graphics;
//using Android.Util;

//namespace RssReader
//{
//    class SlidingTabStrip : LinearLayout
//    {
//        private const int DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS = 2;
//        private const byte DEFAULT_BOTTOM_BORDER_COLOR_ALPHA = 0X26;
//        private const int SELECTED_INDICATION_THICKNESS_DIPS = 8;
//        private int[] INDICATOR_COLORS = { 0X19A319, 0x0000FC };
//        private int[] DIVIDER_COLORS = { 0xC5C5C5 };

//        private const int DEFAULT_DIVIDER_THICKNESS_DIPS = 1;
//        private const float DEFAULT_DIVIDER_HEIGHT = 0.5f;

//        //bottom border
//        private int mBottomBorderThickness;
//        private Paint mBottomBorderPaint;
//        private int mDefaultBottomBorderColor;
//        //indicator
//        private int mSelectedIndicatorThickness;
//        private Paint mSelectedIndicatorPaint;

//        //divider
//        private Paint mDividerPaint;
//        private float mDividerHeight;

//        //Selceted Position Offset
//        private int mSelectedPosition;
//        private float mSelectedOffset;

//        //tab colorizer
//        private SlidingTabScrollView.TabColorizer mCustomTAbColorizer;
//        private SimpleTabColorizer mDefaultTabColorizer;

//        public SlidingTabStrip(Context context) : this (context,null)
//        {

//        }

//        public SlidingTabStrip(Context context, IAttributeSet attributes) : base (context,attributes)
//        {
//            SetWillNotDraw(false);

//            float density = Resources.DisplayMetrics.Density;
//            TypedValue outValue = new TypedValue();
//            context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorForeground, outValue, true);
//            int themeForeGroud = outValue.Data;
//            mDefaultBottomBorderColor = SetCollorAlpha(themeForeGroud,DEFAULT_BOTTOM_BORDER_COLOR_ALPHA);

//            mDefaultTabColorizer = new SimpleTabColorizer();
//            mDefaultTabColorizer.SetIndicatorColors(INDICATOR_COLORS);
//            mDefaultTabColorizer.SetDividerColors(DIVIDER_COLORS);
//        }

//        private int SetCollorAlpha(int themeForeGroud, byte dEFAULT_BOTTOM_BORDER_COLOR_ALPHA)
//        {
//            throw new NotImplementedException();
//        }
//        private class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
//        {
//            private int[] mIndicatorColors;
//            private int[] mDividerColors;

//            public int GetIndicatorColor(int position)
//            {
//                return mIndicatorColors[position % mIndicatorColors.Length];
//            }

//            public int GetDividerColor(int position)
//            {
//                return mDividerColors[position % mDividerColors.Length];
//            }

//            public int[] IndicatorColors
//            {
//                set { mIndicatorColors = value; }
//            }
//            public int[] DividerColors
//            {
//                set { mDividerColors = value; }
//            }
//        }
//    }
//}