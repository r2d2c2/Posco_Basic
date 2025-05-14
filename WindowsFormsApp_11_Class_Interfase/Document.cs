using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_11_Class_Interfase
{
    interface IReadable
    {
        void Read();
    }
    public interface IWritable
    {
        void Write();
    }
    public interface IPrintable
    {
        void Print();
    }
    public class Document : IReadable,IWritable,IPrintable
    {
        public void Read()
        {
            Console.WriteLine("문서를 읽습니다.");
        }
        public void Write()
        {
            Console.WriteLine("문서를 작성합니다.");
        }
        public void Print()
        {
            Console.WriteLine("문서를 인쇄합니다.");
        }

    }
    public class PptDocument: IReadable, IWritable, IPrintable
    {
        public void Read()
        {
            Console.WriteLine("PPT 문서를 읽습니다.");
        }
        public void Write()
        {
            Console.WriteLine("PPT 문서를 작성합니다.");
        }
        public void Print()
        {
            Console.WriteLine("PPT 문서를 인쇄합니다.");
        }
    }
    public class PdfDocument : IReadable, IWritable, IPrintable
    {
        public void Read()
        {
            Console.WriteLine("PDF 문서를 읽습니다.");
        }
        public void Write()
        {
            Console.WriteLine("PDF 문서를 작성합니다.");
        }
        public void Print()
        {
            Console.WriteLine("PDF 문서를 인쇄합니다.");
        }
    }
