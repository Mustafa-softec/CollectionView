using System;
using System.Collections.Generic;
using Cura.Cells;
using Cura.Models;
using Foundation;
using UIKit;

namespace Cura.Adapters
{
    public class DoctorHorizontalCollectionDataSource : UICollectionViewDataSource
    {
        public List<Doctor> items { get; set; } = new List<Doctor>();
        public DoctorHorizontalCollectionDataSource(List<Doctor> _items)
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
            var cell = (DorctoHorizontalCollectionViewCell)collectionView.DequeueReusableCell(DorctoHorizontalCollectionViewCell.Key, indexPath);

            var doctor = items[indexPath.Row];

            cell.FillData(doctor);

            return cell;
        }
    }
}