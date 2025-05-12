using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        class MyList<T>
        {
            public int count = 0;
            T[] arr=new T[1];
            public void Add(T item)
            {
                if (arr.Count() >= count)
                {// 배열이 가득 차면
                    T[] myArr = new T[arr.Length * 2];
                    // *2배열을 만들어 이동
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]=myArr[i];
                    }
                    arr = myArr;    
                    count++;
                    arr[count] = item;
                }
                else
                {
                    arr[count] = item;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            Console.ReadLine();
            Console.WriteLine("================new Square 클레스 입니다==============");
            Square s1 = new Square();
            Console.WriteLine($"s1 넓이를 {s1.GetArea()}");
            Console.WriteLine("------------------------------------------------------");
            Square s2 = new Square(5);
            Console.WriteLine($"s2 넓이 : {s2.GetArea()}");
            Console.WriteLine("=========================파티션 클레스=================");
            Square2 s3 = new Square2();
            Console.WriteLine($"s3넓이는 {s3.GetArea()}");
            Square2 s4 = new Square2(7);
            Console.WriteLine($"s4넓이는 {s4.GetArea()}");

            Console.WriteLine("======================구조체&클레스===================");
            PointStruct ps1 = new PointStruct { x = 10, y = 20 };
            PointStruct ps2 = ps1;//깊은 복사
            ps2.x = 99;
            ps1.Print();//10,20
            ps2.Print();
            Console.WriteLine();
            PointClass pc1 = new PointClass { x = 10, y = 20 };
            PointClass pc2 = pc1;//참조 복사(얕은 복사)
            pc2.x = 99;
            pc1.Print();//99,20
            pc2.Print();

        }
        #region #구조체와 클레스의 차이점
        // 구조체 값형식
        struct PointStruct
        {
            public int x;
            public int y;
            public void Print()
            {
                Console.WriteLine($"struct Point : {x},{y}");
            }
        }
        //클레스는 참조형식
        class PointClass
        {
            public int x;
            public int y;
            public void Print()
            {
                Console.WriteLine($"class point : {x},{y}");
            }
        }

        #endregion
    }
}
