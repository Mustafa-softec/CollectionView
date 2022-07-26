using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Cura
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {

        public UIWindow window { get; set; }

      //  public IntPtr Handle => throw new NotImplementedException();

        UICollectionViewController homeCollectionViewController;
        UICollectionViewFlowLayout flowLayout;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method


            window = new UIWindow(UIScreen.MainScreen.Bounds);

            var _width = window.Bounds.Width;

            // Flow Layout
            flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize(_width, 300),
                SectionInset = new UIEdgeInsets(20, 20, 20, 20),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumInteritemSpacing = 50, // minimum spacing between cells
                MinimumLineSpacing = 50 // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            homeCollectionViewController = new HomeViewController(flowLayout);

            //homeCollectionViewController.CollectionView.ContentInset = new UIEdgeInsets(50, 0, 0, 0);

            window.RootViewController = homeCollectionViewController;
            window.MakeKeyAndVisible();

            return true;
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

