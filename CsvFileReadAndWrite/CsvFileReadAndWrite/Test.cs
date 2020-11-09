using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvFileReadAndWrite
{
    class Test
    {
        StreamReader sr;
        public void ReadFile()
        {
            string path = @"c:\chichi\MyTest.txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("This");
                    sw.WriteLine("is some text");
                    sw.WriteLine("to test");
                    sw.WriteLine("Reading");
                }

                sr = new StreamReader(path);
                //This is an arbitrary size for this example.
                char[] c = null;

                while (sr.Peek() >= 0)
                {
                    c = new char[5];
                    sr.Read(c, 0, c.Length);
                    //The output will look odd, because
                    //only five characters are read at a time.
                    Console.WriteLine(c);
                    Console.WriteLine("position : " + sr.BaseStream.Position);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }


    }
}
