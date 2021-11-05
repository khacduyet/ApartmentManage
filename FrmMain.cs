using Product.DAO;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Product
{
    public partial class FrmMain : Form
    {
        Apartment db = new Apartment();
        public bool check { get; set; }
        public int userId { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            setText();
            FrmLogin login = new FrmLogin();
            login.ShowDialog();
            userId = login.userId;
            getPermission();
        }

        private void getPermission()
        {

            ts1Sign.Enabled = false;
            getDate();
            toolStripProgBar.Minimum = 0;
            toolStripProgBar.Maximum = 100;
            toolStripProgBar.Value = 70;

            // Get Permission
            var data = from u in db.tblUser
                       join r in db.tblPerRelationship
                       on u.userId equals r.idUserRel
                       join p in db.tblPermission
                       on r.idPerRel equals p.permissionId
                       where u.userId == userId
                       select new
                       {
                           uuid = u.uuid,
                           permissionName = p.permissionName,
                           permissionAccess = p.permissionAccess
                       };

            string arrStr = "";
            foreach (var item in Assembly.Load("Product").GetTypes())
            {
                if (item.BaseType == typeof(Form))
                {
                    var emptyCtor = item.GetConstructor(Type.EmptyTypes);
                    if (emptyCtor != null)
                    {
                        var f = (Form)emptyCtor.Invoke(new object[] { });
                        // t.FullName will help distinguish the unwanted entries and
                        // possibly later ignore them
                        string formItem = item.FullName;
                        if (formItem == "Product.FrmLogin" | formItem == "Product.FrmMain")
                        {
                            arrStr = arrStr;
                        }
                        else
                        {
                            arrStr += formItem + ",";
                        }
                    }
                }
            }

            string[] arrCompare = arrStr.Split(',');
            string[] arrPer = { };
            foreach (var item in data)
            {
                if (item.permissionAccess.Equals("All"))
                {
                    arrPer = arrCompare;
                }
                else
                {
                    arrPer = item.permissionAccess.Split(',');
                }
            }

            var primary = arrCompare.Length > arrPer.Length ? arrCompare : arrPer;
            var secondary = primary == arrPer ? arrCompare : arrPer;
            var difference = primary.Except(secondary).ToArray();


            ToolStripItem[] a = { };
            ToolStripItem[] b = { };
            ToolStripItem[] c = { };

            foreach (var item in difference)
            {
                string str = item.Replace("Product.", "");
                a = toolStrip1.Items.Find(str, true);
                foreach (var aa in a)
                {
                    aa.Enabled = false;
                }
                b = toolStrip2.Items.Find(str, true);
                foreach (var bb in b)
                {
                    bb.Enabled = false;
                }
                c = toolStrip3.Items.Find(str, true);
                foreach (var cc in c)
                {
                    cc.Enabled = false;
                }
            }
            // End Get Permission

            // Set statusBar
            foreach (var item in data)
            {
                toolStripUsername.Text = "Tài khoản: " + item.uuid + " - Quyền: " + item.permissionName;
            }
        }

        private void getDate()
        {
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            toolStripDate.Text = date;
        }

        private void toolStripBtn(string str, ToolStripButton tsb)
        {
            if (str == tsb.Name)
            {
                tsb.Enabled = false;
            }
        }

        private void setText()
        {
            AccountManager.Text = "Quản lý \ntài khoản";
            FrmEmployee.Text = "Quản lý \nnhân viên";
            FrmApartment.Text = "Quản lý \ncăn hộ";
            FrmContract.Text = "Quản lý \nhợp đồng";
            FrmFamily.Text = "Quản lý \nhộ gia đình";
            FrmMember.Text = "Quản lý \nthành viên";
            FrmService.Text = "Quản lý \ndịch vụ";
            FrmServiceBill.Text = "Quản lý hóa \nđơn dịch vụ";
            ts2Parking.Text = "Quản lý \nbãi xe";
            FrmReportApartment.Text = "Thống kê \ncăn hộ";
            ts3ser.Text = "Thống kê \ndịch vụ";
            ts3electric.Text = "Thống kê \ntiền điện";
            ts3water.Text = "Thống kê \ntiền nước";
            ts3revenue.Text = "Thống kê \ndoanh thu";
        }
        private bool existForm(string frm_name)
        {
            bool flag = false;
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == frm_name)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private void ts1AccMan_Click(object sender, EventArgs e)
        {
            if (!existForm("AccountManager"))
            {
                AccountManager am = new AccountManager();
                am.MdiParent = this;
                am.Show();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() != this.GetType() && item != this)
                {
                    item.Close();
                }
            }
            FrmLogin formLogin = new FrmLogin();
            formLogin.ShowDialog();
            getPermission();
        }
        private void ts2EmpMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmEmployee"))
            {
                FrmEmployee fel = new FrmEmployee();
                fel.MdiParent = this;
                fel.Show();
            }
        }

        private void ts2FamMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmFamily"))
            {
                FrmFamily ff = new FrmFamily();
                ff.MdiParent = this;
                ff.Show();
            }
        }

        private void ts2MemMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmMember"))
            {
                FrmMember fm = new FrmMember();
                fm.MdiParent = this;
                fm.Show();
            }
        }

        private void ts2ApartMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmApartment"))
            {
                FrmApartment fa = new FrmApartment();
                fa.MdiParent = this;
                fa.Show();
            }
        }

        private void ts2Constract_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmContract"))
            {
                FrmContract fc = new FrmContract();
                fc.MdiParent = this;
                fc.Show();
            }
        }

        private void ts2SerMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmService"))
            {
                FrmService fs = new FrmService();
                fs.MdiParent = this;
                fs.Show();
            }
        }

        private void ts2billMan_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmServiceBill"))
            {
                FrmServiceBill fsb = new FrmServiceBill();
                fsb.MdiParent = this;
                fsb.Show();
            }
        }

        private void ts3apart_Click(object sender, EventArgs e)
        {
            if (!existForm("FrmReport"))
            {
                FrmReportApartment fr = new FrmReportApartment();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
