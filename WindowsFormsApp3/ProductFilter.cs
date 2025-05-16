using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public delegate bool ProductCondition(Product product); //존건 함수 델리케이트
    internal class ProductFilter
    {
        public static List<Product> Filter(List<Product> products,ProductCondition condition)
        {
            List<Product> result=new List<Product>();
            // 조건에 맞는 제품을 저장

            foreach(var p in products)
            {
                if(condition(p))
                {
                    result.Add(p);
                }
            }
            return result;
        }

    }
}
