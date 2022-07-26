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
            // Perform any additional setup after loading the view, typically from a nib.

            


            //CollectionView.BackgroundColor = UIColor.Yellow;

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

            DoctorSection doctorSection = new DoctorSection();
            doctorSection.Title = "Doctors accepting MedGulf insurance";
            doctorSection.Doctors = new List<Doctor>();
            for (int i = 0; i < 10; i++)
            {
                doctorSection.Doctors.Add(new Doctor());
            }
            HomeList.Add(doctorSection);

            // add more sections here ...
        }

    }
}

