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
    public partial class FrmServiceBill : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        string getId;
        public FrmServiceBill()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmServiceBill_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in db.tblContract.ToList())
            {
                i++;
            }
            // Kiểm tra nếu chưa có bản ghi thì edit = false
            if (i == 0)
            {
                edit = false;
            }
            showEmp();
            showApart();
            showService();
            setTextNameFamily();
            setTextService();
            showServiceBill();
            getCurrentRow();
        }

        private void showService()
        {
            cboSer.DataSource = db.tblService.ToList();
            cboSer.DisplayMember = "serId";
            cboSer.ValueMember = "id";
        }

        private void showServiceBill()
        {
            dgvListSerBill.DataSource = db.getSerBill();
        }

        private void showEmp()
        {
            cboEmp.DataSource = db.getEmployee();
            cboEmp.DisplayMember = "empName";
            cboEmp.ValueMember = "empId";
        }

        private void showApart()
        {
            cboApart.DataSource = db.getAparment();
            cboApart.DisplayMember = "apartId";
            cboApart.ValueMember = "id";
        }
        private void setTextNameFamily()
        {
            int temp = (int)cboApart.SelectedValue;
            var apart = db.searchApartById(temp);
            foreach (var item in apart)
            {
                if (item.familyId != null)
                {
                    var family = db.searchFamilyByid1(item.familyId);
                    foreach (var f in family)
                    {
                        if (f.familyName != null)
                        {
                            txtNameFamily.Text = f.familyName;
                        }
                    }
                }
                else
                {
                    txtNameFamily.Text = "Trống!";
                }
            }
        }
        private void setTextService()
        {
            var ser = cboSer.SelectedValue;
            var find = db.tblService.Find(ser);
            var price = find.price;
            txtNameSer.Text = find.serName;
            txtPrice.Text = price.ToString();

            // Tính thành tiền
            var apart = db.tblApartment.Find(cboApart.SelectedValue);
            var area = apart.area;
            var total = (area * price) + (area * price * 0.1);
            txtTotal.Text = total.ToString();
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListSerBill.CurrentRow;
            if (cr != null)
            {
                getId = txtId.Text = cr.Cells[0].Value.ToString();
                txtName.Text = cr.Cells[1].Value.ToString();
                txtNote.Text = cr.Cells[2].Value.ToString();
                txtTotal.Text = cr.Cells[3].Value.ToString();

                cboEmp.SelectedValue = cr.Cells[5].Value;
                cboApart.SelectedValue = cr.Cells[6].Value;
                cboSer.SelectedValue = cr.Cells[7].Value;
                cboSer.Enabled = false;
                setTextNameFamily();
                setTextService();
                edit = true;
            }

        }

        private void cboApart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setTextNameFamily();
            setTextService();
        }

        private void cboSer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setTextService();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            cboSer.Enabled = true;
            txtId.Text = txtName.Text = txtNote.Text = "";
            cboEmp.SelectedIndex = cboApart.SelectedIndex = cboSer.SelectedIndex = 0;
            setTextNameFamily();
            setTextService();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtId.Text != "" && txtNote.Text != "")
            {
                if (edit == false)
                {
                    // ADD TO TABLE SERVICE BILL
                    var lstSer = db.tblServiceBill.ToList();
                    bool chk = false;
                    foreach (var item in lstSer)
                    {
                        if (item.id.Equals(txtId.Text))
                        {
                            chk = true;
                            break;
                        }
                    }
                    if (chk)
                    {
                        MessageBox.Show("Mã hóa đơn bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var serbill = new tblServiceBill();
                        serbill.id = txtId.Text;
                        serbill.serBillName = txtName.Text;
                        serbill.note = txtNote.Text;
                        serbill.total = Double.Parse(txtTotal.Text);
                        serbill.datePrint = DateTime.Now;
                        serbill.empId = (int)cboEmp.SelectedValue;
                        serbill.apartId = (int)cboApart.SelectedValue;
                        serbill.serId = (int)cboSer.SelectedValue;
                        db.tblServiceBill.Add(serbill);
                        db.SaveChanges();

                        MessageBox.Show("Thêm mới hóa đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showServiceBill();
                    }
                }
                else
                {
                    var id = txtId.Text;
                    var serbill = db.tblServiceBill.Find(id);
                    serbill.serBillName = txtName.Text;
                    serbill.note = txtNote.Text;
                    serbill.total = Double.Parse(txtTotal.Text);
                    serbill.datePrint = serbill.datePrint;
                    serbill.empId = (int)cboEmp.SelectedValue;
                    serbill.apartId = (int)cboApart.SelectedValue;
                    serbill.serId = (int)cboSer.SelectedValue;
                    db.SaveChanges();

                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showServiceBill();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = txtId.Text;
                var p = db.tblServiceBill.Find(id);
                if (p != null)
                {
                    db.tblServiceBill.Remove(p);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showServiceBill();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void dgvListSerBill_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }

        Bitmap bitmap;

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 0, 0);
            ServiceBill pnl = new ServiceBill();
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bitmap, (pagearea.Width / 2) - (pnl.Width / 2), pnl.Location.Y);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Receipts pnl = new Receipts();
            pnl.getInform(getId);

            bitmap = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bitmap, new Rectangle(0, 0, pnl.Width, pnl.Height));

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Receipts pnl = new Receipts();
            //pnl.getInform(getId);

            //bitmap = new Bitmap(pnl.Width, pnl.Height);
            //pnl.DrawToBitmap(bitmap, new Rectangle(0, 0, pnl.Width, pnl.Height));

            //printDialog.Document = printDocument;
            //printDialog.ShowDialog();

            if (dgvListSerBill.CurrentRow != null)
            {
                FrmReport fr = new FrmReport();
                fr.BillId = dgvListSerBill.CurrentRow.Cells[0].Value.ToString();
                fr.Show();
            }
        }

        private void dgvListSerBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
