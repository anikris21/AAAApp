using System.Text;
namespace EncodingApp
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Encoding.Unicode.GetBytes(new char[] {'a'}) {}
            // Encoding.Unicode.GetBytes(new char[] {'\u6771'})
            Console.WriteLine($"a {Encoding.Unicode.GetByteCount(new char[] { 'a' })}" );


            // \U000 "" +  {Encoding.Unicode.GetBytes(new char[] { 'a' })}
            Console.WriteLine($"🃜 \U0001F0DC" + Encoding.Unicode.GetByteCount("\U0001F0DC"));

            int v = 0x0001F0DC;
            Console.WriteLine($"Unicode code points {v:X}  = ");
            show(Char.ConvertFromUtf32(v));
            



            Console.WriteLine("\u6771 " + Encoding.Unicode.GetByteCount(new char[] { '\u6771' }));



        }

        static void show(string s) {
            for (int i1 = 0; i1 < s.Length; i1++) {
                Console.WriteLine("0x{0:X} ", (int)s[i1]);
            }


        }
    }
}