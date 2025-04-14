using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AobToByte
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputBox.Text))
                {
                    UpdateStatus("Please enter a value!", Color.Red);
                    return;
                }

                string result = ComboBox.SelectedIndex == 0
                    ? ConvertAobToByteArray(inputBox.Text)
                    : ConvertByteArrayToAob(inputBox.Text);

                resultBox.Text = result;
                UpdateStatus("Conversion successful!", Color.Green);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", Color.Red);
            }
        }

        private string ConvertAobToByteArray(string input)
        {
           
            input = Regex.Replace(input, @"[\s,;]+", " ").Trim();
            var elements = input.Split(' ');
            var result = new StringBuilder();

            foreach (var element in elements)
            {
                if (string.IsNullOrWhiteSpace(element))
                    continue;

                if (element == "??")
                {
                    result.Append("'?', ");
                }
                else if (IsValidHex(element, 2))
                {
                    result.Append($"0x{element.ToUpper()}, ");
                }
                else if (IsValidHex(element, 4))
                {
                    // Conserver les valeurs 16-bit comme 0xCC00
                    result.Append($"0x{element.ToUpper()}, ");
                }
                else
                {
                    throw new FormatException($"Invalid hex value: {element}");
                }
            }

            return result.ToString().TrimEnd(',', ' ');
        }

        private string ConvertByteArrayToAob(string input)
        {
           
            string cleaned = input.Replace("0x", "")
                                 .Replace(" ", "")
                                 .Replace("?", "??")
                                 .Replace("'", "");

            
            string[] bytes = cleaned.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();
            foreach (string byteStr in bytes)
            {
                string formattedByte = byteStr.Trim().PadLeft(2, '0').ToUpper();
                result.Append(formattedByte + " ");
            }

            return result.ToString().Trim();
        }

        private bool IsValidHex(string value, int length)
        {
            if (value == "?" || value == "??") return true;
            if (value.Length != length) return false;
            return Regex.IsMatch(value, @"^[0-9a-fA-F?]+$");
        }




        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputBox.Clear();
            resultBox.Clear();

            if (ComboBox.SelectedIndex == 0)
            {
                inputBox.PlaceholderText = "Enter AOB";
                resultBox.PlaceholderText = "Resulting Byte Array";
            }
            else
            {
                inputBox.PlaceholderText = "Enter Byte Array";
                resultBox.PlaceholderText = "Resulting AOB";
            }
            UpdateStatus($"Mode changed to: {ComboBox.Text}", Color.Blue);
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resultBox.Text))
            {
                UpdateStatus("No result to copy!", Color.Red);
                return;
            }

            Clipboard.SetText(resultBox.Text);
            UpdateStatus("Result copied to clipboard!", Color.Green);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputBox.Clear();
            resultBox.Clear();
            UpdateStatus("Fields cleared", Color.Blue);
        }

        private void UpdateStatus(string message, Color color)
        {
            status.ForeColor = color;
            status.Text = message;

          
            var timer = new Timer { Interval = 3000 };
            timer.Tick += (s, e) =>
            {
                status.Text = string.Empty;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void registreBtn_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            string githubUrl = "https://github.com/paulafredo/AobToByte";

            try
            {

                System.Diagnostics.Process.Start(githubUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //private void label5_Click(object sender, EventArgs e)
            //{
            //    
            //    string githubUrl = "https://github.com/paulafredo/AobToByte";

            //    try
            //    {
            //        
            //        System.Diagnostics.Process.Start(githubUrl);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Impossible d'ouvrir le lien: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }

        }


    }
}



