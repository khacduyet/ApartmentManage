using Product.DAO;
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
    public partial class Receipts : UserControl
    {
        Apartment db = new Apartment();
        string id;
        public Receipts()
        {
            InitializeComponent();
        }

        public void getInform(string getId)
        {
            id = getId;
        }

        private void Receipts_Load(object sender, EventArgs e)
        {
            var bill = db.tblServiceBill.Find(id);
            lblId.Text += bill.id;
            //lblName.Text += bill.serBillName;

            var apart = db.searchApartById(bill.apartId);
            foreach (var item in apart)
            {
                if (item.familyId != null)
                {
                    var family = db.searchFamilyByid1(item.familyId);
                    foreach (var f in family)
                    {
                        if (f.familyName != null)
                        {
                            lblName.Text = f.familyName.ToUpper();
                            lblAddress.Text = f.familyId.ToUpper() + " Chung Cư 151 Nguyễn Đức Cảnh, Hoàng Mai, Hà Nội";
                        }
                    }
                }
                else
                {
                    
                }
            }
            lblNote.Text = bill.note;


            var b = bill.total;
            double a = (double) b;
            lblTotal.Text = a.ToString("###,###,###,###,###") + " đ";


            var text = Product.Ultis.NumberToText((double)bill.total);
            lblTotalToWords.Text = text;
            var emp = db.tblEmployee.Find(bill.empId);
            lblNameEmp.Text = emp.empName;

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            lblDateFirst.Text = lblDateLast.Text = "Ngày " + dy + " Tháng " + mn + " Năm " + yy;
        }
    }
}
