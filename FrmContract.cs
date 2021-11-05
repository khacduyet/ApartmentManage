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
    public partial class FrmContract : Form
    {
        Apartment db = new Apartment();
        bool edit = true;
        public FrmContract()
        {
            InitializeComponent();
        }

        private void FrmContract_Load(object sender, EventArgs e)
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
            setTextNameFamily();
            showContract();
        }

        private void showContract()
        {
            dgvListContract.DataSource = db.getContract();
            getCurrentRow();
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

        private void btnFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn tệp";
            ofd.Filter = "All Word Documents (*.docx;*.doc;*.pdf;*.html;*.xml;*.xls;*.ppt)|*.docx;*.doc;*.pdf;*.html;*.xml;*.xls;*.ppt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setTextNameFamily();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = txtFileName.Text = txtLimitation.Text = "";
            dtpDateSign.Value = DateTime.Now;
            cboEmp.SelectedIndex = 0;
            cboApart.SelectedIndex = 0;
            setTextNameFamily();
            edit = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtLimitation.Text != "")
            {
                if (edit == false)
                {
                    // ADD TO TABLE CONTRACT
                    var con = new tblContract();
                    con.contractName = txtName.Text;
                    con.empId = (int)cboEmp.SelectedValue;
                    con.familyId = (int)cboApart.SelectedValue;
                    insertContract(con);
                    // ADD TO TABLE CONTRACT DETAILs

                    var conDetails = new tblContractDetail();
                    conDetails.limitation = txtLimitation.Text;
                    conDetails.signDay = dtpDateSign.Value;
                    conDetails.content = txtFileName.Text;

                    var getIdContract = db.searchContractByName(txtName.Text);
                    foreach (var item in getIdContract)
                    {
                        conDetails.contractId = item.contractId;
                    }
                    insertContractDetails(conDetails);
                    MessageBox.Show("Thêm mới hợp đồng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showContract();
                }
                else
                {
                    var id = lblId.Text;
                    var con = db.tblContract.Find(Int16.Parse(id));
                    // ADD TO TABLE CONTRACT
                    con.contractName = txtName.Text;
                    con.empId = (int)cboEmp.SelectedValue;
                    con.familyId = (int)cboApart.SelectedValue;
                    updateContract(con);
                    // ADD TO TABLE CONTRACT DETAILs

                    var conDet = db.searchContractDetailsById(Int16.Parse(id));
                    var temp = new tblContractDetail();
                    temp.limitation = txtLimitation.Text;
                    temp.signDay = dtpDateSign.Value;
                    temp.content = txtFileName.Text;

                    var getIdContract = db.searchContractByName(txtName.Text);
                    foreach (var i in getIdContract)
                    {
                        temp.contractId = i.contractId;
                    }

                    foreach (var item in conDet)
                    {
                        temp.contDetailId = item.contDetailId;
                    }
                    updateContractDetails(temp);

                    MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showContract();
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
                int temp = 0;
                var conDet = db.searchContractDetailsById(Int16.Parse(id));
                foreach (var item in conDet)
                {
                    temp = item.contDetailId;
                }
                db.deleteContractDetails(temp);

                var con = db.tblContract.Find(Int16.Parse(id));
                db.deleteMember(con.contractId);
                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showContract();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListContract.CurrentRow;
            if (cr != null)
            {
                lblId.Text = cr.Cells[0].Value.ToString();
                txtName.Text = cr.Cells[1].Value.ToString();
                cboApart.SelectedValue = cr.Cells[2].Value;
                setTextNameFamily();
                cboEmp.SelectedValue = cr.Cells[3].Value;
                txtLimitation.Text = cr.Cells[4].Value.ToString();
                dtpDateSign.Text = cr.Cells[5].Value.ToString();
                txtFileName.Text = cr.Cells[6].Value.ToString();

                edit = true;
            }
        }

        private void insertContract(tblContract con)
        {
            db.insertContract(con.contractName, con.familyId, con.empId);
        }

        private void updateContract(tblContract con)
        {
            db.updateContract(con.contractId, con.contractName, con.familyId, con.empId);
        }

        private void insertContractDetails(tblContractDetail con)
        {
            db.insertContractDetails(con.limitation, con.signDay,con.content, con.contractId);
        }

        private void updateContractDetails(tblContractDetail con)
        {
            db.updateContractDetails(con.contDetailId,con.limitation, con.signDay,con.content, con.contractId);
        }

        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(txtFileName.Text);
            if (txtFileName.Text != "")
            {
                System.Diagnostics.Process.Start(txtFileName.Text);
            } else
            {
                MessageBox.Show("Không có đường dẫn file!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvListContract_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }

        private void llbl_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showContract();
        }
    }
}
