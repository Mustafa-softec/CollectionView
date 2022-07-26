using System;
using System.Collections.Generic;
using Cura.Cells;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura.Adapters
{
    public class ReviewHorizontalCollectionDataSource : UICollectionViewDataSource
    {
        public List<Review> items { get; set; } = new List<Review>();
        public ReviewHorizontalCollectionDataSource(List<Review> _items)
        {
            items = _items;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return items.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (ReviewHorizontalCollectionViewCell)collectionView.DequeueReusableCell(ReviewHorizontalCollectionViewCell.Key, indexPath);

            var revew = items[indexPath.Row];

             cell.FillData(revew);

            return cell;
        }
    }
}
