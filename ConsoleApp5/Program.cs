namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog();
            animal.Name = "멍멍이";
            animal.Speak();// 업케스팅 
            ((Dog)animal).Bite();// 다운캐스팅
            animal =new Cat();
            animal.Name = "야옹이";
            animal.Speak();// 업케스팅
            ((Cat)animal).Scratch();// 다운캐스팅
            animal = new Bird();
            animal.Name = "짹짹이";
            animal.Speak();// 업케스팅
            ((Bird)animal).Fly();// 다운캐스팅

        }
    }
}
