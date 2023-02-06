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
            GameField.Draw();
            while(Snake.Alive)
            {
                Snake.Draw();
                Food.Draw();
                Snake.Move(Snake.CurrentMoveDirection);
                if (Console.KeyAvailable)
                {
                    Snake.ChangeDirection();
                }
                CheckFruit();
                CheckGameOver();
            }
        }

        public void CheckFruit()
        {
            if (Snake.CurrentHeadPosition.X == Food.FoodPosition.X && Snake.CurrentHeadPosition.Y == Food.FoodPosition.Y)
            {
                if (Snake.MoveSpeed > 30)
                {
                    Snake.MoveSpeed = Snake.MoveSpeed - 10;
                }
                Snake.BodyLenght++;
                Food = new Food();
            }
        }

        public void CheckGameOver()
        {
            for (int i = 1; i < Snake.PositionsOfBody.Count; i++)
            {
                if (Snake.CurrentHeadPosition.X == Snake.PositionsOfBody.ElementAt(i).X && Snake.CurrentHeadPosition.Y == Snake.PositionsOfBody.ElementAt(i).Y)
                {
                    Snake.Alive = false;
                    GameOver();
                }
            }

            if (Snake.CurrentHeadPosition.X == 0 || Snake.CurrentHeadPosition.X == Console.WindowWidth - 1 ||
                    Snake.CurrentHeadPosition.Y == 0 || Snake.CurrentHeadPosition.Y == Console.WindowHeight - 1)
            {
                Snake.Alive = false;
                GameOver();
            }
        }

        public void GameOver()
        {
            Console.SetCursorPosition((Console.WindowWidth - 15) / 2, (Console.WindowHeight - 1) / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.SetCursorPosition((Console.WindowWidth - 15) / 2, ((Console.WindowHeight - 1) / 2) + 1);
            Console.WriteLine("Your Score: {0}", Snake.BodyLenght - 3);
            Console.ResetColor();
            Console.SetCursorPosition((Console.WindowWidth - 35) / 2, ((Console.WindowHeight - 1) / 2) + 2);
            Console.WriteLine("[ESC] = Exit || [Enter] = New Game");
        }
    }
}
