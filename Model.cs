using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_4
{
    class Model
    {
        double num1, num2;
        string oper = null;
        string screen = null;
        private Action<string> callBackCalculateAction;
        private delegate double OperationDelegate(double x, double y);
        private Dictionary<string, OperationDelegate> Operations;

        public double NumberTaker
        {
            set
            {
                if (oper == null)
                {
                    num1 = value;
                    screen = "s";
                }
                else
                {
                    num2 = value;
                    screen = "s";
                }
            }
        }
        
        public double GetResults { get { return Calculate(num1, num2, oper); } }
        public string GetScreenClear { get { return screen; } set { this.screen = value; } }

        public Model()
        {
            Operations = new Dictionary<string, OperationDelegate>
                {
            { "+", this.DoAddition },
            { "-", this.DoSubtraction },
            { "*", this.DoMultiplication },
            { "/", this.DoDivision },
                };
        }

        public void OperTaker(string oper, Action<string> callBackAction)
        {
            
            if (this.oper == null)
            {
                this.oper = oper;
            }
            else if (oper == "=")
            {
                this.callBackCalculateAction = callBackAction; this.callBackCalculateAction(GetResults.ToString()); this.oper = null; num2 = 0;
            }
            else 
            {
                this.callBackCalculateAction = callBackAction; this.callBackCalculateAction(GetResults.ToString()); this.oper = oper; num2 = 0;
            }
        }

        private double Calculate(double x, double y, string oper)
        {
            if (!Operations.ContainsKey(oper))
            {
                throw new ArgumentException(string.Format("Operation {0} is invalid", oper), "oper");
            }
            else
            { 
                return this.num1 = Operations[oper](x, y);
            }            
            
        }

        private double DoDivision(double x, double y)
        {
            try
            {
                if (y == 0)
                {
                    throw new DivideByZeroException();
                }
            }
            catch
            {
                return -1;
            }

            return x / y;
        }
        private double DoMultiplication(double x, double y) { return x * y; }
        private double DoSubtraction(double x, double y) { return x - y; }
        private double DoAddition(double x, double y) { return x + y; }
    }
}
