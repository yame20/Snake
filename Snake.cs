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
        public int BodyLenght { get; set; }
        public FieldPoint CurrentHeadPosition { get; set; }
        public LinkedList<FieldPoint> PositionsOfBody { get; set; }
        public FieldPoint CurrentMoveDirection { get; set; }
        public int MoveSpeed { get; set; }
        private FieldPoint LastPosition { get; set; }

        public Snake(int snakePositionX, int snakePositionY)
        {
            Alive = true;
            BodyLenght = 3;
            CurrentHeadPosition = new FieldPoint(snakePositionX, snakePositionY, SNAKE_BODY);
            PositionsOfBody = new LinkedList<FieldPoint>();
            PositionsOfBody.AddFirst(CurrentHeadPosition);
            CurrentMoveDirection = new FieldPoint(+1, 0, SNAKE_BODY);
            MoveSpeed = 150;
        }

        Dictionary<ConsoleKey, FieldPoint> MoveDirection = new()
        {
            {ConsoleKey.UpArrow, new FieldPoint(0, -1, SNAKE_BODY)},
            {ConsoleKey.DownArrow, new FieldPoint(0, +1, SNAKE_BODY)},
            {ConsoleKey.LeftArrow, new FieldPoint(-1, 0, SNAKE_BODY)},
            {ConsoleKey.RightArrow, new FieldPoint(+1, 0, SNAKE_BODY)}
        };

        public void Move(FieldPoint moveDirection)
        {

            FieldPoint oldPosition = new FieldPoint(CurrentHeadPosition.X, CurrentHeadPosition.Y, SNAKE_BODY);

            FieldPoint movement = moveDirection;
            CurrentHeadPosition.X += movement.X;
            CurrentHeadPosition.Y += movement.Y;

            if (BodyLenght > 1)
            {
                PositionsOfBody.AddAfter(PositionsOfBody.First, oldPosition);

                while (PositionsOfBody.Count > BodyLenght)
                {
                    LastPosition = PositionsOfBody.Last();
                    PositionsOfBody.RemoveLast();
                }
            }
            Thread.Sleep(MoveSpeed);
        }

        public void ChangeDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (MoveDirection.ContainsKey(keyInfo.Key))
            {
                FieldPoint newMoveDirection = MoveDirection[keyInfo.Key];

                if (newMoveDirection.X != -CurrentMoveDirection.X || newMoveDirection.Y != -CurrentMoveDirection.Y)
                {
                    CurrentMoveDirection = newMoveDirection;
                }
            }
        }

        public void Draw()
        {
            foreach (FieldPoint positions in PositionsOfBody)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(positions.X, positions.Y);
                Console.Write(positions.PointLook);
                Console.ResetColor();
            }
            if (LastPosition != null)
            {
                Console.SetCursorPosition(LastPosition.X, LastPosition.Y);
                Console.Write(" ");
            }

        }

    }
}
