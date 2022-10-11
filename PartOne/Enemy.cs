using System;

namespace PartOne
{
    public abstract class Enemy : Character
    {
        protected Random Random;

        public Enemy(
            int x,
            int y,
            int damage,
            int startingHp,
            char symbol)
            : base(x, y, symbol)
        {
            MaxHp = startingHp;
            Hp = startingHp;
            Damage = damage;
        }

        public override string ToString() => $"{nameof(Enemy)} at [{X},{Y}] ({Damage})";
    }
}