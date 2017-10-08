using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculatorWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculatorWPF.ViewModels.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        [TestMethod()]
        public void CanCalcBMIExecute_正常系_身長体重ともにdouble型()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserHeight = "170.0";
            mainWindowViewModel.UserWeight = "65.0";
            var privateObject = new PrivateObject(mainWindowViewModel);
            var actual = privateObject.Invoke("CanCalcBMIExecute");
            var expected = true;

            System.Console.WriteLine("UserHeight: {0},  UserWeight: {1},  actual: {2},  expected: {3}", mainWindowViewModel.UserHeight, mainWindowViewModel.UserWeight, actual, expected);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CanCalcBMIExecute_正常系_身長が非double型()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserHeight = "あああ";
            mainWindowViewModel.UserWeight = "65.0";
            var privateObject = new PrivateObject(mainWindowViewModel);
            var actual = privateObject.Invoke("CanCalcBMIExecute");
            var expected = false;

            System.Console.WriteLine("UserHeight: {0},  UserWeight: {1},  actual: {2},  expected: {3}", mainWindowViewModel.UserHeight, mainWindowViewModel.UserWeight, actual, expected);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CanCalcBMIExecute_正常系_体重が非double型()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserHeight = "170.0";
            mainWindowViewModel.UserWeight = "あああ";
            var privateObject = new PrivateObject(mainWindowViewModel);
            var actual = privateObject.Invoke("CanCalcBMIExecute");
            var expected = false;

            System.Console.WriteLine("UserHeight: {0},  UserWeight: {1},  actual: {2},  expected: {3}", mainWindowViewModel.UserHeight, mainWindowViewModel.UserWeight, actual, expected);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CanCalcBMIExecute_正常系_身長がnull()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserHeight = null;
            mainWindowViewModel.UserWeight = "65.0";
            var privateObject = new PrivateObject(mainWindowViewModel);
            var actual = privateObject.Invoke("CanCalcBMIExecute");
            var expected = false;

            System.Console.WriteLine("UserHeight: {0},  UserWeight: {1},  actual: {2},  expected: {3}", mainWindowViewModel.UserHeight, mainWindowViewModel.UserWeight, actual, expected);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CanCalcBMIExecute_正常系_体重がnull()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.UserHeight = "170.0";
            mainWindowViewModel.UserWeight = null;
            var privateObject = new PrivateObject(mainWindowViewModel);
            var actual = privateObject.Invoke("CanCalcBMIExecute");
            var expected = false;

            System.Console.WriteLine("UserHeight: {0},  UserWeight: {1},  actual: {2},  expected: {3}", mainWindowViewModel.UserHeight, mainWindowViewModel.UserWeight, actual, expected);

            Assert.AreEqual(actual, expected);
        }

    }
}