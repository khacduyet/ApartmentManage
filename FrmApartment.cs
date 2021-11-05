using Product.DAO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Product
{
    public partial class FrmApartment : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        int count = 0;
        public FrmApartment()
        {
            InitializeComponent();
        }

        private void cboDerpartment_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmApartment_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in db.tblApartment.ToList())
            {
                i++;
            }
            // Kiểm tra nếu chưa có bản ghi thì edit = false
            if (i == 0)
            {
                edit = false;
            }
            showFamily();
            showApartment();
        }

        private void showApartment()
        {
            dgvListApart.DataSource = db.getAparment();
            getCurrentRow();
        }

        private void showFamily()
        {
            cboFamily.DataSource = db.getFamily();
            cboFamily.DisplayMember = "familyId";
            cboFamily.ValueMember = "id";

            //cboSearchApart.DataSource = db.getFamily();
            //cboSearchApart.DisplayMember = "familyId";
            //cboSearchApart.ValueMember = "id";
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                ptbImage.Image = new Bitmap(ofd.FileName);
                // image file path
                lblLinkImage.Text = ofd.FileName;
            }
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListApart.CurrentRow;
            if (cr != null)
            {
                lblId.Text = cr.Cells[0].Value.ToString();
                txtId.Text = cr.Cells[1].Value.ToString();
                nbrPrice.Value = decimal.Parse(cr.Cells[2].Value.ToString());
                nbrArea.Value = decimal.Parse(cr.Cells[3].Value.ToString());
                txtNote.Text = cr.Cells[4].Value.ToString();
                lblLinkImage.Text = cr.Cells[5].Value.ToString();
                if (lblLinkImage.Text.Length > 0)
                    ptbImage.Image = Image.FromFile(lblLinkImage.Text);
                else ptbImage.Image = null;
                if (cr.Cells[6].Value.ToString().Equals("True"))
                {
                    rdoUsed.Checked = true;
                }
                else
                {
                    rdoUnused.Checked = true;
                }
                if (cr.Cells[7].Value == null)
                {
                    chkFamily.Checked = false;
                    cboFamily.SelectedIndex = 0;
                }
                else
                {
                    chkFamily.Checked = true;
                    cboFamily.SelectedValue = cr.Cells[7].Value;
                }
                edit = true;
            }
        }

        private void chkFamily_CheckStateChanged(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
            {
                lblFamilyId.Visible = true;
                cboFamily.Visible = true;
            }
            else
            {
                lblFamilyId.Visible = false;
                cboFamily.Visible = false;
                count = 0;
            }
        }

        private void insertApart(tblApartment apart)
        {
            db.insertApartment(apart.apartId, apart.price, apart.area, apart.note, apart.image, apart.status, apart.familyId);
            MessageBox.Show("Thêm căn hộ thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateApart(tblApartment apart)
        {
            db.updateApartment(apart.id, apart.apartId, apart.price, apart.area, apart.note, apart.image, apart.status, apart.familyId);
            MessageBox.Show("Cập nhật căn hộ thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            txtId.Text = txtNote.Text = lblLinkImage.Text = "";
            nbrArea.Value = nbrPrice.Value = 0;
            cboFamily.SelectedIndex = 0;
            chkFamily.Checked = false;
            lblFamilyId.Visible = false;
            cboFamily.Visible = false;
            count = 0;
            rdoUsed.Checked = true;
            ptbImage.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtNote.Text != "" && lblLinkImage.Text != "")
            {
                if (edit == false)
                {
                    var apart = new tblApartment();
                    apart.apartId = txtId.Text;
                    apart.price = (double)nbrPrice.Value;
                    apart.area = (double)nbrArea.Value;
                    apart.note = txtNote.Text;
                    apart.image = lblLinkImage.Text;
                    if (rdoUsed.Checked)
                    {
                        apart.status = true;
                    }
                    else
                    {
                        apart.status = false;
                    }
                    if (chkFamily.Checked)
                    {
                        apart.familyId = (int)cboFamily.SelectedValue;
                    }
                    else
                    {
                        apart.familyId = null;
                    }
                    insertApart(apart);
                    showApartment();
                }
                else
                {
                    var id = lblId.Text;
                    var apart = db.tblApartment.Find(Int16.Parse(id));
                    apart.apartId = txtId.Text;
                    if (rdoUsed.Checked)
                    {
                        apart.status = true;
                    }
                    else
                    {
                        apart.status = false;
                    }
                    apart.price = (double)nbrPrice.Value;
                    apart.area = (double)nbrArea.Value;
                    apart.note = txtNote.Text;

                    if (chkFamily.Checked)
                    {
                        apart.familyId = (int)cboFamily.SelectedValue;
                    }
                    else
                    {
                        apart.familyId = null;
                    }

                    apart.image = lblLinkImage.Text;
                    updateApart(apart);
                    showApartment();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void dgvListApart_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = lblId.Text;
                var apart = db.tblApartment.Find(Int16.Parse(id));
                db.deleteApartment(apart.id);
                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showApartment();
            }
        }

        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showApartment();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvListApart.DataSource = db.searchApartByIdOrApart(txtKeySearch.Text, txtKeySearch.Text);
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
