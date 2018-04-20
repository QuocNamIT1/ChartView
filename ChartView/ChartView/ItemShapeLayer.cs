using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace ChartView
{
    public class ItemShapeLayer : CAShapeLayer
    {
        private ItemType _type;
        private DrawingItemFactory _itemFactory;
        private UIBezierPath _path;
        private CGPoint _pointCenter = new CGPoint(0, 0);
        private nfloat _radiusLargeCirle = 20f;
        private nfloat _radiusSmallCirle = 10f;
        private DataItemLabel _label;
        private const int DURATION = 2;
        private static double INCLINED_LEFT = -Constant.M_PI / 4;
        private static double INCLINED_RIGHT = (Constant.M_PI / 4);
        private DrawingItem _centerItem, _leftItem, _rightItem;

        public ItemShapeLayer(ItemType type):base()
        {
            _type = type;
            SetBackgroundColor();
            _label = new DataItemLabel(_type);

            //this.AddSublayer(_label.Layer); 
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


        private void AddTextToLayer()
        {
            //var label = new DataItemLabel(_type);

            //this.AddSublayer(label.Layer); 

            var textLayer = new CATextLayer();
            textLayer.String = "Hello how are you?";
            //textLayer.Font = UIFont.F(ofSize: startFontSize, weight: UIFont.Weight.semibold);
            textLayer.FontSize = 15;
            //textLayer.AlignmentMode = kCAAlignmentLeft;
            textLayer.ForegroundColor = UIColor.Black.CGColor;
            textLayer.ContentsScale = UIScreen.MainScreen.Scale;
            //textLayer.IsWrapped = true;
                textLayer.BackgroundColor = UIColor.LightGray.CGColor;
            textLayer.AnchorPoint =new CGPoint(x: 0, y: 0);
            textLayer.Position = new CGPoint(40,100);
            //textLayer.Frame =new R(width: 450, height: 50);
            //this.AddSublayer();
        }

        public void Render(int data)
        {
            _itemFactory = new DrawingItemFactory();
            _itemFactory.SetPointCenter(_pointCenter);
            _itemFactory.SetLargeRadius(_radiusLargeCirle);
            _itemFactory.SetSmallRadius(_radiusSmallCirle);

            _path = _itemFactory.CreatPathOfItem(_type);
            this.Path = _path.CGPath;
            //AddTextToLayer();
        }

        private void SetBackgroundColor()
        {
            if(_type==ItemType.Center)
            {
                this.FillColor = Constant.CenterItemBackground;
            }
            else
            {
                this.FillColor = Constant.OtherItemBackground;
            }
        }

        private void TransitionLayer(UIBezierPath pathDestination, Action completeAction = null)
        {
            CATransaction.Begin();
            var keyFramAnimation = CAKeyFrameAnimation.FromKeyPath("position");
            keyFramAnimation.Path = _itemFactory.CreatPathTransitionOfItem(ItemType.Left).CGPath;

            var transitionTorightAnimation = CABasicAnimation.FromKeyPath("path");
            transitionTorightAnimation.SetFrom(_path.CGPath);
            transitionTorightAnimation.SetTo(pathDestination.CGPath);

			CATransaction.CompletionBlock = () =>
			{
                Render(0);
                this.DidChangeValue("path");
			};

            var groupAnimation = new CAAnimationGroup();
            groupAnimation.Duration = DURATION;
            groupAnimation.FillMode = CAFillMode.Forwards;
            groupAnimation.RemovedOnCompletion = false;
            //groupAnimation.AutoReverses = false;
            groupAnimation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.Linear);
            groupAnimation.Animations = new CAAnimation[] {  transitionTorightAnimation};
            this.AddAnimation(groupAnimation ,"transition");
            //UIView.Animate(2, () => {
            //    _label.Frame = new CGRect(260, 100, 40, 40);
            //    _label.Transform = CGAffineTransform.MakeRotation((nfloat)INCLINED_RIGHT);
            //});


        }

        public void TransitionToLeft()
        {
            
            switch(_type)
            {
                case ItemType.Center:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Left));
                    break;
                case ItemType.Left:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Rest));
                    break;
                case ItemType.Right:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Center));
                    break;
            }

        }

        public void LayoutIfNeed()
        {
        }

        public void TransitionToRight()
        {

            switch (_type)
            {
                case ItemType.Center:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Right));
                    break;
                case ItemType.Left:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Center));
                    break;
                case ItemType.Right:
                    TransitionLayer(_itemFactory.CreatPathOfItem(ItemType.Rest));
                    break;
            }

        }
    }
}
