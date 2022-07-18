using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//

namespace TuVanMuaMayTinh_HCG_Nhom5
{
    public partial class FormHuongDanCauHinhCSDL : Form
    {
        public FormHuongDanCauHinhCSDL()
        {
            InitializeComponent();
        }

        private void FormHuongDanCauHinhCSDL_Load(object sender, EventArgs e)
        {
            textBoxSQL.Text = Resource1.String1;
        }
    }
}
