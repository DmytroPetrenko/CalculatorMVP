using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Events_4
{
    class Presenter
    {
        Model model;
        MainWindow mainWindow;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.model = new Model();
            this.mainWindow.ButtonEvent += MainWindow_ButtonEvent;
            this.mainWindow.ButtonActionEvent += MainWindow_ButtonActionEvent;
        }

        public void ChangeScreen(string value)
        {
            this.mainWindow.Screen.Text = value;
        }

        public void ClearScreen()
        {
            this.mainWindow.Screen.Text = "";
        }

        private void MainWindow_ButtonActionEvent(object sender, EventArgs e)
        {
            this.model.NumberTaker = Double.Parse(this.mainWindow.Screen.Text);

            switch (((Button)sender).Content.ToString())
            {
                case "+":                    
                    this.model.OperTaker("+", ChangeScreen);
                    break;
                case "-":
                    this.model.OperTaker("-", ChangeScreen);
                    break;
                case "*":
                    this.model.OperTaker("*", ChangeScreen);
                    break;
                case "/":
                    this.model.OperTaker("/", ChangeScreen);
                    break;
                case "=":
                    this.model.OperTaker("=", ChangeScreen);
                    break;
                default:
                    break;
            }                        
        }

        private void MainWindow_ButtonEvent(object sender, EventArgs e)
        {
            if (this.model.GetScreenClear != null)
            {
                ClearScreen();
                this.model.GetScreenClear = null;
            }

            this.mainWindow.Screen.Text += ((Button)sender).Content.ToString();
        }
    }
}
