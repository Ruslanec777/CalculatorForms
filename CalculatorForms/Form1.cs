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
        public IMathAction Action { get; set; } = new MathAction();
        public Form1()
        {
            InitializeComponent();

            SetDisplayText(Action.Last());

        }

        private void AddMathObjectToAction(IMathObject mathObject)
        {
            throw new NotImplementedException();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            CustomButtonBase buttonBase = (CustomButtonBase)sender;

            IMathObject lastMathObject = Action.Last();

            if (lastMathObject is Number tempNumber && tempNumber.isCompletedResult == true)
            {
                Action.Clear();

                DisplayClear();

                SetDisplayText(buttonBase.Text);

                Number newNumber = new Number(Action, GetDisplayText());

                Action.Add(newNumber);

                return;
            }
            else if (lastMathObject is Number tempNumber2 && tempNumber2.isCompletedResult == false)
            {
                AddSymbolToDisplay(buttonBase.Text);

                if (GetDisplayText()[0] == '0' && GetDisplayText()[1] != ',')
                {
                    SetDisplayText(GetDisplayText().Remove(0, 1));
                }

                string str= GetDisplayText();

                lastMathObject.Text= str;

                //str= lastMathObject.Text;
            }

            //if (lastMathObject.GetType().Equals(typeof(Number)) && (Number)lastMathObject.) 
            //{
            //    Action.Actions.RemoveAt(Action.Actions.Count - 1);

            //    new Number(Action, DisplayTextBox.Text).AddYourselfToActionQueue();

            //}
        }

        private void AddSymbolToDisplay(string text)
        {
            DisplayTextBox.Text += text;
        }

        private void DecPointBtnClick(object sender, EventArgs e)
        {
            if (!DisplayTextBox.Text.Any(x => x == ','))
            {
                ClickNumber(sender, e);
            }
        }

        private void DisplayClear()
        {
            DisplayTextBox.Text = "0";
        }

        private void SetDisplayText(IMathObject mathObject)
        {
            DisplayTextBox.Text = mathObject.Text;
        }

        private void SetDisplayText(string text)
        {
            DisplayTextBox.Text = text;
        }

        private string GetDisplayText()
        {
            return DisplayTextBox.Text;
        }
    }
}
