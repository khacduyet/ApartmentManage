using Product.DAO;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Product
{
    public partial class FrmLogin : Form
    {
        Apartment db = new Apartment();
        public int userId { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            bool chk = false;
            var user = from u in db.tblUser
                       where u.uuid == txtUser.Text && u.pwd == txtPass.Text && u.status == true
                       select u;
            foreach (var item in user)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chk = true;
                userId = item.userId;
                this.Hide();
            }
            
            if (!chk)
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }
    }
}
