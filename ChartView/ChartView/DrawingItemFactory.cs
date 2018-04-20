using System;
using CoreGraphics;

namespace ChartView
{
    public enum ItemType
    {
        Left,Center,Right,Rest
    }

    public class DrawingItemFactory
    {
        private CGPoint _pointCenter = new CGPoint(0,0);
        private nfloat _radiusLargeCirle = 20f;
        private nfloat _radiusSmallCirle = 10f;

        public void SetPointCenter(CGPoint point)
        {
            _pointCenter = point;
        }

        public void SetLargeRadius(nfloat largeRadius)
        {
            _radiusLargeCirle = largeRadius;
        }

        public void SetSmallRadius(nfloat smallRadius)
        {
            _radiusSmallCirle = smallRadius;
        }

        public UIKit.UIBezierPath CreatPathOfItem(ItemType type)
        {
            DrawingItem item=null;
            switch(type)
            {
                case ItemType.Center:
                    item = new DrawingItem(Constant.CENTER_ITEM_POINT_TOP_LEFT, Constant.CENTER_ITEM_POINT_TOP_RIGHT, Constant.CENTER_ITEM_POINT_BOTTOM_LEFT, Constant.CENTER_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Left:
                    item = new DrawingItem(Constant.LEFT_ITEM_POINT_TOP_LEFT, Constant.LEFT_ITEM_POINT_TOP_RIGHT, Constant.LEFT_ITEM_POINT_BOTTOM_LEFT, Constant.LEFT_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Right:
                    item = new DrawingItem(Constant.RIGHT_ITEM_POINT_TOP_LEFT, Constant.RIGHT_ITEM_POINT_TOP_RIGHT, Constant.RIGHT_ITEM_POINT_BOTTOM_LEFT, Constant.RIGHT_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Rest:
                    item = new DrawingItem(Constant.REST_OF_CIRCLE_POINT_TOP_RIGHT, Constant.REST_OF_CIRCLE_POINT_TOP_LEFT, Constant.REST_OF_CIRCLE_POINT_BOTTOM_RIGHT, Constant.REST_OF_CIRCLE_POINT_BOTTOM_LEFT);
                    break;
                default:
                    
                    break;
            }
            item?.SetPointCenter(_pointCenter);
            item?.SetLargeRadius(_radiusLargeCirle);
            item?.SetSmallRadius(_radiusSmallCirle);

            return item?.GetPath();
        }

        public UIKit.UIBezierPath CreatPathTransitionOfItem(ItemType type)
        {
            DrawingItem item = null;
            switch (type)
            {
                case ItemType.Center:
                    item = new DrawingItem(Constant.CENTER_ITEM_POINT_TOP_LEFT, Constant.CENTER_ITEM_POINT_TOP_RIGHT, Constant.CENTER_ITEM_POINT_BOTTOM_LEFT, Constant.CENTER_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Left:
                    item = new DrawingItem(Constant.LEFT_ITEM_POINT_TOP_LEFT, Constant.LEFT_ITEM_POINT_TOP_RIGHT, Constant.LEFT_ITEM_POINT_BOTTOM_LEFT, Constant.LEFT_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Right:
                    item = new DrawingItem(Constant.RIGHT_ITEM_POINT_TOP_LEFT, Constant.RIGHT_ITEM_POINT_TOP_RIGHT, Constant.RIGHT_ITEM_POINT_BOTTOM_LEFT, Constant.RIGHT_ITEM_POINT_BOTTOM_RIGHT);
                    break;
                case ItemType.Rest:
                    item = new DrawingItem(Constant.REST_OF_CIRCLE_POINT_TOP_RIGHT, Constant.REST_OF_CIRCLE_POINT_TOP_LEFT, Constant.REST_OF_CIRCLE_POINT_BOTTOM_RIGHT, Constant.REST_OF_CIRCLE_POINT_BOTTOM_LEFT);
                    break;
                default:

                    break;
            }
            item?.SetPointCenter(_pointCenter);
            item?.SetLargeRadius(_radiusLargeCirle+50);
            item?.SetSmallRadius(_radiusSmallCirle);

            return item?.GetPathTransition();
        }
    }
}
