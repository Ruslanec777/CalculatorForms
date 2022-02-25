using CalcLibrary.Interfaces;
using CalcLibrary.Models;
using CalculatorApplication.Models.ActionClasses;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForms
{
    public partial class Form1 : Form
    {
        public IMathAction Action { get; set; }= new MathAction();
        public Form1()
        {
            InitializeComponent();
            new Number (Action,  DisplayTextBox.Text).AddYourselfToActionQueue() ;
            
        }

        private void AddMathObjectToAction(IMathObject mathObject)
        {
            throw new NotImplementedException();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            CustomButtonBase buttonBase = (CustomButtonBase)sender;

            DisplayTextBox.Text += buttonBase.Text;

            if (DisplayTextBox.Text[0] == '0' && DisplayTextBox.Text[1] != ',')
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Remove(0, 1);
            }

            if (Action.Actions.Last().GetType().Equals(typeof(Number))) 
            {
                Action.Actions.RemoveAt(Action.Actions.Count - 1);

                new Number(Action, DisplayTextBox.Text).AddYourselfToActionQueue();

            }
        }

        private void DecPointBtnClick(object sender, EventArgs e)
        {
            if (!DisplayTextBox.Text.Any(x => x == ','))
            {
                ClickNumber(sender, e);
            }
        }
    }
}
