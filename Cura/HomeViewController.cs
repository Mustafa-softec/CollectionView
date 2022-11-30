using System;
using System.Collections.Generic;
using CoreGraphics;
using Cura.Cells;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura
{
    public class HomeViewController : UICollectionViewController//, IUISearchResultsUpdating, IUICollectionViewDelegateFlowLayout
    {
        //Home
        public List<ISection> HomeList { get; set; } = new List<ISection>();
        static NSString verticalCellId = new NSString("VerticalCollectionViewCell");

        public HomeViewController(UICollectionViewLayout layout) : base(layout)
        {
            FillHomeList();
        }

        

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(VerticalCollectionViewCell), verticalCellId);
        }


        #region Override Methods

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            // We only have one section
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            // Return the number of items
            return HomeList.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Get a reusable cell and set {~~it's~>its~~} title from the item
            var cell = collectionView.DequeueReusableCell(verticalCellId, indexPath) as VerticalCollectionViewCell;
            var section = HomeList[(int)indexPath.Item];
            if (section is ReviewSection reviewSection)
            {
                cell.SetReviewCell(reviewSection);
            }
            else if (section is DoctorSection doctorSection)
            {
                cell.SetDoctorCell(doctorSection);
            }

            return cell;
        }

        //public override CGSize GetSizeForChildContentContainer(IUIContentContainer contentContainer, CGSize parentContainerSize)
        //{
        //    return base.GetSizeForChildContentContainer(contentContainer, parentContainerSize);
        //}

        //[Export("collectionView:layout:sizeForItemAtIndexPath:")]
        //public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        //{
        //    return new CGSize(width: View.Frame.Width, height: 300);
        //}

        //[Export("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
        //public nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        //{
        //    return 0;
        //}
        #endregion

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        private void FillHomeList()
        {
            #region doctors
            Doctor d1 = new Doctor()
            {
                Name = "DR. Name 1",
                Image = "Images/d1.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 4
            };


            Doctor d2 = new Doctor()
            {
                Name = "DR. Name 2",
                Image = "Images/d2.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 7
            };



            Doctor d3 = new Doctor()
            {
                Name = "DR. Name 3",
                Image = "Images/d3.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 9
            };



            Doctor d4 = new Doctor()
            {
                Name = "DR. Name 4",
                Image = "Images/d4.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 8
            };

            Doctor d5 = new Doctor()
            {
                Name = "DR. Name 5",
                Image = "Images/d5.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 6
            };

            Doctor d6 = new Doctor()
            {
                Name = "DR. Name 6",
                Image = "Images/d6.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 5
            };


            Patient p1 = new Patient()
            {
                Name = "Noura",
                Image = "Images/u1.png",
                Age = 35
            };

            Patient p2 = new Patient()
            {

                Name = "محمد",
                Image = "Images/u2.png",
                Age = 23
            };

            Patient p3 = new Patient()
            {
                Name = "امل",
                Image = "Images/u1.png",
                Age = 44
            };
            #endregion
            
            #region reviws section
            ReviewSection reviewSection = new ReviewSection();
            reviewSection.Title = "Our happy customers";
            reviewSection.Reviews = new List<Review>();

            Review r1 = new Review()
            {
                Comment = "test comment",
                Doctor = d1,
                Patient = p1
            };
            reviewSection.Reviews.Add(r1);
            //Settings
            Review r2 = new Review()
            {
                Comment = "اشكر الطبيب على شرحه الوافى وتوضيحه للحالة",
                Doctor = d2,
                Patient = p2
            };
            reviewSection.Reviews.Add(r2);

            Review r3 = new Review()
            {
                Comment = "متفهم ومحترم وساعدنى كثيرا",
                Doctor = d3,
                Patient = p3
            };
            reviewSection.Reviews.Add(r3);

            HomeList.Add(reviewSection);

            #endregion

            #region doctors section
            DoctorSection doctorSection = new DoctorSection();
            doctorSection.Title = "Doctors accepting MedGulf";
            doctorSection.Doctors = new List<Doctor>();

            doctorSection.Doctors.Add(d1);

            doctorSection.Doctors.Add(d2);

            doctorSection.Doctors.Add(d3);

            doctorSection.Doctors.Add(d4);

            doctorSection.Doctors.Add(d5);

            doctorSection.Doctors.Add(d6);

            HomeList.Add(doctorSection);

            #endregion


            
            // add more sections here ...
        }

    }
}

