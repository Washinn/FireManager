﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireManager.Views
{
    public partial class CreateProcedure : Form
    {
        public CreateProcedure()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewForeignKeys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
