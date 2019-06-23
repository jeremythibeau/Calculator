using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculation
    {
        private double var1;
        private double var2;
        
        public Calculation (double v1, double v2)
        {
            var1 = v1;
            var2 = v2;
        }
        public double addition(double v1, double v2)
        {
            return v1 + v2;
        }
        public double subtract(double v1, double v2)
        {
            return v1 - v2;
        }
        public double multiply(double v1, double v2)
        {
            return v1 * v2;
        }
        public double divide(double v1, double v2)
        {
            return v1/v2;
        }
        public void setv1(double v)
        {
            var1 = v;
        }
        public double getv1()
        {
            return var1;
        }
        //unused
        public double getv2()
        {
            return var2;
        }
        //unused
        public void setv2(double v)
        {
            var2 = v;
        }
    }
}
