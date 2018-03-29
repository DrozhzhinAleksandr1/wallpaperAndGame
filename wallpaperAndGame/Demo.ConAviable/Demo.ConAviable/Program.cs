using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Demo.ConAviable
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 1, offsetX = 1, offsetY = 3, speed = 240, top = 19, left = 0, reflect = 0;
            Console.WriteLine("  XXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");
            Console.WriteLine("  X                         X");

            ConsoleKey key = Console.ReadKey(false).Key;
            while (true)
            {
                
                if (Console.KeyAvailable)
                {
                    switch(Console.ReadKey().Key)
                    {

                        case ConsoleKey.LeftArrow:
                            if(left != 0)
                            {
                                --left;
                                --left;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (left < 19)
                            {
                                ++left;
                                ++left;
                            }
                            break;
                        case ConsoleKey.Escape:
                            goto End;
                    }
                }

                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write(" ");

                x += offsetX;
                y += offsetY;
                if (x <= 3)
                {
                    x = 3;
                    offsetX = -offsetX;
                    offsetX += 1;
                    if(offsetX > 3)
                    {
                        offsetX = 1;
                    }
                    if(offsetY > 1)
                    {
                        offsetY += 1;
                        if (offsetY > 3)
                        {
                            offsetY = 1;
                        }
                    }
                    speed -= 5;
                    if(speed < 160)
                    {
                        speed = 200;
                    }
                    
                }
                if (x >= 26)
                {
                    x = 26;
                    offsetX = -offsetX;
                }
                if (y <= 1)
                {
                    y = 1;
                    offsetY = -offsetY;                   
                }
                if (y >= 18)
                {
                    if( x < left + 2 || x > left + 8)
                    {
                        goto End;
                    }
                    else
                    {
                        ++reflect;
                        y = 18;
                        offsetY = -offsetY;
                    }
                }


                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write("o");

                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.Write("  [][][]  ");

                Thread.Sleep(speed);
            }
            End:;
            Console.Clear();
            Console.Write($"Reflect:{reflect}; \nYou lose");
            Console.ReadKey();

        }
    }
}
