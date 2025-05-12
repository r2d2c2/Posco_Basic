namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int test;

           

        }
        public static List<string> classifyEdges(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {
            List<string> result = new List<string>();
            List<List<int>> bitArrays = new List<List<int>>();
            List<int> bitArray = new List<int>();
            for (int i = 0; i < gFrom.Count; i++)
            {
                if (gWeight[i] == 1)
                {
                    bitArray.Add(1);
                    result.Add("YES");
                }
                else
                {
                    bitArray.Add(0);
                    result.Add("NO");
                }
                if (gFrom[i] == gTo[i])
                {
                    bitArray.Add(1);
                    result.Add("YES");
                }
                else
                {
                    bitArray.Add(0);
                    result.Add("NO");
                }
            }
        }

        public static List<int> sortBinaryNumbers(List<List<int>> bitArrays)
        {// 2진수로 데이터를 받아서 리스트로 담기
            List<int> result = new List<int>();
            foreach (List<int> i in bitArrays)
            {
                int sum = 0;
                for (int j = 0; j < i.Count; j++)
                {
                    sum += i[j] * (int)Math.Pow(2, i.Count - j - 1);
                }
                result.Add(sum);
            }
            return result;

        }
        public static long finalState(List<List<int>> operations)
        {
            foreach (List<int> i in operations)
            {
                foreach (int ii in i)
                {
                    if (ii == i[0])
                    {
                        Console.Write("-");
                    }
                    if (ii != null)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
            }
        }
    }
}
