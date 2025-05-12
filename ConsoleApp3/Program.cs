namespace ConsoleApp3
{
    internal class Car
    {
        private int seepd;
        private string modelName;
        private int year;

        //상수 생성
        private const int MAX_SPEED = 200;

        //초기화 이후 값을 바꿀 수 없음
        private readonly string manufacturer = "Hyundai";

        //모든 객체가 공유하는 값
        private static int totalCars = 0;

        public int Speed { get; set; }
        public int MySpeed {
            get { return MySpeed; }
            set
            {
                if (value > MAX_SPEED)
                {
                    Console.WriteLine("속도가 너무 빠릅니다.");
                    Speed = MAX_SPEED;
                }
                else
                {
                    Speed = value;
                }
            }
        }
        public bool IsNewCar
        {
            get
            {
                return year >= 2023;
            }
        }

        public Car()
        {
            modelName = "소나타";
            year = 2023;
            Speed = 0;
            totalCars++;
            Console.WriteLine($"제조사 : {manufacturer}, 모델명 : {modelName}, 연식 : {year}");
        }
        public Car(string modelName, int year)
        {
            this.modelName = modelName;
            this.year = year;
            Speed = 0;
            totalCars++;
            Console.WriteLine($"제조사 : {manufacturer}, 모델명 : {modelName}, 연식 : {year}");
        }
        ~Car()
        {
            Console.WriteLine($"{modelName} 소멸 합니다");
        }


        public void Accelerate(int amount)
        {
            Speed += amount;
            Console.WriteLine($"{modelName} 속도가 {Speed} 증가 했습니다");
        }
        public void Brake(int amount)
        {
            Speed-=amount;
            if(Speed < 0)
            {
                Speed = 0;
            }
            Console.WriteLine($"{modelName}속도가 {Speed} 감소 했습니다");
        }
        public void PrintInfo()
        {
            Console.WriteLine("====차량 정보=====");
            Console.WriteLine($"제조사 {manufacturer}");
            Console.WriteLine($"모델명 {modelName}");
            Console.WriteLine($"속도 {Speed}");
            Console.WriteLine($"생산년도 {year}");
            Console.WriteLine($"신차여부 {(IsNewCar?"신차":"구형차량")}");
            Console.WriteLine($"총 샌산 차량 수 {totalCars}");
        }

        public static void ShowTotalCars()
        {
            Console.WriteLine($"총 생산 차량 수 : {totalCars}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.MySpeed = 20;
            car1.PrintInfo();

            Car.ShowTotalCars();
        }
    }
}
