using CoreGraphics;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura.Cells
{
    public class ReviewHorizontalCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("ReviewHorizontalCollectionViewCell");

        UIImageView dr_imageView;
        UILabel dr_labelName;
        UILabel dr_labelSpecialization;

        UIImageView pt_imageView;
        UILabel pt_labelName;
        UILabel pt_age;


        UILabel labelCount;
        UILabel labelComment;

        [Export("initWithFrame:")]
        public ReviewHorizontalCollectionViewCell(CGRect frame) : base(frame)
        {

            ContentView.Layer.BorderColor = UIColor.FromRGB(246, 244, 246).CGColor;
            ContentView.Layer.BorderWidth = 1.0f;
            ContentView.BackgroundColor = UIColor.White;
            ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);


            //comment........
            UIImageView comentImg = new UIImageView(UIImage.FromBundle("Images/co.png"));
            comentImg.Frame = new CGRect(100, 10, 50, 50);

            labelComment = new UILabel(new CGRect(150, 10, 200, 100));
            labelComment.TextColor = UIColor.Black;
            //labelComment.BackgroundColor = UIColor.Yellow;
            labelComment.Lines = 0;
            labelComment.Text = "one year ago";
            labelComment.Font = UIFont.SystemFontOfSize(22);

            UILabel labelDate = new UILabel(new CGRect(120, 124, 100, 22));
            labelDate.TextColor = UIColor.Black;
            labelDate.Text = "one year ago";
            labelDate.Font = UIFont.SystemFontOfSize(14);

            //doctor........
            UIView drView = DrawDoctorView();
            drView.Frame = new CGRect(120, 150, 220, 80);

            //PatientView........
            UIView ptView = DrawPatientView();
            ptView.Frame = new CGRect(0, 0, 100, 120);

            ContentView.AddSubview(ptView);
            ContentView.AddSubview(comentImg);
            ContentView.AddSubview(labelDate);
            ContentView.AddSubview(drView);
            ContentView.AddSubview(labelComment);


        }


        public void FillData(Review review)
        {
            labelComment.Text = review.Comment;

            dr_labelName.Text = review.Doctor.Name;
            dr_labelSpecialization.Text = review.Doctor.Specialization;
            labelCount.Text = $"{review.Doctor.ReviewsCount} Reviews";
            dr_imageView.Image = UIImage.FromBundle(review.Doctor.Image);

            pt_labelName.Text = review.Patient.Name;
            pt_age.Text = $"{review.Patient.Age} Years";
            pt_imageView.Image = UIImage.FromBundle(review.Patient.Image);
        }

        private UIView DrawDoctorView()
        {
            UIView drView = new UIView();

              //drView.BackgroundColor = UIColor.Green;

            dr_imageView = new UIImageView(UIImage.FromBundle("placeholder.png"));
            dr_imageView.Center = ContentView.Center;
            dr_imageView.Frame = new CGRect(0, 5, 70, 70);

            dr_labelName = new UILabel(new CGRect(70, 5, 100, 22));
            dr_labelName.TextColor = UIColor.Black;
            dr_labelName.Font = UIFont.BoldSystemFontOfSize(14);

            dr_labelSpecialization = new UILabel(new CGRect(70, 25, 100, 22));
            dr_labelSpecialization.TextColor = UIColor.LightGray;
            dr_labelSpecialization.Font = UIFont.SystemFontOfSize(12);

            UIImageView starsImg = new UIImageView(UIImage.FromBundle("Images/ic_stars.png"));
            starsImg.Frame = new CGRect(70, 45, 95, 26);

            labelCount = new UILabel(new CGRect(170, 48, 100, 22));
            labelCount.TextColor = UIColor.Black;
            labelCount.TextColor = UIColor.LightGray;
            labelCount.Font = UIFont.BoldSystemFontOfSize(12);//labelCount.Font.WithSize(12);


            drView.AddSubview(dr_imageView);
            drView.AddSubview(dr_labelName);
            drView.AddSubview(starsImg);
            drView.AddSubview(labelCount);
            drView.AddSubview(dr_labelSpecialization);

            return drView;
        }

        private UIView DrawPatientView()
        {
            UIView ptView = new UIView();

            //  drView.BackgroundColor = UIColor.Green;

            pt_imageView = new UIImageView(UIImage.FromBundle("placeholder.png"));
            pt_imageView.Center = ContentView.Center;
            pt_imageView.Frame = new CGRect(5, 5, 70, 70);

            pt_labelName = new UILabel(new CGRect(15, 80, 100, 22));
            pt_labelName.TextColor = UIColor.Black;
            pt_labelName.Font = UIFont.BoldSystemFontOfSize(14);

            pt_age = new UILabel(new CGRect(15, 105, 100, 22));
            pt_age.TextColor = UIColor.Black;
            pt_age.Font = UIFont.BoldSystemFontOfSize(14);

            ptView.AddSubview(pt_imageView);
            ptView.AddSubview(pt_labelName);
            ptView.AddSubview(pt_age);

            return ptView;
        }
    }
}
