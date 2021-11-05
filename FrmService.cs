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
    public partial class FrmService : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        public FrmService()
        {
            InitializeComponent();
        }

        private void FrmService_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in db.tblService.ToList())
            {
                i++;
            }
            // Kiểm tra nếu chưa có bản ghi thì edit = false
            if (i == 0)
            {
                edit = false;
            }
            showService();
        }

        private void showService()
        {
            dgvListService.DataSource = db.tblService.ToList();
            getCurrentRow();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListService.CurrentRow;
            if (cr != null)
            {
                lblId.Text = cr.Cells[0].Value.ToString();
                txtId.Text = cr.Cells[1].Value.ToString();
                txtName.Text = cr.Cells[2].Value.ToString();
                nbrPrice.Value = decimal.Parse(cr.Cells[3].Value.ToString());
                edit = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            lblId.Text = txtId.Text = txtName.Text = "";
            nbrPrice.Value = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtName.Text != "")
            {
                if (edit == false)
                {
                    var lstSer = db.tblService.ToList();
                    bool chk = false;
                    foreach (var item in lstSer)
                    {
                        if (item.serId.Equals(txtId.Text))
                        {
                            chk = true;
                            break;
                        }
                    }
                    if (chk)
                    {
                        MessageBox.Show("Mã dịch vụ bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var ser = new tblService();
                        ser.serId = txtId.Text;
                        ser.serName = txtName.Text;
                        ser.price = (double)nbrPrice.Value;
                        db.tblService.Add(ser);
                        db.SaveChanges();
                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showService();
                    }

                }
                else
                {
                    var id = lblId.Text;
                    var ser = db.tblService.Find(Int16.Parse(id));
                    ser.serId = txtId.Text;
                    ser.serName = txtName.Text;
                    ser.price = (int)nbrPrice.Value;
                    db.SaveChanges();
                    showService();
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
                var id = lblId.Text;
                var p = db.tblService.Find(Int16.Parse(id));
                if (p != null)
                {
                    db.tblService.Remove(p);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showService();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void dgvListService_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }
    }
}
