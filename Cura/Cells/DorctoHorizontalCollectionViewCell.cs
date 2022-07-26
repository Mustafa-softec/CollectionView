using CoreGraphics;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura.Cells
{
    public class DorctoHorizontalCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("DorctoHorizontalCollectionViewCell");

        UIImageView imageView;
        UILabel labelName;
        UILabel labelDegree;
        UILabel labelSpecialization;
        UILabel labelCount;

        [Export("initWithFrame:")]
        public DorctoHorizontalCollectionViewCell(CGRect frame) : base(frame)
        {
           //width 280 & height = 120

           // ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
           // ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;
            //ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            imageView = new UIImageView(UIImage.FromBundle("placeholder.png"));
            imageView.Center = ContentView.Center;
            //imageView.Transform = CGAffineTransform.MakeScale(0.7f, 0.7f);
            imageView.Frame = new CGRect(0, 0, 100, 100);

            labelName = new UILabel(new CGRect(100, 5, 180, 22));
            labelName.TextColor = UIColor.Black;

            labelSpecialization = new UILabel(new CGRect(100, 27, 180, 22));
            labelSpecialization.TextColor = UIColor.LightGray;

            labelDegree = new UILabel(new CGRect(100, 56, 80, 22));
            labelDegree.BackgroundColor = UIColor.FromRGB(240,237,240);
            labelDegree.Font = labelDegree.Font.WithSize(12);
            labelDegree.TextColor = UIColor.Black;
            labelDegree.TextAlignment = UITextAlignment.Center;

            UIImageView starsImg = new UIImageView(UIImage.FromBundle("Images/ic_stars.png"));
            //starsImg.Center = ContentView.Center;
            starsImg.Frame = new CGRect(100, 85, 100, 30);

            labelCount = new UILabel(new CGRect(200, 92, 60, 22));
            labelCount.TextColor = UIColor.Black;
            labelCount.Font = UIFont.BoldSystemFontOfSize(12);//labelCount.Font.WithSize(12);


            UIImageView arrowImg = new UIImageView(UIImage.FromBundle("Images/ic_arrow.png"));
            arrowImg.Frame = new CGRect(240, 40, 30, 30);
            arrowImg.ContentMode = UIViewContentMode.ScaleAspectFit;

            ContentView.AddSubview(labelName);
            ContentView.AddSubview(labelSpecialization);
            ContentView.AddSubview(labelDegree);
            ContentView.AddSubview(starsImg);
            ContentView.AddSubview(labelCount);
            ContentView.AddSubview(arrowImg);
            ContentView.AddSubview(imageView);

        }

        public void FillData(Doctor doctor)
        {
            labelName.Text = doctor.Name;
            labelDegree.Text = doctor.Degree;
            labelSpecialization.Text = doctor.Specialization;

            labelCount.Text = $"{doctor.ReviewsCount} Reviews";

            imageView.Image = UIImage.FromBundle(doctor.Image);
        }
    }
}
