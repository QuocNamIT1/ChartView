using System;
using CoreGraphics;
using UIKit;
namespace ChartView
{
    public class DrawingItem
    {
        private double _topLeftPoint, _topRightPoint, _bottomLeftPoint, _bottomRightPoint;
        private CGPoint _pointCenter;
        private nfloat _radiusLargeCirle;
        private nfloat _radiusSmallCirle;

        public DrawingItem(double topLeft, double topRight, double botLeft, double botRight)
        {
            _topLeftPoint = topLeft;
            _topRightPoint = topRight;
            _bottomLeftPoint = botLeft;
            _bottomRightPoint = botRight;
        }

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

        public UIBezierPath GetPath()
        {
            var path = new UIBezierPath();

            var point1 = GetPointFromRadian(_radiusLargeCirle, _pointCenter, (nfloat)_topLeftPoint);
            var point2 = GetPointFromRadian(_radiusLargeCirle, _pointCenter, (nfloat)_topRightPoint);
            var point3 = GetPointFromRadian(_radiusSmallCirle, _pointCenter, (nfloat)_bottomLeftPoint);
            var point4 = GetPointFromRadian(_radiusSmallCirle, _pointCenter, (nfloat)_bottomRightPoint);
            path.AddArc(_pointCenter, (nfloat)_radiusLargeCirle, (nfloat)_topLeftPoint, (nfloat)_topRightPoint, true);
            path.AddLineTo(point4);
            path.AddArc(_pointCenter, (nfloat)_radiusSmallCirle, (nfloat)_bottomRightPoint, (nfloat)_bottomLeftPoint, false);
            path.AddLineTo(point1);
            path.ClosePath();
            return path;
        }

        public UIBezierPath GetPathTransition()
        {
            var path = new UIBezierPath();

            path.AddArc(_pointCenter, (nfloat)_radiusLargeCirle, (nfloat)_topRightPoint, (nfloat)_topLeftPoint, false);
            path.ClosePath();
            return path;
        }

        private static CGPoint GetPointFromRadian(double radius, CGPoint pointCenter, nfloat radian)
        {
            CGPoint point = new CGPoint();

            point.X = (nfloat)(Math.Cos(radian) * radius + pointCenter.X);
            point.Y = (nfloat)(Math.Sin(radian) * radius + pointCenter.Y);

            return point;
        }
    }
}
