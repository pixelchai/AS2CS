﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PygmentSharp.Core;
using PygmentSharp.Core.Lexing;
using PygmentSharp.Core.Tokens;
using System.Diagnostics;
using PygmentSharp.Core.Formatting;
using System.IO;
using AS2CS.Nodes;

namespace AS2CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //////////////Utils.DEBUG_PARSING = false;

            //new System.Threading.Thread(() =>
            //new AS2CS().ShowDialog()).Start();
            //Console.WindowWidth = (Console.LargestWindowWidth / 4) * 3;

            var lexed = Pygmentize.File(@"rotmgsrc\com\company\assembleegameclient\appengine\SavedCharactersList.as").WithLexer(new ASLexer());
            TokenStream ts = new TokenStream(lexed.GetTokens().ToList());

            //foreach (Token t in lexed.GetTokens().ToList())
            //{
            //    Console.WriteLine(t.ToString());
            //}
            lexed.WithFormatter(new HtmlFormatter(new HtmlFormatterOptions()
            {
            })).ToFile("output.html");
            File.WriteAllText("output.html", File.ReadAllText("output.html").Insert(0,
                "<style>html{background-color:#272822}.c{color:#75715e}.err{color:#960050;background-color:#1e0010}.k{color:#66d9ef}.l{color:#ae81ff}.n{color:#f8f8f2}.o{color:#f92672}.p{color:#f8f8f2}.cm{color:#75715e}.cp{color:#75715e}.c1{color:#75715e}.cs{color:#75715e}.ge{font-style:italic}.gs{font-weight:700}.kc{color:#66d9ef}.kd{color:#66d9ef}.kn{color:#f92672}.kp{color:#66d9ef}.kr{color:#66d9ef}.kt{color:#66d9ef}.ld{color:#e6db74}.m{color:#ae81ff}.s{color:#e6db74}.na{color:#a6e22e}.nb{color:#f8f8f2}.nc{color:#a6e22e}.no{color:#66d9ef}.nd{color:#a6e22e}.ni{color:#f8f8f2}.ne{color:#a6e22e}.nf{color:#a6e22e}.nl{color:#f8f8f2}.nn{color:#f8f8f2}.nx{color:#a6e22e}.py{color:#f8f8f2}.nt{color:#f92672}.nv{color:#f8f8f2}.ow{color:#f92672}.w{color:#f8f8f2}.mf{color:#ae81ff}.mh{color:#ae81ff}.mi{color:#ae81ff}.mo{color:#ae81ff}.sb{color:#e6db74}.sc{color:#e6db74}.sd{color:#e6db74}.s2{color:#e6db74}.se{color:#ae81ff}.sh{color:#e6db74}.si{color:#e6db74}.sx{color:#e6db74}.sr{color:#e6db74}.s1{color:#e6db74}.ss{color:#e6db74}.bp{color:#f8f8f2}.vc{color:#f8f8f2}.vg{color:#f8f8f2}.vi{color:#f8f8f2}.il{color:#ae81ff}.gu{color:#75715e}.gd{color:#f92672}.gi{color:#a6e22e}</style>"
                ));
            Process.Start("output.html");

            CompilationUnit file = null;
            file = new Parser(ts).Parse();
            new TreeDebug(file.ToJSON()).ShowDialog();


            //BugScan("rotmgsrc");
        }

        public static void BugScan(string path)
        {
            int no = 0;
            using (StreamWriter sw = new StreamWriter("bugs.txt"))
            {
                //List<string> r = new List<string>();
                foreach (string f in Directory.GetFiles(path, "*.as", SearchOption.AllDirectories))
                {
                    try
                    {
                        var lexed = Pygmentize.File(f).WithLexer(new ASLexer());
                        TokenStream ts = new TokenStream(lexed.GetTokens().ToList());
                        //ts.ProgressUpdate = 500;
                        ts.dontPrUpdt = true;
                        //ts.ProgressChanged += PrintProgress;
                        CompilationUnit file = null;
                        file = new Parser(ts).Parse();
                        //PrintProgress(100, 100);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        //r.Add(f);
                        sw.WriteLine(f);
                        sw.Flush();
                        no++;
                    }
                    Console.WriteLine(new FileInfo(f).Name);
                    Console.ResetColor();
                }
                sw.WriteLine(no);
                //using (StreamWriter sw = new StreamWriter("bugs.txt"))
                //{
                //    foreach (string str in r)
                //    {
                //        sw.WriteLine(str);
                //    }
                //}
            }
        }

        //public static void GetASFiles(string path)
        //{
        //}

        private static void PrintProgress(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                //Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write("=");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            //Console.BackgroundColor = ConsoleColor.Black;

            double perc = Math.Round((progress / (double)total) * 100, 2);
            Console.Write(perc.ToString() + "%   "); //blanks at the end remove any excess
        }
    }
}
