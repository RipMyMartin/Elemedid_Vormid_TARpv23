namespace Elemendid_vormist_TARpv23
{
    public partial class StartVorm : Form
    {
        List<string> elemendid = new List<string>
        {
            "Nupp", "Silt", "Pilt","Märkeruut"
        };
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pbox;
        CheckBox chk1, chk2;

        private Image imgChecked;
        private Image imgUnchecked;

        public StartVorm()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";

            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid: ");
            foreach (var element in elemendid)
            {
                tn.Nodes.Add(new TreeNode(element));
            }


            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            //Nupp - Button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;

            //Silt - Label
            lbl = new Label();
            lbl.Text = "Aknade elemendid C# abil ";
            lbl.Font = new Font("Arial", 15, FontStyle.Bold);
            lbl.Size = new Size(300, 50);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;

            pbox = new PictureBox();
            pbox.Size = new Size(150, 150);
            pbox.Location = new Point(150, btn.Height + lbl.Height + 5);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            pbox.Image = Image.FromFile(@"..\..\..\Pilt1.jpg");
            pbox.DoubleClick += Pbox_DoubleClick;

        }
        int tt = 0;
        private void Pbox_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "Pilt1.jpg", "Pilt2.jpg", "Pilt3.jpg", "Pilt4.jpg" };
            string fail = pildid[tt];
            pbox.Image = Image.FromFile(@"..\..\..\" + fail);
            tt++;
            if (tt == 3)
            {
                tt = 0;
            }
        }

        private void Lbl_MouseHover(object? sender, EventArgs e)
        {
            //lbl.Size = new Size(700, 30);
            //lbl.Location = new Point(300, 70);
            lbl.Text = "Ебать ты Пидорас";
            lbl.ForeColor = Color.Red;
        }
        private void Lbl_MouseLeave(object? sender, EventArgs e)
        {
            //lbl.Size = new Size(300, 50);
            //lbl.Location = new Point(150, 0);
            lbl.Text = "Aknade elemendid C# abil ";
            lbl.ForeColor = Color.Blue;
        }

        int t = 0;
        private void Btn_Click(object? sender, EventArgs e)
        {
            t++;
            if (t % 2 == 0)
            {
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.BackColor = Color.Green;
            }

        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pbox);
            }
            else if (e.Node.Text == "Märkeruut")
            {
                chk1 = new CheckBox();
                chk1.Checked = false;
                chk1.Text = e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length * 10, chk1.Size.Height);
                chk1.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + 10);
                chk1.CheckedChanged += new EventHandler(Chk_CheckedChanger);

                chk2 = new CheckBox();
                chk2.Checked = false;

                chk2.Size = pbox.Size;
                chk2.BackgroundImage = Image.FromFile(@"..\..\..\Pilt3.jpg");
                chk2.BackgroundImageLayout = ImageLayout.Zoom;

                chk2.Size = new Size(100, 100);
                chk2.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + 20);

                Controls.Add(chk1);
                Controls.Add(chk2);
            }
            imgChecked = Image.FromFile(@"..\..\..\Pilt3.jpg");
            imgUnchecked = Image.FromFile(@"..\..\..\Pilt4.jpg");
            chk1.BackgroundImage = imgUnchecked;
            //Start

        }

        private void Chk_CheckedChanger(object? sender, EventArgs e)
        {
            if (chk1.Checked)
            {
                chk1.BackgroundImage = imgChecked;
            }
            else
            {
                chk1.BackgroundImage = imgUnchecked;
            }
        }
        private void Chk_CheckedChanger(object? sender, EventArgs e)
        {
            if (chk1.Checked)
            {
                chk1.BackgroundImage = imgChecked;
            }
            else
            {
                chk1.BackgroundImage = imgUnchecked;
            }
        }
    }
}
