using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonarr = @"{""errors"": {""title"": [""can't be blank""]}}";

            dynamic dynJson = JsonConvert.DeserializeObject(jsonarr);
            foreach (var item in dynJson)
            {
                // access dynamic property here
            }
        }   

        delegate string StringDelegate(string s);

        static void Benchmark(string description, StringDelegate d, int times, string text)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < times; j++)
            {
                d(text);
            }
            sw.Stop();
            Console.WriteLine("{0} Ticks {1} : called {2} times.", sw.ElapsedTicks, description, times);
        }

        public static string ReverseArray(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        public static string ReverseXor(string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }

            return new string(charArray);
        }

        public static string ReverseClassic(string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length-1;

            for (int i = 0; i < len; i++, len--)
            {
                char temp = charArray[len];
                charArray[len] = charArray[i];
                charArray[i] = temp;
            }
            return new string(charArray);
        }

        public static string StringOfLength(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }
            return sb.ToString();
        }

        static void Mainfdsafdsf(string[] args)
        {
            Console.WriteLine(ReverseClassic("abcdefgh"));
            Console.WriteLine(ReverseXor("abcdefgh"));

            int[] lengths = new int[] { 1, 10, 100, 1000, 10000, 100000 };

            foreach (int l in lengths)
            {
                int iterations = 10000;
                string text = StringOfLength(l);                
                Benchmark(String.Format("Classic (Length: {0})", l), ReverseClassic, iterations, text);
                Benchmark(String.Format("Array (Length: {0})", l), ReverseArray, iterations, text);
                Benchmark(String.Format("Xor (Length: {0})", l), ReverseXor, iterations, text);
                Console.WriteLine();
            }
            Console.Read();
        }


        public static void Main1111(string[] args)
        {
            Action action = printStuff;
            ExecuteEvery(action, 500).Wait();
            //simulate the rest of the application stalling until shutdown events.
            Console.ReadLine();
        }

        private static int x = 0;

        private static void printStuff()
        {
            Console.WriteLine(value: $"Thread Id {AppDomain.GetCurrentThreadId()}, Count {x++}");
        }

        private static async Task ExecuteEvery(Action execute, int milliseconds)
        {
            while (true)
            {
                execute();
                await Task.Delay(milliseconds);
                //await Task.WhenAll(delay, execute);
            }
        }

        static void Main123(string[] args)
        {       



        DataSet dsResult = new DataSet();
            DataSet dsResult2 = new DataSet();

            DataTable table = new DataTable();
            table.Columns.Add("MonthName", typeof(string));
            table.Columns.Add("new_card_qty", typeof(int));
            table.Columns.Add("new_card_total", typeof(double));
            table.Columns.Add("Top_Up_Value", typeof(double));

            // Here we add five DataRows.
            table.Rows.Add("May", 1, 1.0, 1);
            table.Rows.Add("December", 2, 2.0, 2);

            dsResult.Tables.Add(table);

            table = new DataTable();
            table.Columns.Add("MonthName", typeof(string));
            table.Columns.Add("new_card_qty", typeof(int));
            table.Columns.Add("new_card_total", typeof(double));
            table.Columns.Add("Top_Up_Value", typeof(double));

            // Here we add five DataRows.            
            table.Rows.Add("December", 1, 1.0, 1);
            table.Rows.Add("March", 3, 3.0, 3);
            table.Rows.Add("April", 3, 3.0, null);

            dsResult2.Tables.Add(table);

            dsResult.Merge(dsResult2);

            if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
            {
                List<man1> liMan = new List<man1>();

                var distinctDataTable = dsResult.Tables[0].AsEnumerable()
                    .GroupBy(row => row.Field<string>("MonthName"))
                    .Select(group => new
                    {
                        MonthName = group.Key,
                        new_card_qty = group.Sum(e => Convert.ToDouble(e["new_card_qty"] == DBNull.Value ? 0 : e["new_card_qty"])),
                        new_card_total = group.Sum(e => Convert.ToDouble(e["new_card_total"] == DBNull.Value ? 0 : e["new_card_total"])),
                        Top_Up_Value = group.Sum(e => Convert.ToDouble(e["Top_Up_Value"] == DBNull.Value ? 0 : e["Top_Up_Value"])),
                    }).ToList();

                //foreach (var dtRow in distinctDataTable)
                //{
                //    dgvReport.Rows.Add(
                //       dtRow.MonthName,
                //       dtRow.new_card_qty,
                //       dtRow.new_card_total,
                //       dtRow.Top_Up_Value,
                //    );
                //}
            }

                string testData = @" <RESPONSE>
                        <DATA id=""1""/>
                        <DATA id = ""2""/> 
                        <DATA id = ""3""/>  
                        <DATA id = ""4""/>   
                    </RESPONSE>";
            
            XDocument xdc = XDocument.Parse(testData);
            var elementes = xdc.Descendants("DATA")
                .Where(e => e.Attribute("id") != null ? e.Attribute("id").Value == "2" : true);

            foreach (XElement element in elementes)
            {
                XAttribute attribute = new XAttribute("value", "200");
                element.Add(attribute);
            }

            var str = xdc.ToString();

            var tasks = new List<Task>();

            for (int i = 0; i < 500; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var request = WebRequest.Create("http://www.stackoverflow.com");
                    var response = (HttpWebResponse)await Task.Factory
                                        .FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null);

                    Console.WriteLine($"Request {i} status is {response.StatusCode}");

                }));
            }

            try
            {
                // Wait for all the tasks to finish.
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll()");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }


            Parallel.For(1, 500,
                  index => {
                      // web request
                  });




            KeyValuePair<string, string> kvpStrings = new KeyValuePair<string, string>();

            Foo(kvpStrings);


            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }

            List<int> list1 = new List<int>() { 1, 2, 3 };

            List<int> list2 = new List<int>() { 4, 4, 6 };

            var result = list1.Concat(list2);

            Console.ReadLine();

        }

        public static void Foo(object arguments)
        {
            if (arguments is IEnumerable<object>)
            { }

            if (arguments is KeyValuePair<object, object>)
            {

            }
        }

    }

    
    public class man1 //Initialization of the first class
    {
        public int val = 1;
    }

    public class man2 //Initialization of the second class
    {
        public int val = 2;
    }

    public class man3 //Initialization of the third class
    {
        public int val = 3;
    }

    public class allMan
    { //Where all classes 'merge'

        private dynamic chosenMan; //Where the chosen it's going to be stored

        public allMan() //Constructor
        {
            //Have all man in one array to easily get the chosen from index
            object[] men = new object[] { new man1(), new man2(), new man3() };
            var choice = 0;// Random.range(0, men.Length); //Randomly get the index
            chosenMan = men[choice]; // Atribute the chosen class
        }
        public void doActionWithChoosedMan()
        {
            Console.WriteLine(chosenMan.val); //ERROR
        }
    }

}


