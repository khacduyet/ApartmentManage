using Product.DAO;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    public partial class AccountManager : Form
    {
        Apartment ae = new Apartment();
        bool edit = true;
        public AccountManager()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            loadPermission();
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            var data = from u in ae.tblUser
                       join r in ae.tblPerRelationship
                       on u.userId equals r.idUserRel
                       join p in ae.tblPermission
                       on r.idPerRel equals p.permissionId
                       select new
                       {
                           userId = u.userId,
                           uuid = u.uuid,
                           pwd = u.pwd,
                           status = (u.status == true) ? "Mở" : "Khóa",
                           permissionName = p.permissionName,
                           permissionAccess = p.permissionAccess
                       };
            dgvListUser.DataSource = data.ToList();
            getCurrentRow();
        }

        private void loadPermission()
        {
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
                        chkListPermission.Items.Add(formItem);
                        if (formItem == "Product.FrmLogin" | formItem == "Product.FrmMain")
                        {
                            chkListPermission.Items.Remove(formItem);
                        }
                    }
                }
            }
        }

        int c = 0;

        private void chkAll_CheckStateChanged(object sender, EventArgs e)
        {

            if (c == 0)
            {
                for (int i = 0; i < chkListPermission.Items.Count; i++)
                {
                    chkListPermission.SetItemChecked(i, true);
                }
                c++;
            }
            else if (c >= 11)
            {
                c++;
            }
            else
            {
                for (int i = 0; i < chkListPermission.Items.Count; i++)
                {
                    chkListPermission.SetItemChecked(i, false);
                }
                c = 0;
            }
        }
        private void chkListPermission_SelectedValueChanged(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < chkListPermission.Items.Count; i++)
            {
                if (chkListPermission.GetItemChecked(i))
                {
                    count++;
                }
            }
            if (count == chkListPermission.Items.Count)
            {
                c = 0;
                chkAll.Checked = true;
            }
            else
            {
                c = 11;
                chkAll.Checked = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            edit = false;
            txtUser.Text = txtPass.Text = txtNamePermission.Text = "";
            for (int i = 0; i < chkListPermission.Items.Count; i++)
            {
                chkListPermission.SetItemChecked(i, false);
            }
            chkAll.Checked = false;
            c = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != null && txtPass.Text != null && txtNamePermission.Text != null)
            {
                if (!edit)
                {
                    var lstUser = ae.tblUser;
                    bool chk = false;
                    foreach (var item in lstUser)
                    {
                        if (item.uuid.Equals(txtUser.Text))
                        {
                            chk = true;
                            break;
                        }
                    }
                    if (chk)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var user = new tblUser();
                        user.uuid = txtUser.Text;
                        user.pwd = txtPass.Text;
                        if (rdoUnlock.Checked)
                        {
                            user.status = true;
                        }
                        else
                        {
                            user.status = false;
                        }
                        ae.tblUser.Add(user);

                        var per = new tblPermission();
                        per.permissionName = txtNamePermission.Text;
                        if (chkAll.Checked)
                        {
                            per.permissionAccess = "All";
                        }
                        else
                        {
                            string arr = "";
                            for (int i = 0; i < chkListPermission.Items.Count; i++)
                            {
                                if (chkListPermission.GetItemChecked(i))
                                {
                                    arr += chkListPermission.Items[i].ToString() + ",";
                                }
                            }
                            per.permissionAccess = arr;
                        }
                        ae.tblPermission.Add(per);

                        var rel = new tblPerRelationship();
                        rel.idUserRel = user.userId;
                        rel.idPerRel = per.permissionId;
                        ae.tblPerRelationship.Add(rel);

                        ae.SaveChanges();
                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataGridView();
                    }
                }
                else
                {
                    var id = dgvListUser.CurrentRow.Cells[0].Value;
                    var user = ae.tblUser.Find(id);
                    user.uuid = txtUser.Text;
                    user.pwd = txtPass.Text;
                    if (rdoUnlock.Checked)
                    {
                        user.status = true;
                    }
                    else
                    {
                        user.status = false;
                    }

                    var per = ae.tblPermission.Find(id);
                    per.permissionName = txtNamePermission.Text;
                    if (chkAll.Checked)
                    {
                        per.permissionAccess = "All";
                    }
                    else
                    {
                        string arr = "";
                        for (int i = 0; i < chkListPermission.Items.Count; i++)
                        {
                            if (chkListPermission.GetItemChecked(i))
                            {
                                arr += chkListPermission.Items[i].ToString() + ",";
                            }
                        }
                        per.permissionAccess = arr;
                    }

                    ae.SaveChanges();
                    MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ các trường!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = dgvListUser.CurrentRow.Cells[0].Value;
                var user = ae.tblUser.Find(id);
                ae.tblUser.Remove(user);

                var per = ae.tblPermission.Find(id);
                ae.tblPermission.Remove(per);

                var rel = ae.tblPerRelationship.Find(id);
                ae.tblPerRelationship.Remove(rel);

                ae.SaveChanges();

                MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataGridView();
            }
        }

        private void getCurrentRow()
        {
            DataGridViewRow cr = dgvListUser.CurrentRow;
            if (cr != null)
            {
                txtUser.Text = cr.Cells[1].Value.ToString();
                txtNamePermission.Text = cr.Cells[4].Value.ToString();
                if (cr.Cells[3].Value.ToString().Equals("Mở"))
                {
                    rdoUnlock.Checked = true;
                }
                else
                {
                    rdoLock.Checked = true;
                }
                txtPass.Text = cr.Cells[2].Value.ToString();
                for (int i = 0; i < chkListPermission.Items.Count; i++)
                {
                    chkListPermission.SetItemChecked(i, false);
                }
                if (cr.Cells[5].Value.ToString().Equals("All"))
                {
                    chkAll.Checked = true;
                    for (int i = 0; i < chkListPermission.Items.Count; i++)
                    {
                        chkListPermission.SetItemChecked(i, true);
                    }
                }
                else
                {
                    string lstPermission = cr.Cells[5].Value.ToString();
                    string[] arrStr = lstPermission.Split(',');
                    chkAll.Checked = false;
                    foreach (var item in arrStr)
                    {
                        for (int i = 0; i < chkListPermission.Items.Count; i++)
                        {
                            if (chkListPermission.Items[i].ToString().Equals(item))
                            {
                                chkListPermission.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            edit = true;
        }

        private void dgvListUser_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn cập nhật trạng thái?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var id = (int)dgvListUser.CurrentRow.Cells[0].Value;
                var rs = from u in ae.tblUser where u.userId == id select u;
                foreach (var item in rs)
                {
                    if (item.status == true)
                    {
                        item.status = false;
                    }
                    else
                    {
                        item.status = true;
                    }
                }
                ae.SaveChanges();
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataGridView();
            }
        }
    }
}
