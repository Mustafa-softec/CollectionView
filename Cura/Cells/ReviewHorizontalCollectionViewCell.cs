using CoreGraphics;
using Foundation;
using UIKit;

namespace Cura.Cells
{
    public class ReviewHorizontalCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("ReviewHorizontalCollectionViewCell");

        UIImageView imageView;
        UILabel labelView;

        [Export("initWithFrame:")]
        public ReviewHorizontalCollectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;
            ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            imageView = new UIImageView(UIImage.FromBundle("placeholder.png"));
            imageView.Center = ContentView.Center;
            imageView.Transform = CGAffineTransform.MakeScale(0.7f, 0.7f);

            labelView = new UILabel(new CGRect(0, 0, 60, 30));

            labelView.Text = "Review................";

            labelView.TextColor = UIColor.Blue;

            ContentView.AddSubview(labelView);
            ContentView.AddSubview(imageView);

        }
    }
}
