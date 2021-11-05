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
    public partial class FrmReport : Form
    {
        Apartment db = new Apartment();
        public string BillId { get; set; }
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            loadViewer();
        }

        private void loadViewer()
        {
            var data = from sb in db.tblServiceBill
                       join a in db.tblApartment on sb.apartId equals a.id
                       join e in db.tblEmployee on sb.empId equals e.empId
                       join f in db.tblFamily on a.familyId equals f.id
                       where sb.id == BillId
                       select new ServiceBillModel
                       {
                           id = sb.id,
                           empName = e.empName,
                           familyId = f.familyId,
                           familyName = f.familyName,
                           note = sb.note,
                           total = sb.total.Value
                       };

            // Get Day
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
            // Get Day

            string text = "";
            // Get Total to Words
            foreach (var item in data)
            {
                text = Product.Ultis.NumberToText((double)item.total);
            }
            
            // Get Total to Words
            ReportBillService ra = new ReportBillService();
            ra.SetDataSource(data.ToList());
            ra.SetParameterValue(0, "Ngày " + dy + " Tháng " + mn + " Năm " + yy);
            ra.SetParameterValue(1, "Chung cư 151 Nguyễn Đức Cảnh, Hoàng Mai, Hà Nội");
            ra.SetParameterValue(2, char.ToUpper(text[0]) + text.Substring(1));
            ReportViewer1.ReportSource = ra;
            ReportViewer1.Show();
        }
    }
}
