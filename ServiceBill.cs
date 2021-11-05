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
    public partial class ServiceBill : UserControl
    {
        public ServiceBill()
        {
            InitializeComponent();
        }

        private void ServiceBill_Load(object sender, EventArgs e)
        {
            string name = "Bùi Khắc Duyệt";
            lblName.Text += name.ToUpper();
            string totalAmount = lblTotalAmount.Text;
            var text = Product.Ultis.NumberToText(Double.Parse(totalAmount));
            lblTotalInWords.Text += text;
        }
    }
}
