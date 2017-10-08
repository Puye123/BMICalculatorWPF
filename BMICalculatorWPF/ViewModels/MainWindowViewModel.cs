using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMICalculatorWPF.Models;
using System.ComponentModel;

namespace BMICalculatorWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region プロパティ
        private string _userHeight;
        /// <summary>
        /// 身長
        /// </summary>
        public string UserHeight
        {
            get { return _userHeight; }
            set
            {
                SetProperty(ref _userHeight, value);
                this.CalcBMICommand.RaiseCanExecuteChanged();
            }
        }

        private string _userWeight;
        /// <summary>
        /// 体重
        /// </summary>
        public string UserWeight
        {
            get { return _userWeight; }
            set
            {
                SetProperty(ref _userWeight, value);
                this.CalcBMICommand.RaiseCanExecuteChanged();
            }
        }

        private double _userBMI;
        /// <summary>
        /// BMI値
        /// </summary>
        public double UserBMI
        {
            get { return _userBMI; }
            set { SetProperty(ref _userBMI, value); }
        }

        private int _userBMIGraphWidth;
        /// <summary>
        /// BMIグラフ横幅
        /// </summary>
        public int UserBMIGraphWidth
        {
            get { return _userBMIGraphWidth; }
            set { SetProperty(ref _userBMIGraphWidth, value); }
        }

        private int _windowWidth;
        /// <summary>
        /// Window横幅
        /// </summary>
        public int WindowWidth
        {
            get { return _windowWidth; }
            set {
                SetProperty(ref _windowWidth, value);
                this.UserBMIGraphWidth = (int)(this.WindowWidth / 50 * this.UserBMI);
            }
        }
        #endregion

        public DelegateCommand CalcBMICommand { private set;  get; }
        public CalcBMI calcBMI;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            this.CalcBMICommand = new DelegateCommand(CalcBMIExecute, CanCalcBMIExecute);
            this.calcBMI = new CalcBMI();
            this.WindowWidth = 300;

            this.calcBMI.PropertyChanged += this.CalcBMIPropertyChanged;
        }

        private void CalcBMIPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "BMI")
            {
                this.UserBMI = this.calcBMI.BMI;
                this.UserBMIGraphWidth = (int)(this.WindowWidth / 50 * this.UserBMI);
            }
        }


        #region BMI計算コマンド
        /// <summary>
        /// CalcBMIExecuteを実行しても良いか
        /// </summary>
        /// <returns></returns>
        private  bool CanCalcBMIExecute()
        {
            double dummy;
            if (!double.TryParse(this.UserHeight, out dummy)) return false;
            if (!double.TryParse(this.UserWeight, out dummy)) return false;

            return true;
        }

        /// <summary>
        /// BMIの計算を行う
        /// </summary>
        private  void CalcBMIExecute()
        {
            this.calcBMI.Calculate(double.Parse(this.UserHeight), double.Parse(this.UserWeight));
        }
        #endregion
    }
}
