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
            ReviewSection reviewSection = new ReviewSection();
            reviewSection.Title = "Our happy customers";
            reviewSection.Reviews = new List<Review>();
            for (int i = 0; i < 10; i++)
            {
                reviewSection.Reviews.Add(new Review());
            }
            HomeList.Add(reviewSection);

            #region doctors section
            DoctorSection doctorSection = new DoctorSection();
            doctorSection.Title = "Doctors accepting MedGulf";
            doctorSection.Doctors = new List<Doctor>();

            Doctor d1 = new Doctor()
            {
                Name = "DR. Name 1",
                Image = "Images/d1.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 4
            };
            doctorSection.Doctors.Add(d1);

            Doctor d2 = new Doctor()
            {
                Name = "DR. Name 2",
                Image = "Images/d2.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 7
            };
            doctorSection.Doctors.Add(d2);


            Doctor d3 = new Doctor()
            {
                Name = "DR. Name 3",
                Image = "Images/d3.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 9
            };
            doctorSection.Doctors.Add(d3);

            Doctor d4 = new Doctor()
            {
                Name = "DR. Name 4",
                Image = "Images/d4.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 8
            };
            doctorSection.Doctors.Add(d4);

            Doctor d5 = new Doctor()
            {
                Name = "DR. Name 5",
                Image = "Images/d5.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 6
            };
            doctorSection.Doctors.Add(d5);

            Doctor d6 = new Doctor()
            {
                Name = "DR. Name 6",
                Image = "Images/d6.png",
                Degree = "SPECIALIST",
                Specialization = "Neurology",
                ReviewsCount = 5
            };
            doctorSection.Doctors.Add(d6);

            HomeList.Add(doctorSection);

            #endregion

            // add more sections here ...
        }

    }
}

