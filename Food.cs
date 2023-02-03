using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        public FieldPoint FoodPosition { get; set; }

        public Food()
        {
            Random rnd = new Random();
            FoodPosition = new FieldPoint(rnd.Next(1, Console.WindowWidth-1), rnd.Next(1, Console.WindowHeight-1), '■');
        }

        public void Draw()
        {
            Console.SetCursorPosition(FoodPosition.X, FoodPosition.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(FoodPosition.PointLook);
            Console.ResetColor();
        }
    }
}
