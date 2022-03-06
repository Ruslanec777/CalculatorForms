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

        private void ClickNumber(object sender, EventArgs e)
        {
            CustomButtonBase buttonBase = (CustomButtonBase)sender;

            IMathObject lastMathObject = Expression.Last();

            //lastMathObject = lastMathObject as Number;

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

                    SetDisplayText(NormaliseNumber());

                    string str = GetDisplayText();

                    number.Text = str;
                }
            }
            else
            {
                AddNewNumber(buttonBase);
            }
        }

        private string NormaliseNumber()
        {
            if (GetDisplayText().Length > 1 && GetDisplayText()[0] == '0' && GetDisplayText()[1] != ',')
            {
                return (GetDisplayText().Remove(0, 1));
            }

            if (GetDisplayText().Length > 2 && GetDisplayText()[0] == '-' && GetDisplayText()[1] == '0' && GetDisplayText()[2] != ',')
            {
                return (GetDisplayText().Remove(1, 1));
            }

            return GetDisplayText();
        }

        private void AddNewNumber(CustomButtonBase buttonBase)
        {
            DisplayClear();

            SetDisplayText(buttonBase.Text);

            Number newNumber = new Number(Expression, GetDisplayText());

            Expression.Add(newNumber);
        }

        private void AddNewNumber(Number number)
        {
            DisplayClear();

            SetDisplayText(number.Text);

            Expression.Add(number);
        }

        private void AddSymbolToDisplay(string text)
        {
            if (!CheckValidNumber(text))
            {
                return;
            }
            DisplayTextBox.Text += text;
        }

        private bool CheckValidNumber(string text)
        {
            switch (GetDisplayText().Length)
            {
                case 1:
                    if (GetDisplayText()[0] == '0' && text == "0")
                        return false;
                    break;

                case 2:
                    if (GetDisplayText()[0] == '-' && GetDisplayText()[0] == '0' && text == "0")
                        return false;

                    break;

                default:
                    return true;
            }


            if (GetDisplayText().Length == 2 && GetDisplayText()[0] == '-' && GetDisplayText()[1] == '0' && text == "0")
            {
                return false;
            }


            return true;
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

        private void signBtn_Click(object sender, EventArgs e)
        {

            IMathObject lastMathObject = Expression.Last();

            if (lastMathObject is Number number)
            {
                if (number.isCompletedResult == true)
                {
                    Expression.Clear();

                    Number newNumber = new Number(Expression);
                    newNumber.SetNegative();

                    AddNewNumber(newNumber);

                    return;
                }
                else
                {
                    number.ChangeSign();
                    SetDisplayText(number.Text.ToString());
                }
            }
            else
            {
                Number newNumber = new Number(Expression);
                newNumber.SetNegative();

                AddNewNumber(newNumber);

            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Expression.Clear();
            Expression.Add(new Number(Expression));
            SetDisplayText((Number)Expression.Last());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
