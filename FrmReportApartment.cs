using Product.DAO;
using Product.ReportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product
{
    public partial class FrmReportApartment : Form
    {
        Apartment db = new Apartment();
        public FrmReportApartment()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            loadViewer();
        }

        private void loadViewer()
        {
            var data = from a in db.tblApartment
                       join f in db.tblFamily on a.familyId equals f.id
                       select new ApartmentModel
                       {
                           apartId = a.apartId,
                           price = a.price.Value,
                           area = a.area.Value,
                           note = a.note,
                           status = a.status.Value,
                           familyId = f.familyId,
                           familyName = f.familyName,
                           numberMember = f.numberMember.Value
                       };
            ReportApartment ra = new ReportApartment();
            ra.SetDataSource(data.ToList());
            ra.SetParameterValue(0, "Công ty TNHH Dịch vụ ABC .. XYZ");
            ra.SetParameterValue(1, "Địa chỉ: nhà A, phố B, phường C, quận D, TP E");
            ra.SetParameterValue(2, "DANH SÁCH THỐNG KÊ CĂN HỘ CÓ CHỦ SỞ HỮU");
            ReportViewer.ReportSource = ra;
            ReportViewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = from a in db.tblApartment
                       where a.familyId == null
                       select new
                       {
                           apartId = a.apartId,
                           price = a.price.Value,
                           area = a.area.Value,
                           note = a.note,
                           status = a.status.Value,
                           familyId = "",
                           familyName = "",
                           numberMember = ""
                       };
            ReportApartment ra = new ReportApartment();
            ra.SetDataSource(data.ToList());
            ra.SetParameterValue(0, "Công ty TNHH Dịch vụ ABC .. XYZ");
            ra.SetParameterValue(1, "Địa chỉ: nhà A, phố B, phường C, quận D, TP E");
            ra.SetParameterValue(2, "DANH SÁCH THỐNG KÊ CĂN HỘ CHƯA CHỦ SỞ HỮU");
            ReportViewer.ReportSource = ra;
            ReportViewer.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadViewer();
        }
    }
}
