﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public Product(string name, int price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public override string ToString() //기본 ToString은 클레스 이름만 나옴
        {
            return $"{Name} / {Price} / {Category}";
        }
    }
}
