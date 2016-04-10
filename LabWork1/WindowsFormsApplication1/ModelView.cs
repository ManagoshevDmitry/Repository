using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WindowsFormsApplication1
{
    public partial class ModelView : Form
    {
        private byte _catalogue;
        public ICatalogue Catalog { get; set; }

        public ModelView()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonStandard_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = true;
            _catalogue = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonElectronicResource_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = false;
            _catalogue = 1;
        }

        private void radioButtonDissertation_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = false;
            _catalogue = 2;
        }

        private void buttonGateDescription_Click(object sender, EventArgs e)
        {
            Model.ICatalogue catalogModel = null;
            switch (_catalogue)
            {
                case 0:
                    catalogModel = new Standard(Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text), Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text),Convert.ToString(textBox23.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
                    break;
                case 1:
                    catalogModel = new ElectronicResource(Convert.ToString(textBox7.Text), Convert.ToString(textBox8.Text), Convert.ToString(textBox9.Text), Convert.ToString(textBox10.Text), Convert.ToString(textBox11.Text), Convert.ToString(textBox12.Text), Convert.ToInt32(textBox13.Text), Convert.ToString(textBox14.Text));
                    break;
                case 2:
                    catalogModel = new Dissertation(Convert.ToString(textBox15.Text), Convert.ToString(textBox16.Text), Convert.ToString(textBox17.Text), Convert.ToString(textBox18.Text), Convert.ToString(textBox19.Text), Convert.ToString(textBox20.Text), Convert.ToInt32(textBox21.Text), Convert.ToInt32(textBox22.Text));
                    break;
            }
            Catalog = catalogModel;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
