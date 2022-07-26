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

        [Export("initWithFrame:")]
        public VerticalCollectionViewCell(CGRect frame) : base(frame)
        {

           
        }

        public void SetReviewCell(ReviewSection reviewSection)
        {
            UICollectionViewFlowLayout flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(100, 100),
                SectionInset = new UIEdgeInsets(20, 20, 20, 20),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 50, // minimum spacing between cells
                MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            CGRect collectionFrame = new CGRect(0, 0, ContentView.Frame.Width, 300);

            reviewCollection = new UICollectionView(collectionFrame, flowLayout);

            reviewCollection.RegisterClassForCell(typeof(ReviewHorizontalCollectionViewCell), ReviewHorizontalCollectionViewCell.Key);

            reviewCollection.BackgroundColor = UIColor.Red;

            ContentView.AddSubview(reviewCollection);

            ContentView.BackgroundColor = UIColor.Gray;

            reviewCollection.DataSource = new ReviewHorizontalCollectionDataSource(reviewSection.Reviews);
        }


        public void SetDoctorCell(DoctorSection doctorSection)
        {
            UICollectionViewFlowLayout flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(100, 100),
                SectionInset = new UIEdgeInsets(20, 20, 20, 20),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 50, // minimum spacing between cells
                MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            CGRect collectionFrame = new CGRect(0, 0, ContentView.Frame.Width, 300);

            doctorCollection = new UICollectionView(collectionFrame, flowLayout);

            doctorCollection.RegisterClassForCell(typeof(DorctoHorizontalCollectionViewCell), DorctoHorizontalCollectionViewCell.Key);

            doctorCollection.BackgroundColor = UIColor.Red;

            ContentView.AddSubview(doctorCollection);

            ContentView.BackgroundColor = UIColor.Gray;

            doctorCollection.DataSource = new DoctorHorizontalCollectionDataSource(doctorSection.Doctors);
        }
    }
}
