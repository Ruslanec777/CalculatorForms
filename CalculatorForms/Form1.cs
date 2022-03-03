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
        public IExpression Expression { get; set; }
        public Form1()
        {
            InitializeComponent();

            SetDisplayText("0");

            Expression = new Expression();
        }

        private void AddMathObjectToAction(IMathObject mathObject)
        {
            throw new NotImplementedException();
        }

        private void ClickNumber(object sender, EventArgs e)
        {
            CustomButtonBase buttonBase = (CustomButtonBase)sender;

            IMathObject lastMathObject = Expression.Last();

            lastMathObject = lastMathObject as Number;

            if (lastMathObject is Number number)
            {
                if (number.isCompletedResult == true)
                {
                    Expression.Clear();

                    AddNewNumber(buttonBase);

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
            else
            {
                AddNewNumber(buttonBase);

            }

            //if (lastMathObject.GetType().Equals(typeof(Number)) && (Number)lastMathObject.) 
            //{
            //    Action.Actions.RemoveAt(Action.Actions.Count - 1);

            //    new Number(Action, DisplayTextBox.Text).AddYourselfToActionQueue();

            //}
        }

        private void AddNewNumber(CustomButtonBase buttonBase)
        {
            DisplayClear();

            SetDisplayText(buttonBase.Text);

            Number newNumber = new Number(Expression, GetDisplayText());

            Expression.Add(newNumber);
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

                    Expression.Add(new MathOperation(Expression, typesMathItems));

                    if (Expression.Last() is MathOperation mathOperation)
                    {
                        mathOperation.Run();
                    }

                    SetDisplayText((Number)Expression.Last());

                    return;
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

                default:
                    throw new Exception();
            }

            Expression.Add(new MathOperation(Expression, typesMathItems));
            //Action.Last().
        }

        private void ResultBtn_Click(object sender, EventArgs e)
        {
            Expression.Calculate();

            if (Expression.Last() is Number number)
            {
                SetDisplayText(number);
            }

        }
    }
}
