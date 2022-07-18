using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TuVanMuaMayTinh_HCG_Nhom5
{
    public partial class FormLuat : Form
    {
        KetNoiSQL ketNoi = new KetNoiSQL();
        string table = "luat";
        string Age, Sex, Income, Configuration, Manufacturers, OS, Buy;
        int numberColumns = 0;
        Luat luatTimDuoc = new Luat();
        List<Luat> DSLuat = new List<Luat>();
        public FormLuat()
        {
            InitializeComponent();
            loadData();
        }
        public FormLuat(List<Luat> dsLuat, Luat luat)
        {
            this.luatTimDuoc = luat;
            this.DSLuat = dsLuat;
            InitializeComponent();
            ketNoi.truyVanSQL("delete from " + table);

            string sql = "insert into " + table + " values(@a,@s,@i,@c,@m,@o,@b)";
            for (int i = 0; i < dsLuat.Count; i++)
            {
                ketNoi.thucThiSQL(sql, dsLuat[i]);
            }

            loadData();
        }
        public void loadData()
        {
            try
            {
                dataGridView1.DataSource = ketNoi.layDLTuBang(table);
                numberColumns = dataGridView1.Columns.Count;

                string stt = ketNoi.truyVanSQL("select stt from luat where age='" + luatTimDuoc.Age + "' and sex='" + luatTimDuoc.Sex + "' and income = '" + luatTimDuoc.Income + "' and Configuration='" + luatTimDuoc.Configuration + "' and  Manufacturers='" + luatTimDuoc.Manufacturers + "' and os= '" + luatTimDuoc.OS + "' and buy='" + luatTimDuoc.Buy + "'").Rows[0][0].ToString();

                string kq = "Các dữ kiện thỏa mãn luật " + stt + ". Nên kết quả là: " + luatTimDuoc.Buy;
                txtKQ.Text = kq;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Enabled = false;
                FormHuongDanCauHinhCSDL f = new FormHuongDanCauHinhCSDL();
                f.TopMost = true;
                f.Show();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];

            this.Age = row.Cells[1].Value.ToString();
            this.Sex = row.Cells[2].Value.ToString();
            this.Income = row.Cells[3].Value.ToString();
            this.Configuration = row.Cells[4].Value.ToString();
            this.Manufacturers = row.Cells[5].Value.ToString();
            this.OS = row.Cells[6].Value.ToString();
            this.Buy = row.Cells[7].Value.ToString();

            string kq = "Nếu chọn ";
            for (int i = 1; i < numberColumns - 1; i++)
            {
                string value = row.Cells[i].Value.ToString();
                if (!value.Equals(""))
                {
                    kq += dataGridView1.Columns[i].HeaderText + " = " + value + ", ";
                }
            }
            txtKQ.Text = kq + " thì " + Buy;
        }


    }
}
