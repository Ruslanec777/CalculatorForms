using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using CalcLibrary.Models;
using CalculatorApplication.Models.ActionClasses;
using CalculatorApplication.Models.MathFunctions;
using Guna.UI2.WinForms.Suite;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CalculatorForms
{
    public partial class Form1 : Form
    {
        public IMathAction Action { get; set; }
        public Form1()
        {
            InitializeComponent();

            SetDisplayText("0");

            Action = new MathAction();
        }

        private void AddMathObjectToAction(IMathObject mathObject)
        {
            throw new NotImplementedException();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            CustomButtonBase buttonBase = (CustomButtonBase)sender;

            IMathObject lastMathObject = Action.Last();

            lastMathObject = lastMathObject as Number;

            if (lastMathObject is Number number)
            {
                if (number.isCompletedResult == true)
                {
                    Action.Clear();

                    DisplayClear();

                    SetDisplayText(buttonBase.Text);

                    Number newNumber = new Number(Action, GetDisplayText());

                    Action.Add(newNumber);

                    return;
                }
                else
                {
                    AddSymbolToDisplay(buttonBase.Text);

                    if (GetDisplayText()[0] == '0' && GetDisplayText()[1] != ',')
                    {
                        SetDisplayText(GetDisplayText().Remove(0, 1));
                    }

                    string str = GetDisplayText();

                    number.Text = str;
                }
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

        private void SetDisplayText(Number number)
        {
            DisplayTextBox.Text = number.Text;
        }

        private void SetDisplayText(string text)
        {
            DisplayTextBox.Text = text;
        }

        private string GetDisplayText()
        {
            return DisplayTextBox.Text;
        }

        private void MathFunctionBtn_Click(object sender, EventArgs e)
        {
            CustomButtonBase customButtonBase = (CustomButtonBase)sender;

            TypesMathItems typesMathItems;

            switch (customButtonBase.Text)
            {
                case "%":
                    typesMathItems = TypesMathItems.Percentage;

                    break;
                case "÷":
                    typesMathItems = TypesMathItems.Dev;

                    break;
                case "x":
                    typesMathItems = TypesMathItems.Mult;

                    break;
                case "-":
                    typesMathItems = TypesMathItems.Sub;

                    break;
                case "+":
                    typesMathItems = TypesMathItems.Sum;

                    break;
                case "=":
                    typesMathItems = TypesMathItems.Result;

                    break;

                default:
                    throw new Exception();
            }

            Action.Add(new MathFunction(Action, typesMathItems));
        }
    }
}
