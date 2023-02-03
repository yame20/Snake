using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Game
    {
        Field GameField { get; set; }
        Snake Snake { get; set; }
        Food Food { get; set; }
        

        public Game() 
        {
            GameField = new Field(Console.WindowWidth, Console.WindowHeight);
            Snake = new Snake((Console.WindowWidth - 1) / 2, (Console.WindowHeight - 1) / 2);
            Food = new Food();
        }

        public void Run()
        { 
            while(Snake.Alive)
            {
                GameField.Draw();
                Snake.Draw();
                Food.Draw();
                Snake.Move(Snake.CurrentMoveDirection);
                if (Console.KeyAvailable)
                {
                    Snake.ChangeDirection();
                }
                if (Snake.CurrentHeadPosition.X == Food.FoodPosition.X && Snake.CurrentHeadPosition.Y == Food.FoodPosition.Y)
                {
                    Snake.BodyLenght++;
                    Food = new Food();
                }
                if (Snake.CurrentHeadPosition.X == 0 || Snake.CurrentHeadPosition.X == Console.WindowWidth -1 ||
                    Snake.CurrentHeadPosition.Y == 0 || Snake.CurrentHeadPosition.Y == Console.WindowHeight -1)
                {
                    Snake.Alive = false;
                    Console.SetCursorPosition((Console.WindowWidth-1)/2, (Console.WindowHeight-1)/2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Game Over");
                }
            }
        }
    }
}
