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

        private void button6_Click(object sender, EventArgs e)
        {
            Registrar_Usuario registrar_usuario = new Registrar_Usuario();
            registrar_usuario.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Editar_Usuario editar_usuario = new Editar_Usuario();
            editar_usuario.Show();
        }
    }
}
