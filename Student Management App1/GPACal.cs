using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_App1
{
    internal class GPACal
    {
        private double sum = 0;
        private int n = 0;
        public double addGPA(double gpax)
        {
            this.sum += gpax;
            this.n++;
            double result = this.sum / this.n;
            return result;
        }
        /*public double getGpax()
        {
            
        }*/
    }
}
