using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepaddd
{
    public partial class Form1 : Form
    {
        bool açıkvarmı = false;
        bool degisikvarmı = false;
        string açıkdadı = "";
        public Form1()
        {
            InitializeComponent();
        }
        public void dosyaAcma()
        {
            OpenFileDialog od = new OpenFileDialog();
            DialogResult basilan = od.ShowDialog();
           
            if(basilan== DialogResult.OK)
            {
                açıkdadı = od.FileName;
                açıkvarmı = true;
                degisikvarmı = false;
                richTextBox1.LoadFile(açıkdadı,RichTextBoxStreamType.PlainText);
            }

        }
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (açıkvarmı == false)
            {
                if (degisikvarmı == false)
                    dosyaAcma();
                else
                {
                    DialogResult basilan = MessageBox.Show("kaydedilsin mi?", "Notepad",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
                    if (basilan == DialogResult.No)
                    { dosyaAcma(); }
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(açıkdadı,RichTextBoxStreamType.PlainText);
                        }
                       
                    }



                }
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisikvarmı = true;
        }

        private void sözcükKaydırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sözcükKaydırToolStripMenuItem.Checked = !sözcükKaydırToolStripMenuItem.Checked;
            richTextBox1.WordWrap = sözcükKaydırToolStripMenuItem.Checked;
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void durumÇubuğuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            durumÇubuğuToolStripMenuItem.Checked = !durumÇubuğuToolStripMenuItem.Checked;
            statusStrip1.Visible = durumÇubuğuToolStripMenuItem.Checked;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();

        }
    }
}
