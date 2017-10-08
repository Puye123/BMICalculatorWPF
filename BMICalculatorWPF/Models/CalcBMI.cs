using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculatorWPF.Models
{
    public class CalcBMI : BindableBase
    {
        private double _bmi;
        public double BMI
        {
            get { return _bmi; }
            set { SetProperty(ref _bmi, value); }
        }

        public CalcBMI()
        {

        }

        public void Calculate(double height, double weight)
        {
            double heightMeter = height / 100;
            this.BMI = weight / (heightMeter * heightMeter);
        }
    }
}
