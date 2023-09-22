using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using KpopZtation.Report;
using KpopZtation.Dataset;
using KpopZtation.Models;
using KpopZtation.Repository;

namespace KpopZtation.Views.TransactionReport
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport report = new CrystalReport();
            CrystalReportViewer.ReportSource = report;

            KzDataset data = getData(TransactionHeaderRepository.GetAllTransactions());
            report.SetDataSource(data);
        }

        private KzDataset getData(List<transactionHeader> transactionHeaders)
        {
            KzDataset data = new KzDataset();
            var headerTb = data.transactionHeader;
            var detailTb = data.transactionDetail;
            var albumTb = data.album;

            HashSet<int> existingAlbums = new HashSet<int>();

            foreach (transactionHeader th in transactionHeaders)
            {
                var hrow = headerTb.NewRow();
                hrow["transactionId"] = th.transactionId;
                hrow["transactionDate"] = th.transactionDate;
                hrow["customerId"] = th.customerId;

                int grandTotalPrice = 0;
                foreach(transactionDetail td in th.transactionDetails)
                {
                    var drow = detailTb.NewRow();
                    drow["transactionId"] = td.transactionId;
                    drow["albumId"] = td.albumId;
                    drow["qty"] = td.qty;

                    int subTotalPrice = countSubTotalPrice(td.albumId, td.qty);
                    drow["subTotalPrice"] = "Rp " + subTotalPrice;
                    detailTb.Rows.Add(drow);

                    if (!existingAlbums.Contains(td.albumId))
                    {
                        var arow = albumTb.NewRow();
                        arow["albumId"] = td.albumId;
                        album album = AlbumRepository.findAlbum(td.albumId);
                        arow["albumName"] = album.albumName;
                        arow["albumPrice"] = "Rp " + album.albumPrice;
                        albumTb.Rows.Add(arow);

                        existingAlbums.Add(td.albumId);
                    }
                    grandTotalPrice += subTotalPrice;
                }

                hrow["grandTotalPrice"] = "Rp " + grandTotalPrice;
                headerTb.Rows.Add(hrow);
            }
            return data;
        }
        
        private int countSubTotalPrice(int albumId, int qty)
        {
            album album = AlbumRepository.findAlbum(albumId);
            return (album.albumPrice * qty);
        }
    }
}