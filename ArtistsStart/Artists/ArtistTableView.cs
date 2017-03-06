using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace Artists
{
    public class ArtistTableView : UITableViewController
    {
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var artist = Artists.Shared.ArtistData.Artists[indexPath.Row];

            var cell = new UITableViewCell(CGRect.Empty);
            cell.TextLabel.Text = artist;

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return Shared.ArtistData.Artists.Count;
        }
    }


}