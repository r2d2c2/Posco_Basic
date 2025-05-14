using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Console.WriteLine("숫자를 입력 하세요");
                string input = Console.ReadLine();
                int number = int.Parse(input);
                int result = 100 / number;
                Console.WriteLine($"100/ {number} = {result}");
                if(number<0)
                {
                    throw new Exception("음수는 입력할 수 없습니다.");
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("0으로 나눌수 없습니다.");
                Console.WriteLine(e.Message);//0으로 나누려 했습니다.
                string stackTrace = e.StackTrace;// 에러가 발생한 위치를 알려줌
                Console.WriteLine(stackTrace);
                Type type = e.GetType();// 에러의 종류를 알려줌
                Console.WriteLine(type);
                Console.WriteLine(e);// 에러 정보의 전부 출력
            }
            catch (FormatException e)
            {
                Console.WriteLine("숫자 형식이 아닙니다.");
                Console.WriteLine(e.Message);//입력 문자열의 형식이 잘못되었습니다.
            }
            catch (Exception e)
            {
                Console.WriteLine("알수 없는 에러");
                Console.WriteLine(e.Message);// 값이 크면: 값이 너무 크거나 작아 Int32 형식에 맞지 않습니다.
            }
            finally
            {
                Console.WriteLine("프로그램 종료");
            }

            try
            {
                throw new Exception("예외 발생");
            }
            catch
            {
                Console.WriteLine("catch 실행");
            }
        }
    }
}
