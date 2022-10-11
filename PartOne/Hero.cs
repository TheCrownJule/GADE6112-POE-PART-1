using System.Text;

namespace PartOne
{
    public class Hero : Character
    {
        public Hero(int x, int y, int startingHP)
            : base(x, y, 'H')
        {
            MaxHp = startingHP;
            Hp = startingHP;
            Damage = 2;
        }

        public override MovementEnum ReturnMove(MovementEnum movement = MovementEnum.Nothing)
        {
            Tile visionTile = null;
            switch (movement)
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
                visionTile.TileType != TileTypeEnum.Enemy &&
                visionTile.TileType != TileTypeEnum.Obstacle)
            {
                return movement;
            }

            return MovementEnum.Nothing;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Player Stats:");
            sb.AppendLine($"HP: {Hp}/{MaxHp}");
            sb.AppendLine($"Damage: {Damage}");
            sb.AppendLine($"[{X},{Y}]");
            return sb.ToString();
        }
    }
}