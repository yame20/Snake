using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    internal class Field
    {
        public FieldPoint[,] FieldSpace { get; set; } 

        public Field(int width, int height)
        {
            FieldSpace = new FieldPoint[width, height];

            for (int y = 0; y < FieldSpace.GetLength(1); y++)
            {
                for (int x = 0; x < FieldSpace.GetLength(0); x++)
                {
                    //leeres Spielfeld
                    FieldSpace[x, y] = new FieldPoint(x, y, ' ');
                    //Ober und Untergrenze 
                    FieldSpace[x, 0] = new FieldPoint(x, 0, 'X');
                    FieldSpace[x, height - 1] = new FieldPoint(x, height - 1, 'X');
                    //Seitliche Grenzen
                    FieldSpace[0, y] = new FieldPoint(0, y, 'X');
                    FieldSpace[width - 1, y] = new FieldPoint(width - 1, y, 'X');
                }
            }
        }

        public void Draw()
        {
            Console.CursorVisible = false;
            for (int y = 0; y < FieldSpace.GetLength(1); y++)
            {
                for (int x = 0; x < FieldSpace.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (FieldSpace[x, y].PointLook == 'X')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(FieldSpace[x, y].PointLook);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(FieldSpace[x, y].PointLook);
                        
                    }
                }
            }
        }
    }
}
