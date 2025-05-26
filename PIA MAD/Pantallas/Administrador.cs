using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD.Pantallas
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            panelUsuarios.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
        }
    }
}
