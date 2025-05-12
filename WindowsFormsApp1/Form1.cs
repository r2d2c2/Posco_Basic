using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region # 구조체 정의
        struct Point
        {
            public int x;
            internal int y;// 같은 프로젝트 안에서 접근 허용
            public int z;
            public int Diff_xy() => x - y;
        }
        #endregion
        #region # 실습1
        struct Point2
        {
            public int x;
            public int x2;
            public int y;
            public int y2;
            // x,y 거리 구하기
            public static double Distance(int x,int y,int x2,int y2) => Math.Sqrt( Math.Pow((x - x2) + (y - y2),2));
        }
        #endregion
        #region # 실습2
        struct Student
        {
            public string name;
            public int age;
            public int score;
            public void print() => Console.WriteLine($"이름 : {name}, 나이 : {age}, 점수 : {score}");
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            #region # 구조체 사용
            Point point1=new Point();//기본값을 가진 구조체를 생성
            //변수에 값이 없으며 0으로 초기화됨
            Point point2;//선언만 해도 메모리에 할당됨(초기화 없음)
            point2.x = 10;

            point1.x = 10;
            point2.x = 31;
            Point point3 = new Point();
            point3.x = 20;
            point3.y = 40;
            int diff = point3.Diff_xy();
            Console.WriteLine($"point {point3.x},{point3.y},{point3.z}, 함수값 : {diff}");

            Point[] p=new Point[3];
            for(int i=0;i<p.Length; i++)
            {
                p[i].x = i;
                p[i].y = i * i;
                p[i].z = -i;
                Console.WriteLine($"p[{i}] ({p[i].x},{p[i].y},{p[i].z})");
            }
            Console.WriteLine(add(1, 2));
            hello();
            #endregion

            #region # 실습1 사용
            Console.WriteLine("----------------------------------");
            string[] str = Console.ReadLine().Split(' ');
            Point2 myPoint;
            int.TryParse(str[0], out myPoint.x);
            int.TryParse(str[1], out myPoint.y);
            int.TryParse(str[2], out myPoint.x2);
            int.TryParse(str[3], out myPoint.y2);
            Console.WriteLine(Point2.Distance(myPoint.x,myPoint.y,myPoint.x2,myPoint.y2));
            #endregion

            #region # 실습2 사용
            Console.WriteLine("------------------------------");
            string[] infor = Console.ReadLine().Split(' ');
            Student[] student = new Student[3]
            {
                new Student { name = infor[0], age = Convert.ToInt32(infor[1]), score = Convert.ToInt32(infor[2]) },
                new Student { name = infor[3], age = Convert.ToInt32(infor[4]), score = Convert.ToInt32(infor[5]) },
                new Student { name = infor[6], age = Convert.ToInt32(infor[7]), score = Convert.ToInt32(infor[8]) }
            };
            for (int i = 0; i < student.Length; i++)
            {
                student[i].print();
            }
            #endregion

            button1.Click += (s, e) => ((Button)s).BackColor = Color.Red;
        }

        int add(int a, int b) => a + b;
        void hello() => Console.WriteLine("hello");
    }
}
