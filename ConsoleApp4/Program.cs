namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region # 기본 상속
            Rectangle rectangle = new Rectangle()
            {
                Name = "사각형",
                Width = 4,
                Height = 5
            };//객체 이니셜라이저(속성 값을 한번에 초기화)

            Triangle triangle = new Triangle()
            {
                Name = "삼각형",
                BaseLength = 6,
                Height = 3
            };
            Circle circle = new Circle()
            {
                Name = "원",
                Radius = 2
            };
            rectangle.PrintName();
            Console.WriteLine($"넓이 {rectangle.GetArea()}");
            triangle.PrintName();
            Console.WriteLine($"넓이 {triangle.GetArea()}");
            circle.PrintName();
            Console.WriteLine($"넓이 {circle.GetArea():F2}");
            Console.ReadLine();
            #endregion

            #region # 다단계 상속
            Console.WriteLine("-----------------------------");
            GrandChild grandChild = new GrandChild();
            grandChild.SayHello();
            grandChild.SayHello2();
            grandChild.SayHello3();
            grandChild.SayHello4();
            #endregion

            #region # base 키워드
            Console.WriteLine("-----------------------------");
            Parent parent = new Parent("홍길동", 60);
            Console.WriteLine("------------------------------");
            GrandChild grandChild2 = new GrandChild("John",70);
            Console.WriteLine("-----------------------------");
            Parent grandChild3 = new Parent();

            #endregion


        }
    }
}
