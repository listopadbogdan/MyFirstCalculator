﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        private string currentResult = "";

        public Form1()
        {
            InitializeComponent();
        }

        //private void button_Click(object sender, EventArgs e, string Key = "")
        //{
        //    currentResult += Key;
        //    textBoxOutput.Text = currentResult;
        //}

        private void button_Click(object sender, EventArgs e)
        {
            currentResult += (sender as Button).Text;

            textBoxOutput.Text = currentResult;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            string formattedResult = currentResult.Replace("x", "*").Replace(",", ".");
            if (formattedResult.Length < 0)
            {
                DeleteLastOperator(ref formattedResult);
            }

            try
            { 
                textBoxOutput.Text = new DataTable().Compute(formattedResult, null).ToString();
                currentResult = textBoxOutput.Text;
            }
            catch
            {
                textBoxOutput.Text = "0";
                currentResult = "";
            }

        }
        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "0";
            currentResult = "";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (currentResult.Length > 0)
            {
                currentResult = currentResult.Remove(currentResult.Length - 1, 1);
            }

            textBoxOutput.Text = currentResult;
        }

        private void DeleteLastOperator(ref string str) 
        {
            if (str.IndexOf("+") == str.Length - 1
                || str.IndexOf("-") == str.Length - 1
                || str.IndexOf("/") == str.Length - 1
                || str.IndexOf("*") == str.Length - 1)
            {
                str = str.Remove(str.Length - 1, 1);
            }
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Debug.WriteLine((char)e.KeyValue);
        //    //if ((e.KeyCode > Keys.D0 || e.KeyCode < Keys.D9)
        //    //        || (e.KeyCode > Keys.NumPad0 || e.KeyCode < Keys.NumPad9)
        //    //        || (e.KeyCode > Keys.Multiply || e.KeyCode < Keys.Divide))
        //    //{ 
        //    //    button_Click(sender, e, ((char)e.KeyCode).ToString());
        //    //}
            
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Debug.WriteLine("Enter");

        //        buttonEquals_Click(sender, e);
        //    }
        //}
    }
}
