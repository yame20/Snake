using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public const char SNAKE_BODY = '■';

        public bool Alive { get; set; }
        public int Body { get; set; }
        public FieldPoint CurrentHeadPosition { get; set; }
        public LinkedList<FieldPoint> PosotionsOfBody { get; set; }

        public Snake(int snakePositionX, int snakePositionY)
        {
            Alive = true;
            Body = 2;
            CurrentHeadPosition = new FieldPoint(snakePositionX, snakePositionY, SNAKE_BODY);
            PosotionsOfBody = new LinkedList<FieldPoint>();
            PosotionsOfBody.AddFirst(CurrentHeadPosition);
            
        }

        //Dictionary<ConsoleKey, FieldPoint> MoveDirection = new()
        //{
        //    {ConsoleKey.UpArrow, new FieldPoint(0, -1, SNAKE_BODY)},
        //    {ConsoleKey.DownArrow, new FieldPoint(0, +1, SNAKE_BODY)},
        //    {ConsoleKey.LeftArrow, new FieldPoint(-1, 0, SNAKE_BODY)},
        //    {ConsoleKey.RightArrow, new FieldPoint(+1, 0, SNAKE_BODY)}
        //};

        public void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                
                if (Body > 1)
                {
                    for (int i = 1; i < Body; i++)
                    {
                        FieldPoint oldPosition = new FieldPoint(CurrentHeadPosition.X, CurrentHeadPosition.Y, SNAKE_BODY);
                        PosotionsOfBody.AddLast(oldPosition);
                        if (PosotionsOfBody.Count > Body)
                        {
                            
                        }
                    }
                }
                CurrentHeadPosition.Y -= 1;
                PosotionsOfBody[0] = CurrentHeadPosition;
             

            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                CurrentHeadPosition.Y += 1;
                PosotionsOfBody[0] = CurrentHeadPosition;

            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                CurrentHeadPosition.X -= 1;
                PosotionsOfBody[0] = CurrentHeadPosition;

            }
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                CurrentHeadPosition.X += 1;
                PosotionsOfBody[0] = CurrentHeadPosition;

            }



        }
        public void Draw()
        {
            foreach (var positions in PosotionsOfBody)
            {
                //if (PosotionsOfBody)
                Console.SetCursorPosition(positions.X, positions.Y);
                Console.Write(SNAKE_BODY);
            }
        }

    }
}
