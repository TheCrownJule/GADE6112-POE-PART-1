using System;

namespace PartOne
{
    public abstract class Character : Tile
    {
        protected int Hp;
        protected int MaxHp;
        protected int Damage;

        public Tile[] Vision; // 0: up, 1: down, 2: left, 3: right
        public MovementEnum MovementEnum;

        protected Character(int x, int y, char symbol)
            : base(x, y)
        {
            TileTypeEnum tileType;

            switch (symbol)
            {
                case 'H':
                    tileType = TileTypeEnum.Hero;
                    break;
                case 'E':
                    tileType = TileTypeEnum.Enemy;
                    break;
                default:
                    throw new InvalidOperationException(
                        "You can only choose between Hero or Enemy for Character types");
            }

            Vision = new Tile[4];

            TileType = tileType;
        }

        public virtual void Attack(Character target)
        {
            target.Hp -= Damage;
        }

        // IsDead
        public bool IsDead() => Hp <= 0;

        public virtual bool CheckRange(Character target)
        {
            bool isWithinDamageRadius = DistanceTo(target) <= 1;
            return isWithinDamageRadius;
        }

        int DistanceTo(Character target)
        {
            int xDistance = Math.Abs(target.X - X);
            int yDistance = Math.Abs(target.Y - Y);
            return xDistance + yDistance;
        }

        public void Move(MovementEnum movement)
        {
            //0 1 2 3
            //1
            //2
            //3

            switch (movement)
            {
                case MovementEnum.Up:
                    y--;
                    break;
                case MovementEnum.Down:
                    y++;
                    break;
                case MovementEnum.Right:
                    x++;
                    break;
                case MovementEnum.Left:
                    x--;
                    break;
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum movement = MovementEnum.Nothing);

        public abstract override string ToString();
    }
}