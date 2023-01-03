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
        

        public Game() 
        {
            GameField = new Field(Console.WindowWidth, Console.WindowHeight);
            Snake = new Snake((Console.WindowWidth - 1) / 2, (Console.WindowHeight - 1) / 2);
        }

        public void Run()
        { 
            while(true)
            {
                GameField.Draw();
                Snake.Draw();
                Snake.Move();
                
            }
        }
    }
}
