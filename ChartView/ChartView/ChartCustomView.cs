using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ChartView
{
    [Register("ChartCustomView")]
    public class ChartCustomView : UIView
    {

        private ItemShapeLayer _centerItemLayer, _rightItemLayer, _leftItemLayer, _restOfChartLayer;
        private ItemShapeLayerFactory _layerFactory;
        bool reDraw = false;
        public ChartCustomView(IntPtr handle) : base(handle)
        {
            Init();
        }

        public ChartCustomView() : base()
        {
            Init();
        }

        private void Init()
        {
            this.ClipsToBounds = true;

            _layerFactory = new ItemShapeLayerFactory();
            _layerFactory.SetPointCenter(new CGPoint(Frame.Width / 2, Frame.Height + 50));
            _layerFactory.SetLargeRadius((nfloat)Math.Sqrt(Math.Pow(Frame.Width / 2, 2) + Math.Pow(50, 2)));
            _layerFactory.SetSmallRadius(100f);

            _centerItemLayer = _layerFactory.CreateLayer(ItemType.Center);
            _rightItemLayer = _layerFactory.CreateLayer(ItemType.Right);
            _leftItemLayer = _layerFactory.CreateLayer(ItemType.Left);
            _restOfChartLayer = _layerFactory.CreateLayer(ItemType.Rest);

            this.Layer.AddSublayer(_centerItemLayer);
            this.Layer.AddSublayer(_rightItemLayer);
            this.Layer.AddSublayer(_leftItemLayer);
            this.Layer.AddSublayer(_restOfChartLayer);
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            var context = UIGraphics.GetCurrentContext();
            //if (!reDraw)
            //{
            //    _centerItemLayer.Path = _itemFactory.CreatPathOfItem(ItemType.Center).CGPath;

            //    _rightItemLayer.Path = _itemFactory.CreatPathOfItem(ItemType.Right).CGPath;
            //    _leftItemLayer.Path = _itemFactory.CreatPathOfItem(ItemType.Left).CGPath;
            //    _restOfChartLayer.Path = _itemFactory.CreatPathOfItem(ItemType.Rest).CGPath;
            //}
            //else
            //{
            //    _leftItemLayer.Path = _itemFactory.CreatPathOfItem(ItemType.Left).CGPath;
            //    _leftItemLayer.FillColor = Constant.CenterItemBackground;
            //}

        }



        public void SelectItem()
        {
            
            _centerItemLayer.TransitionToLeft();
            _leftItemLayer.TransitionToLeft();
            _rightItemLayer.TransitionToLeft();
        }
    }
}
