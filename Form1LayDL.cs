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
    public partial class BTL_HCG : Form
    {

        KetNoiSQL ketnoi = new KetNoiSQL();
        List<Gain> dsGain = new List<Gain>();
        TreeNode tree = new TreeNode();         // cây chính
        TreeNode currentNode;                   // node hiện tại
        Entropy enstropyS;
        int pro = 0;                            // phần trăm của progessBar
        int proMax = 150;                       //tổng giá trị của progessbar
        List<string> lstAtt = new List<string>();
        const string BANG_DL = "DuLieu";
        //
        const string BANG_LUAT = "Luat";
        List<Luat> dsLuat = new List<Luat>();
        Luat luatTimDuoc = new Luat();


        public BTL_HCG()
        {
            InitializeComponent();
        }


        private void BTL_HCG_Load(object sender, EventArgs e)
        {
            try
            {
                //tao cay quyet dinh
                DataTable D = ketnoi.truyVanSQL("select * from " + BANG_DL + " where 1=2");
                startProgess();
                lstAtt = new List<string>();
                for (int i = 0; i < D.Columns.Count; i++)
                {
                    lstAtt.Add(D.Columns[i].ColumnName);
                }
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
                btLamMoi.Enabled = false;
                btNext.Enabled = false;
                comboBoxTraLoi.Enabled = false;
                this.dlToolStripMenuItem.Enabled = false;
                this.luatToolStripMenuItem.Enabled = false;
                FormHuongDanCauHinhCSDL f = new FormHuongDanCauHinhCSDL();
                f.Show();
            }
        }


        //Các tác vụ dưới nền. Load dữ liệu
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                tree = id3("", lstAtt);
                timLuat(tree);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pro = 0;
            groupBoxProgess.Visible = false;
            btLamMoi.Enabled = true;
            btNext.Enabled = true;
            menuStrip1.Enabled = true;
            comboBoxTraLoi.Enabled = true;

            timer1.Stop();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(tree);
            currentNode = treeView1.TopNode;
            taoCauHoi(currentNode);

        }


        //Các phương thức liên quan tới Hệ chuyên gia============================

        //tính độ lợi thông tin
        Gain GetGainMax(string sql, string dkthem)
        {
            try
            {
                DataTable bangDL = ketnoi.truyVanSQL(sql + dkthem);
                List<Gain> dsGan = new List<Gain>();
                for (int i = 1; i < bangDL.Columns.Count - 1; i++)
                {
                    Gain g = initGain(bangDL.Columns[i].ColumnName.ToString(), dkthem);
                    dsGan.Add(g);
                }
                Gain maxGain = dsGan[0];
                for (int i = 1; i < dsGan.Count; i++)
                {
                    if (dsGan[i].layGain > maxGain.layGain)
                    {
                        maxGain = dsGan[i];
                    }
                }
                return maxGain;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //Khởi tạo cây quyết định theo thuật toán ID3
        public TreeNode id3(string dkThem, List<string> attributes)
        {
            try
            {
                string sql = "select " + attributes[0];
                for (int i = 1; i < attributes.Count; i++)
                {
                    sql += ", " + attributes[i];
                }
                sql += " from " + BANG_DL + " where 1=1 ";
                DataTable D = ketnoi.truyVanSQL(sql + dkThem);

                //ktra xem tất cả các mẫu có đều thuộc một lớp hay không
                DataTable temp = ketnoi.truyVanSQL("select buy from " + BANG_DL + " where 1=1 " + dkThem + 
                    " group by buy");
                if (temp.Rows.Count == 1)
                {
                    string name = temp.Rows[0][0].ToString();
                    TreeNode tem = new TreeNode(name);
                    tem.Name = name;
                    tem.ForeColor = System.Drawing.Color.Red;
                    return tem;
                }

                //Đặt t là nhãn phổ biến nhất của thuộc tính mục tiêu trong D
                string nhanPhoBienTrongD = timNhanPhoBienNhat(dkThem);

                //Nếu attribute rỗng trả về cây có 1 nút gốc trỏ bởi t
                if (attributes.Count == 2)
                {//bỏ qua cột đầu tiên là stt và cột cuối cùng là taget buy
                    TreeNode nodePhoBienNhat = new TreeNode(nhanPhoBienTrongD);
                    nodePhoBienNhat.Name = nhanPhoBienTrongD;
                    customStyleNode(nodePhoBienNhat, System.Drawing.Color.Orange);
                    return nodePhoBienNhat;
                }
                //aStar là thuộc tính phân cấp tốt nhất của D
                Gain aStart = GetGainMax(sql + dkThem, dkThem);
                TreeNode t = new TreeNode(aStart.LabelNode);
                customStyleNode(t, System.Drawing.Color.Blue);
                //thuộc tính quyết định của t là aStar 
                for (int i = 0; i < aStart.DSEntropyS.Count; i++)
                {
                    Entropy a = aStart.DSEntropyS[i];

                    //bổ sung nhánh mới dưới t ứng với aStart = a
                    TreeNode tNew = new TreeNode(t.Text + "=" + a.LabelNode);
                    t.Nodes.Add(tNew);

                    customStyleNode(tNew, System.Drawing.Color.Green);
                    //Đặt D_a là tập con của D chứa các mẫu aStart = a
                    string dkMoi = dkThem + " and " + aStart.LabelNode + " = '" + a.LabelNode + "'";
                    DataTable D_a = ketnoi.truyVanSQL(sql + dkMoi);
                    //Nếu D_a rỗng, dưới nhánh mới sẽ thêm nút lá với nhãn phổ biến nhất trong D
                    if (D_a.Rows.Count == 0)
                    {
                        TreeNode node = new TreeNode(nhanPhoBienTrongD);
                        customStyleNode(node, System.Drawing.Color.Red);
                        //tNew.Nodes.Remove(tNew);
                        node.Name = nhanPhoBienTrongD;

                        tNew.Nodes.Add(node);
                    }
                    else
                    {
                        List<string> attCon = new List<string>(attributes);
                        attCon.Remove(aStart.LabelNode);
                        tNew.Nodes.Add(id3(dkMoi, attCon));
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //tìm nhãn phổ biến nhất 
        string timNhanPhoBienNhat(string dkThem)
        {
            string sql = "SELECT buy FROM " + BANG_DL + " where 1=1 " + dkThem + " GROUP BY buy order by count(*) desc";
            string s = "";
            try
            {
                s = ketnoi.truyVanSQL(sql).Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return s;
        }

        //Tính độ lợi thông tin của thuộc tính
        Gain initGain(string nameAttribute, string dieuKienThem)
        {
            try
            {
                enstropyS = new Entropy("s" + nameAttribute, countSql("where buy = 'yes' " + dieuKienThem), countSql("where buy = 'no' " + dieuKienThem));
                List<Entropy> ds = new List<Entropy>();
                //Khoi tao danh sach
                DataTable da = ketnoi.truyVanSQL("SELECT DISTINCT " + nameAttribute + " from  " + BANG_DL);
                int yesCount = 0, noCount = 0;
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    string labelNode = da.Rows[i][0].ToString();
                    yesCount = countSql("where " + nameAttribute + " = '" + labelNode + "' and buy = 'yes' " + dieuKienThem);
                    noCount = countSql("where " + nameAttribute + " = '" + labelNode + "' and buy = 'no' " + dieuKienThem);
                    Entropy entro = new Entropy(labelNode, yesCount, noCount);
                    ds.Add(entro);
                }
                return new Gain(nameAttribute, ds, enstropyS);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return null;
            }
        }

        //trả về số lượng với điều kiện truyền vào theo truy vấn SQL
        int countSql(string where)
        {
            try
            {
                string sql = "Select count(stt) from " + BANG_DL + " " + where;
                return Int32.Parse(ketnoi.truyVanSQL(sql).Rows[0][0].ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }

        // Các phương thức sinh tập luật từ cây quyết định==================================

        //tìm ra các Node là KQ NO, Yes, No Result  đổ vào dsLuat
        public void timLuat(TreeNode tree)
        {
            TreeNode[] nodeNo = tree.Nodes.Find("No", true);
            TreeNode[] nodeYes = tree.Nodes.Find("Yes", true);
            sinhLuat(nodeNo);
            sinhLuat(nodeYes);
        }

        //sinh ra các luật tương ứng theo mảng Node truyền vào
        public void sinhLuat(TreeNode[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Luat l = new Luat();
                l.Buy = arr[i].Text;
                TreeNode currentNo = arr[i];
                while (currentNo.Parent != null)
                {
                    currentNo = currentNo.Parent;
                    string name = currentNo.Parent.Text;
                    string value = currentNo.Text.Substring(currentNo.Text.IndexOf("=") + 1);
                    setAttributeLuat(lstAtt, name, value, ref l);
                    currentNo = currentNo.Parent;
                }
                dsLuat.Add(l);
            }
        }

        //gán giá trị vào thuộc tính của  một luật truyền vào
        public void setAttributeLuat(List<string> dsAtt, string nameAtt, string value, ref Luat l)
        {
            int vt = -1;
            for (int i = 1; i < dsAtt.Count; i++)
            {
                if (nameAtt.Equals(dsAtt[i], StringComparison.OrdinalIgnoreCase))
                {
                    vt = i;
                    break;
                }
            }
            switch (vt)
            {
                case 1:
                    l.Age = value;
                    break;
                case 2:
                    l.Sex = value;
                    break;
                case 3:
                    l.Income = value;
                    break;
                case 4:
                    l.Configuration = value;
                    break;
                case 5:
                    l.Manufacturers = value;
                    break;
                case 6:
                    l.OS = value;
                    break;
                case 7:
                    l.Buy = value;
                    break;
            }
        }


        //Giao diện================================================
        private void btLamMoi_Click(object sender, EventArgs e)
        {
            startProgess();
            backgroundWorker1.RunWorkerAsync();
        }
        private void btNext_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < currentNode.Nodes.Count; i++)
            {
                TreeNode treeRoot = currentNode.Nodes[i];

                if (treeRoot.Text.Equals(comboBoxTraLoi.SelectedValue.ToString()))
                {
                    treeView1.SelectedNode = treeRoot;
                    treeView1.SelectedNode.Expand();
                    bool c = taoCauHoi(treeRoot.Nodes[0]);
                    currentNode = treeRoot.Nodes[0];
                    if(c){

                        Luat l = new Luat();
                        l.Buy = currentNode.Text;
                        TreeNode currentNo = currentNode;
                        while (currentNo.Parent != null)
                        {
                            currentNo = currentNo.Parent;
                            string name = currentNo.Parent.Text;
                            string value = currentNo.Text.Substring(currentNo.Text.IndexOf("=") + 1);
                            setAttributeLuat(lstAtt, name, value, ref l);
                            currentNo = currentNo.Parent;
                        }
                        luatTimDuoc = l;

                    }
                    break;
                }
            }
        }
        

        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.treeView1.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.FullPath != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.FullPath.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        this.toolTip1.SetToolTip(this.treeView1, theNode.FullPath.ToString());
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }
        }

        //Menu====================================================
        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHuongDanCauHinhCSDL f = new FormHuongDanCauHinhCSDL();
            f.Show();
        }
        private void dlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapDL dl = new FormNhapDL();
            dl.Show();
        }

        private void luatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLuat luat = new FormLuat(dsLuat, luatTimDuoc);
            luat.Show();
        }

        private void nhómHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/groups/yeuict/");
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yeuict.tk/");
        }

        private void nguyễnTiếnĐạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/TienDatPC");
        }

        private void hoàngTrọngKhangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/xivo.nat");
        }

        private void đỗThịHiênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100006737823098");
        }

        // các phương thức hỗ trợ trong giao diện

        private void startProgess()
        {
            enableTime();
            treeView1.Nodes.Clear();
            groupBoxProgess.Visible = true;
            btLamMoi.Enabled = false;
            comboBoxTraLoi.Enabled = false;
            btNext.Enabled = false;
            menuStrip1.Enabled = false;
            lbCauHoi.Text = "Câu hỏi!";

        }
        private void enableTime()
        {
            timer1.Enabled = true;
            timer1.Interval = 100;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pro++;
            if (pro >= proMax)
            {
                pro = 0;
            }
            iTalk_ProgressBar1.Value = pro;
        }

        private void customStyleNode(TreeNode t, Color c)
        {
            t.ForeColor = c;
        }
        //tạo câu hỏi mới
        public bool taoCauHoi(TreeNode node)
        {
            string sCauHoi = node.Text;

            List<string> ans = new List<string>();
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                ans.Add(node.Nodes[i].Text);
            }
            if (sCauHoi.Equals("No") || sCauHoi.Equals("Yes"))
            {
                btNext.Enabled = false;
                comboBoxTraLoi.Enabled = false;
                string message = "";
                if (sCauHoi.Equals("No"))
                {
                    message = "Bạn không nên mua Laptop";
                }
                if (sCauHoi.Equals("Yes"))
                {
                    message = "Bạn nên mua Laptop";
                }
               
                MessageBox.Show(message);
                return true;

            }
            else
            {
                lbCauHoi.Text = sCauHoi;
                comboBoxTraLoi.DataSource = ans;
                return false;
            }
        }

        private void iTalk_ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxTuVan_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

