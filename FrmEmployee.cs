using Product.DAO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Product
{
    public partial class FrmEmployee : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            getIdEmp();
            txtName.Text = txtPhone.Text = txtEmail.Text = txtCMND.Text = txtAddress.Text = lblLinkImage.Text = "";
            cboDerpartment.SelectedIndex = 0;
            rdoMale.Checked = true;
            dtpDob.Text = "01/01/1990";
            ptbImage.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtAddress.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" && txtCMND.Text != "" && lblLinkImage.Text != "" && dtpDob.Value != null)
            {
                if (edit == false)
                {
                    var emp = new tblEmployee();
                    emp.empName = txtName.Text;
                    if (rdoMale.Checked)
                    {
                        emp.gender = true;
                    }
                    else
                    {
                        emp.gender = false;
                    }
                    emp.address = txtAddress.Text;
                    emp.phone = txtPhone.Text;
                    emp.dob = dtpDob.Value;
                    emp.email = txtEmail.Text;
                    emp.identityNumber = txtCMND.Text;
                    emp.departmentId = cboDerpartment.SelectedIndex;
                    emp.image = lblLinkImage.Text;
                    insertEmp(emp);
                    showEmp();
                }
                else
                {
                    var id = txtId.Text;
                    var em = db.tblEmployee.Find(Int16.Parse(id));
                    em.empName = txtName.Text;
                    if (rdoMale.Checked)
                    {
                        em.gender = true;
                    }
                    else
                    {
                        em.gender = false;
                    }
                    em.address = txtAddress.Text;
                    em.phone = txtPhone.Text;
                    em.dob = dtpDob.Value;
                    em.email = txtEmail.Text;
                    em.identityNumber = txtCMND.Text;
                    em.departmentId = cboDerpartment.SelectedIndex;
                    em.image = lblLinkImage.Text;
                    updateEmp(em);
                    showEmp();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

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

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            cboDerpartment.SelectedIndex = 0;
            getIdEmp();
            showEmp();
        }

        private void showEmp()
        {
            dgvListEmp.DataSource = db.getEmployee();
            getCurrentRow();
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListEmp.CurrentRow;
            if (cr != null)
            {
                txtId.Text = cr.Cells[0].Value.ToString();
                txtName.Text = cr.Cells[1].Value.ToString();
                if (cr.Cells[2].Value.ToString().Equals("True"))
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }
                txtAddress.Text = cr.Cells[3].Value.ToString();
                txtPhone.Text = cr.Cells[4].Value.ToString();
                dtpDob.Text = cr.Cells[5].Value.ToString();
                txtEmail.Text = cr.Cells[6].Value.ToString();
                txtCMND.Text = cr.Cells[7].Value.ToString();
                cboDerpartment.SelectedValue = cr.Cells[8].Value;
                lblLinkImage.Text = cr.Cells[9].Value.ToString();
                if (lblLinkImage.Text.Length > 0)
                    ptbImage.Image = Image.FromFile(lblLinkImage.Text);
                else ptbImage.Image = null;
                edit = true;
            }
        }

        private void insertEmp(tblEmployee emp)
        {
            db.insertEmployee(emp.empName, emp.gender, emp.address, emp.phone, emp.dob, emp.email, emp.identityNumber, emp.departmentId, emp.image);
            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateEmp(tblEmployee emp)
        {
            db.updateEmployee(emp.empId, emp.empName, emp.gender, emp.address, emp.phone, emp.dob, emp.email, emp.identityNumber, emp.departmentId, emp.image);
            MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void getIdEmp()
        {
            var d = db.getMaxIdEmp().Max();
            var dnew = d + 1;
            txtId.Text = dnew.ToString();
        }

        private void dgvListEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getCurrentRow();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = txtId.Text;
                var em = db.tblEmployee.Find(Int16.Parse(id));
                db.deleteEmployee(em.empId);
                showEmp();
                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvListEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
