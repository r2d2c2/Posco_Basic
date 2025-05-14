using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_11_Class_Interfase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("문서 작업 실행");
            Document document = new Document();
            document.Read();
            document.Write();
            document.Print();
            Console.WriteLine("인터페이스로 각각 제어");
            IReadable readable = new Document();
            readable.Read();
            IWritable writable = new Document();
            writable.Write();
            IPrintable printable = new Document();
            printable.Print();

            IReadable readable1 = new Document();
            IReadable readable2 = new PptDocument();
            IReadable readable3 = new PdfDocument();

        }
    }
}
