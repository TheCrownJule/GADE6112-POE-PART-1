namespace PartOne
{
    public abstract class Tile
    {
        protected int x;

        public int X => x;

        protected int y;
        public int Y => y;

        public TileTypeEnum TileType;

        public char Symbol
        {
            get
            {
                switch (TileType)
                {
                    case TileTypeEnum.Empty:
                        return '_';
                    case TileTypeEnum.Hero:
                        return 'H';
                    case TileTypeEnum.Enemy:
                        return 'E';
                    case TileTypeEnum.Gold:
                        return 'G';
                    case TileTypeEnum.Weapon:
                        return 'W';
                    case TileTypeEnum.Obstacle:
                        return 'X';
                    default:
                        return ' ';
                }
            }
        }

        public Tile(int x, int y, TileTypeEnum tileType)
        {
            this.x = x;
            this.y = y;
            TileType = tileType;
        }

        protected Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}