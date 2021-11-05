using Product.DAO;
using System;
using System.Windows.Forms;

namespace Product
{
    public partial class FrmFamily : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        public FrmFamily()
        {
            InitializeComponent();
        }

        private void FrmFamily_Load(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (var item in db.tblFamily)
            //{
            //    i++;
            //}
            //// Kiểm tra nếu chưa có bản ghi thì edit = false
            //if (i == 0)
            //{
            //    edit = false;
            //}
            showFamily();
        }

        private void showFamily()
        {
            dgvListFamily.DataSource = db.getFamily();
            getCurrentRow();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListFamily.CurrentRow;
            if (cr != null)
            {
                lblId.Text = cr.Cells[0].Value.ToString();
                txtId.Text = cr.Cells[1].Value.ToString();
                txtName.Text = cr.Cells[2].Value.ToString();
                nbrMember.Value = decimal.Parse(cr.Cells[3].Value.ToString());
                edit = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtId.Text = txtName.Text = lblId.Text = "";
            nbrMember.Value = 0;
            edit = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtName.Text != "")
            {
                if (edit == false)
                {
                    var fam = new tblFamily();
                    fam.familyId = txtId.Text;
                    fam.familyName = txtName.Text;
                    fam.numberMember = (int)nbrMember.Value;
                    insertFam(fam);
                    showFamily();
                }
                else
                {
                    var id = lblId.Text;
                    //var fa = db.tblFamily.Find(Int16.Parse(id));
                    var fa = new tblFamily();
                    fa.id = Int16.Parse(id);
                    fa.familyId = txtId.Text;
                    fa.familyName = txtName.Text;
                    fa.numberMember = (int)nbrMember.Value;
                    updateFam(fa);
                    showFamily();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
        private void insertFam(tblFamily fam)
        {
            db.insertFamily(fam.familyId, fam.familyName, fam.numberMember);
            MessageBox.Show("Thêm hộ gia đình thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateFam(tblFamily fam)
        {
            db.updateFamily(fam.id, fam.familyId, fam.familyName, fam.numberMember);
            MessageBox.Show("Cập nhật hộ gia đình thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.deleteFamily(Int16.Parse(lblId.Text));
                showFamily();
                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvListFamily_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getCurrentRow();
        }
    }
}
