using Product.DAO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Product
{
    public partial class FrmMember : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        public FrmMember()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void FrmMember_Load(object sender, EventArgs e)
        {
            showFamily();
            showMember();
        }

        private void showMember()
        {
            dgvListMember.DataSource = db.getMember();
            getCurrentRow();
        }

        private void showFamily()
        {
            cboFamily.DataSource = db.getFamily();
            cboFamily.DisplayMember = "familyId";
            cboFamily.ValueMember = "id";

            cboSearchMem.DataSource = db.getFamily();
            cboSearchMem.DisplayMember = "familyId";
            cboSearchMem.ValueMember = "id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void refreshForm()
        {
            edit = false;
            txtId.Text = txtName.Text = txtPhone.Text = txtEmail.Text = txtCMND.Text = lblLinkImage.Text = "";
            cboFamily.SelectedIndex = 0;
            rdoMale.Checked = true;
            dtpDob.Text = "01/01/1990";
            ptbImage.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" && txtCMND.Text != "" && lblLinkImage.Text != "" && dtpDob.Value != null)
            {
                if (edit == false)
                {
                    var mem = new tblMember();
                    mem.memberId = txtId.Text;
                    mem.name = txtName.Text;
                    if (rdoMale.Checked)
                    {
                        mem.gender = true;
                    }
                    else
                    {
                        mem.gender = false;
                    }
                    mem.phone = txtPhone.Text;
                    mem.dob = dtpDob.Value;
                    mem.email = txtEmail.Text;
                    mem.identityNumber = txtCMND.Text;
                    mem.familyId = (int)cboFamily.SelectedValue;
                    mem.image = lblLinkImage.Text;
                    insertMem(mem);
                    showMember();
                }
                else
                {
                    var id = lblId.Text;
                    var mem = db.tblMember.Find(Int16.Parse(id));
                    mem.memberId = txtId.Text;
                    mem.name = txtName.Text;
                    if (rdoMale.Checked)
                    {
                        mem.gender = true;
                    }
                    else
                    {
                        mem.gender = false;
                    }
                    mem.phone = txtPhone.Text;
                    mem.dob = dtpDob.Value;
                    mem.email = txtEmail.Text;
                    mem.identityNumber = txtCMND.Text;
                    mem.familyId = (int)cboFamily.SelectedValue;
                    mem.image = lblLinkImage.Text;
                    updateMem(mem);
                    showMember();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListMember.CurrentRow;
            if (cr != null)
            {
                lblId.Text = cr.Cells[0].Value.ToString();
                txtId.Text = cr.Cells[1].Value.ToString();
                txtName.Text = cr.Cells[2].Value.ToString();
                if (cr.Cells[3].Value.ToString().Equals("True"))
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }
                txtEmail.Text = cr.Cells[4].Value.ToString();
                txtCMND.Text = cr.Cells[5].Value.ToString();
                dtpDob.Text = cr.Cells[7].Value.ToString();
                txtPhone.Text = cr.Cells[8].Value.ToString();
                cboFamily.SelectedValue = cr.Cells[9].Value;


                lblLinkImage.Text = cr.Cells[6].Value.ToString();
                if (lblLinkImage.Text.Length > 0)
                    ptbImage.Image = Image.FromFile(lblLinkImage.Text);
                else ptbImage.Image = null;
                edit = true;
            }
        }
        private void insertMem(tblMember mem)
        {
            db.insertMember(mem.memberId, mem.name, mem.gender, mem.email, mem.identityNumber, mem.image, mem.dob, mem.phone, mem.familyId);
            MessageBox.Show("Thêm thành viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateMem(tblMember mem)
        {
            db.updateMember(mem.id, mem.memberId, mem.name, mem.gender, mem.email, mem.identityNumber, mem.image, mem.dob, mem.phone, mem.familyId);
            MessageBox.Show("Cập nhật thành viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvListMember_Click(object sender, EventArgs e)
        {
            getCurrentRow();

        }



        private void searchFamily()
        {
            var id = cboSearchMem.SelectedValue;
            dgvListMember.DataSource = db.searchFamily((int)id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = lblId.Text;
                var mem = db.tblMember.Find(Int16.Parse(id));
                db.deleteMember(mem.id);
                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showMember();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchFamily();
        }

        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showMember();
        }
    }
}
