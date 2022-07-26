using System;
using System.Collections.Generic;
using CoreGraphics;
using Cura.Adapters;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura.Cells
{
    public class VerticalCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("VerticalCollectionViewCell");

        UICollectionView reviewCollection;
        UICollectionView doctorCollection;
        UILabel labelTitle;

        [Export("initWithFrame:")]
        public VerticalCollectionViewCell(CGRect frame) : base(frame)
        {

           
        }

        public void SetReviewCell(ReviewSection reviewSection)
        {
            labelTitle = new UILabel(new CGRect(0, 0, 250, 50));
            labelTitle.Font = UIFont.BoldSystemFontOfSize(16);
            labelTitle.TextColor = UIColor.Black;
            labelTitle.Text = reviewSection.Title;
            labelTitle.Lines = 0;
            //labelTitle.BackgroundColor = UIColor.Yellow;

            ContentView.AddSubview(labelTitle);



            UICollectionViewFlowLayout flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(100, 100),
                SectionInset = new UIEdgeInsets(20, 20, 20, 20),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 50, // minimum spacing between cells
                MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            CGRect collectionFrame = new CGRect(0, 50, ContentView.Frame.Width, 300);

            reviewCollection = new UICollectionView(collectionFrame, flowLayout);

            reviewCollection.RegisterClassForCell(typeof(ReviewHorizontalCollectionViewCell), ReviewHorizontalCollectionViewCell.Key);

            reviewCollection.BackgroundColor = UIColor.White;

            ContentView.AddSubview(reviewCollection);

            ContentView.BackgroundColor = UIColor.White;

            reviewCollection.DataSource = new ReviewHorizontalCollectionDataSource(reviewSection.Reviews);
        }


        public void SetDoctorCell(DoctorSection doctorSection)
        {

            labelTitle = new UILabel(new CGRect(0, 0,290, 50));
            labelTitle.Font = UIFont.BoldSystemFontOfSize(16);
            labelTitle.TextColor = UIColor.Black;
            labelTitle.Text = doctorSection.Title;
            labelTitle.Lines = 0;
            //labelTitle.BackgroundColor = UIColor.Yellow;

            ContentView.AddSubview(labelTitle);


            UILabel labelAll = new UILabel(new CGRect(270,20 , 50, 30));
            labelAll.Font = UIFont.SystemFontOfSize(12);
            labelAll.TextColor = UIColor.FromRGB(58,194,224);
            labelAll.Text = "See All";
            ContentView.AddSubview(labelAll);

            UICollectionViewFlowLayout flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(280, 120),
                SectionInset = new UIEdgeInsets(10, 10, 10, 10),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 20, // minimum spacing between cells
                MinimumLineSpacing = 20 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            CGRect collectionFrame = new CGRect(0, 50, ContentView.Frame.Width, 280);

            doctorCollection = new UICollectionView(collectionFrame, flowLayout);

            doctorCollection.RegisterClassForCell(typeof(DorctoHorizontalCollectionViewCell), DorctoHorizontalCollectionViewCell.Key);

            doctorCollection.BackgroundColor = UIColor.White;

            ContentView.AddSubview(doctorCollection);

            ContentView.BackgroundColor = UIColor.White;

            doctorCollection.DataSource = new DoctorHorizontalCollectionDataSource(doctorSection.Doctors);
        }
    }
}
