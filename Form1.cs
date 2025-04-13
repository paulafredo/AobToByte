using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AobToByte
{
    public partial class AobToByte: Form
    {
        public AobToByte()
        {
            InitializeComponent();
        }

        private void AobToByte_Load(object sender, EventArgs e)
        {

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            string input = inputBox.Text.Trim();
            string result = "";

            if (comboBoxMode.SelectedIndex==0)
            {
                var bytes = input.Split(new[] { ' ', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries);
                result = string.Join(", ", bytes.Select(b => $"0x{b.ToLower()}"));

            }
            else
            {
                var parts = input.Split(new[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                result = string.Join(" ", parts.Select(p => p.Replace("0x", "").ToLower()));

            }
            resultsBox.Text = result;

        }         
    }
}





