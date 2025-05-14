using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_11_Ref
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            #region # ref,out
            //int num = 10;
            //ChangeValue(num);
            //Console.WriteLine(num);
            //ChangeValue2(ref num);
            //Console.WriteLine(num);

            ////out 은 return 처럼 값을 만들어서 돌려주는데 여러값을 돌려 줄수 있다.
            //int outNum;
            ////ChangeValue2(ref outNum);// 에러
            //ChangeValue3(out outNum);
            //Console.WriteLine(outNum);

            //int result, result2;
            //Divide(10, 3, out result, out result2);
            //Console.WriteLine($"목 {result} 나머지{result2}");
            #endregion
            #region # ref 실습
            int[] arrRef = new int[5];
            FillArray(ref arrRef);
            Console.WriteLine($"[ref] 배열의 값{string.Join(" ",arrRef)} ");
            #endregion

            #region # out 실습
            int[] arrOut;
            FillArray2(out arrOut, 5);
            Console.WriteLine($"[out] 배열 값 : {string.Join(" ",arrOut)}");
            #endregion
        }
        #region # ref, out
        void ChangeValue(int x) => x = 99;
        void ChangeValue2(ref int x) => x = 99;
        void ChangeValue3(out int x) => x = 100;

        void Divide(int a, int b, out int result, out int result2)
        {
            result = a / b;
            result2 = a % b;
        }
        #endregion
        #region # ref 실습
        // 배열 채우기
        void FillArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }
        #endregion

        #region out 실습
        void FillArray2(out int[] arr, int size)
        {
            arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
        }
        #endregion
    }
}