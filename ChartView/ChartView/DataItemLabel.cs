using System;
using CoreGraphics;
using UIKit;

namespace ChartView
{
    public class DataItemLabel : UILabel
    {
        private static double INCLINED_LEFT = -Constant.M_PI / 4;
        private static double INCLINED_RIGHT = (Constant.M_PI / 4);

        private ItemType _type;

        public DataItemLabel(ItemType type):base()
        {
            _type = type;
            this.Font = UIFont.FromName("Helvetica-Bold", size: 12);
            this.Text = "Hello";
            this.TextColor = UIColor.Red;
			SetPosition();
            SetTransform();
        }

        private void SetPosition()
        {
            switch (_type)
            {
                case ItemType.Left:
                    this.Frame = new CGRect(60, 100, 40, 40);
                    break;
                case ItemType.Right:
                    this.Frame = new CGRect(260, 100, 40, 40);
                    break;
                case ItemType.Center:
                    this.Frame = new CGRect(160, 120, 40, 40);
                    break;
                default:
                    break;
            }
        }

        private void SetTransform()
        {
            switch (_type)  
            {
                case ItemType.Left:
                    this.Transform = CGAffineTransform.MakeRotation((nfloat)INCLINED_LEFT);
                    break;
                case ItemType.Right:
                    this.Transform = CGAffineTransform.MakeRotation((nfloat)INCLINED_RIGHT);
                    break;
                default:
                    break;
            }
        }

        public void Transition()
        {
            //UIView.Animate(2, () =>{
            //    this.Transform = CGAffineTransform.MakeRotation((nfloat)INCLINED_RIGHT);
            //});
           
        }
    }
}
