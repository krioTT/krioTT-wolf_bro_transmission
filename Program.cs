using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kriogen109
{
    class Wolf_Pack
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string input_data = Console.ReadLine().ToUpper().Trim();
            var encode_data_stream = false;
            string[] input_data_split = new string[input_data.Length];
            if (input_data == string.Empty)
                return;
            else if (char.IsLetterOrDigit(input_data[0]))
                encode_data_stream = true;
            else
            {
                input_data_split = Load_splitted_input(input_data);
            }
            var rotate_to = encode_data_stream ? input_data.Length : input_data_split.Length;
            var data_result = new StringBuilder();
            for (int i = 0; i < rotate_to; i++)
            {
                if (encode_data_stream && data_decode.ContainsValue(input_data[i]))
                {
                    var key = data_decode.FirstOrDefault(k => k.Value == input_data[i]).Key;
                    data_result.Append(key + (char)32);
                }
                else if (!encode_data_stream && data_decode.ContainsKey(input_data_split[i]))
                    data_result.Append(data_decode[input_data_split[i]]);
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(string.Join("", data_result));
            Console.ResetColor();
            Console.WriteLine();
            Kriogen109.Wolf_Pack.Terminate();
        }

        private static string[] Load_splitted_input(string input_data)
        {
            return input_data
                            .Split(new char[] { (char)32, '\t' },
                            StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
        }

        private static void Terminate()
        {
            Console.WriteLine(" Press ENTER to exit");
            for (; Console.ReadKey(true).Key != ConsoleKey.Enter;) ;
        }

        private static readonly Dictionary<string, char> data_decode = new Dictionary<string, char>()
            {
                {".-",'A' },    {"-...", 'B'},  {"-.-.", 'C'},
                {"-..", 'D'},   {".", 'E'},     {"..-.", 'F'},
                {"--.", 'G'},   {"....", 'H'},  {"..", 'I'},
                {".---",'J'},   {"-.-", 'K'},   {".-..",'L' },
                {"--",'M'},     {"-.", 'N'},    {"---",'O' },
                {".--.",'P'},   {"--.-",'Q'},   {".-.",'R'},
                {"...",'S'},    {"-",'T'},      {"..-",'U'},
                {"...-",'V'},   {".--",'W'},    {"-..-",'X'},
                {"-.--",'Y'},   {"--..",'Z'},   { "|",' '},
                {"-----",'0'},  {".----",'1'},  { "..---",'2'},
                {"...--",'3'},  {"....-",'4'},  { ".....",'5'},
                {"-....",'6'},  {"--...",'7'},  { "---..",'8'},
                { "----.",'9'}
            };
    }
}
