using System;
using CoreGraphics;
using UIKit;

namespace ChartView
{
    public class Constant
    {
        public static double M_PI = 3.14159265f;

        public static double CENTER_ITEM_POINT_TOP_LEFT = M_PI * 1.35f;
        public static double CENTER_ITEM_POINT_TOP_RIGHT = M_PI * 1.65f;
        public static double CENTER_ITEM_POINT_BOTTOM_LEFT = M_PI * 1.39f;
        public static double CENTER_ITEM_POINT_BOTTOM_RIGHT = M_PI * 1.61f;


        public static double LEFT_ITEM_POINT_TOP_LEFT = M_PI * 1.12f;
        public static double LEFT_ITEM_POINT_TOP_RIGHT = M_PI * 1.35f;
        public static double LEFT_ITEM_POINT_BOTTOM_LEFT = M_PI * 1.12f;
        public static double LEFT_ITEM_POINT_BOTTOM_RIGHT = M_PI * 1.39f;

        public static double RIGHT_ITEM_POINT_TOP_LEFT = M_PI * 1.65f;
        public static double RIGHT_ITEM_POINT_TOP_RIGHT = M_PI * 1.88f;
        public static double RIGHT_ITEM_POINT_BOTTOM_LEFT = M_PI * 1.61f;
        public static double RIGHT_ITEM_POINT_BOTTOM_RIGHT = M_PI * 1.88f;

        public static double REST_OF_CIRCLE_POINT_TOP_LEFT = M_PI * 1.115f;
        public static double REST_OF_CIRCLE_POINT_TOP_RIGHT = M_PI * 1.885f;
        public static double REST_OF_CIRCLE_POINT_BOTTOM_LEFT = M_PI * 1.115f;
        public static double REST_OF_CIRCLE_POINT_BOTTOM_RIGHT = M_PI * 1.885f;

        public static CGColor CenterItemBackground =UIColor.FromRGB(96, 194, 216).CGColor;
        public static CGColor OtherItemBackground = UIColor.FromRGB(231, 231, 231).CGColor;
    }
}
