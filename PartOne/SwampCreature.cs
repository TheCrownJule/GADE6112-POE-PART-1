using System;

namespace PartOne
{
    public class SwampCreature : Enemy
    {
        public SwampCreature(int x, int y)
            : base(x, y, 1, 10, 'E')
        {
            Random = new Random();
        }

        public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.Nothing)
        {
            var isValidMove = false;
            MovementEnum nextHopefulMove = GenerateRandomDirection();
            while (!isValidMove)
            {
                nextHopefulMove = GenerateRandomDirection();

                Tile visionTile = null;
                switch (nextHopefulMove)
                {
                    case MovementEnum.Up:
                        visionTile = Vision[0];
                        break;
                    case MovementEnum.Down:
                        visionTile = Vision[1];
                        break;
                    case MovementEnum.Left:
                        visionTile = Vision[2];
                        break;
                    case MovementEnum.Right:
                        visionTile = Vision[3];
                        break;
                }

                if (visionTile != null &&
                    visionTile.TileType != TileTypeEnum.Hero &&
                    visionTile.TileType != TileTypeEnum.Obstacle)
                {
                    isValidMove = true;
                }
            }

            return nextHopefulMove;
        }

        MovementEnum GenerateRandomDirection()
        {
            int randomDirection = Random.Next(1, 5);
            return (MovementEnum)randomDirection;
        }
    }
}