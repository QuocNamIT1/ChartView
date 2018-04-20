using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace ChartView
{
    public class ItemShapeLayerFactory
    {
        private CGPoint _pointCenter = new CGPoint(0, 0);
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

        public ItemShapeLayer CreateLayer(ItemType type,int data = 0)
        {
            var layer=new ItemShapeLayer(type);
            layer?.SetPointCenter(_pointCenter);
            layer?.SetLargeRadius(_radiusLargeCirle);
            layer?.SetSmallRadius(_radiusSmallCirle);
            layer.Render(0);
           
            //layer.StrokeColor= new CGColor(132, 232, 0);
            return layer;
        }
    }
}
