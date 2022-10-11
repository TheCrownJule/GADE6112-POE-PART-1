using System;
using System.Text;

namespace PartOne
{
    public class Map
    {
        // Map specifics
        readonly Tile[,] map;
        readonly int mapWidth;
        readonly int mapHeight;

        // Characters
        public Hero Hero { get; }
        readonly Enemy[] enemies;
        public Enemy[] Enemies => enemies;

        // Random
        readonly Random Random;

        public Map(
            int minMapHeight,
            int maxMapHeight,
            int minMapWidth,
            int maxMapWidth,
            int numberOfEnemies)
        {
            Random = new Random();

            mapHeight = Random.Next(minMapHeight, maxMapHeight);
            mapWidth = Random.Next(minMapWidth, maxMapWidth);

            map = new Tile[mapHeight, mapWidth];
            FillMapWithEmptyTiles();
            SetBorderToObstacles();

            enemies = new Enemy[numberOfEnemies];

            Hero = (Hero)Create(TileTypeEnum.Hero);

            for (var i = 0; i < numberOfEnemies; i++)
            {
                enemies[i] = (Enemy)Create(TileTypeEnum.Enemy);
            }

            UpdateVision();
        }

        void FillMapWithEmptyTiles()
        {
            for (var y = 0; y < mapHeight; y++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    map[y, x] = new EmptyTile(x, y);
                }
            }
        }

        void SetBorderToObstacles()
        {
            for (var i = 0; i < mapHeight; i++)
            {
                map[i, 0] = new Obstacle(i, 0);
                map[i, mapWidth - 1] = new Obstacle(i, mapWidth - 1);
            }

            for (var i = 0; i < mapWidth; i++)
            {
                map[0, i] = new Obstacle(0, i);
                map[mapHeight - 1, i] = new Obstacle(mapHeight - 1, i);
            }
        }

        void UpdateVision()
        {
            // vision[0] is == tile directly above the characters current position
            // directly above characters position == character.Y - 1

            Hero.Vision[0] = GetTile(Hero.X, Hero.Y - 1);
            Hero.Vision[1] = GetTile(Hero.X, Hero.Y + 1);
            Hero.Vision[2] = GetTile(Hero.X - 1, Hero.Y);
            Hero.Vision[3] = GetTile(Hero.X + 1, Hero.Y);

            // do it again for the enemies array
            for (var i = 0; i < enemies.Length; i++)
            {
                enemies[i].Vision[0] = GetTile(enemies[i].X, enemies[i].Y - 1);
                enemies[i].Vision[1] = GetTile(enemies[i].X, enemies[i].Y + 1);
                enemies[i].Vision[2] = GetTile(enemies[i].X - 1, enemies[i].Y);
                enemies[i].Vision[3] = GetTile(enemies[i].X + 1, enemies[i].Y);
            }
        }

        Tile GetTile(int positionX, int positionY) => map[positionY, positionX];

        Tile Create(TileTypeEnum tileType)
        {
            // create objects of the right type based on tile type enum
            // hero, enemies, obstacles

            Tile tile = null;
            switch (tileType)
            {
                case TileTypeEnum.Hero:
                    tile = CreateHeroTile();
                    break;
                case TileTypeEnum.Enemy:
                    tile = CreateEnemyTile();
                    break;
                case TileTypeEnum.Obstacle:
                    tile = CreateObstacleTile();
                    break;
            }

            return tile;

            // when creating, ensure position is unique - no two items may overlap
        }

        Obstacle CreateObstacleTile()
        {
            (int x, int y) = GetUniquePosition();
            return new Obstacle(x, y);
        }

        Enemy CreateEnemyTile()
        {
            (int x, int y) = GetUniquePosition();
            var cret = new SwampCreature(x, y);

            map[cret.Y, cret.X] = cret;
            return cret;
        }

        Hero CreateHeroTile()
        {
            (int x, int y) = GetUniquePosition();
            var hero = new Hero(x, y, 20);

            map[hero.Y, hero.X] = hero;
            return hero;
        }

        (int x, int y) GetUniquePosition()
        {
            var isValidPosition = false;
            var x = 0;
            var y = 0;
            while (!isValidPosition)
            {
                x = Random.Next(1, mapWidth);
                y = Random.Next(1, mapHeight);
                Tile tile = GetTile(x, y);
                if (tile.TileType == TileTypeEnum.Empty)
                {
                    isValidPosition = true;
                }
            }

            return (x, y);
        }

        public void Update(MovementEnum movementEnum)
        {
            UpdateHeroPositionOnMap();
            RefillHeroLastPositionOnMap(movementEnum);
            UpdateVision();
        }

        void RefillHeroLastPositionOnMap(MovementEnum movementEnum)
        {
            int lastX = Hero.X;
            int lastY = Hero.Y;

            switch (movementEnum)
            {
                case MovementEnum.Up:
                    lastY++;
                    break;
                case MovementEnum.Down:
                    lastY--;
                    break;
                case MovementEnum.Left:
                    lastX++;
                    break;
                case MovementEnum.Right:
                    lastX--;
                    break;
            }

            lastX = ClampXToMapWidth(lastX);
            lastY = ClampYToMapHeight(lastY);

            map[lastY, lastX] = new EmptyTile(lastX, lastY);
        }

        int ClampYToMapHeight(int lastY)
        {
            if (lastY >= mapHeight)
            {
                lastY = mapHeight - 1;
            }

            if (lastY <= 0)
            {
                lastY = 1;
            }

            return lastY;
        }

        int ClampXToMapWidth(int lastX)
        {
            if (lastX >= mapWidth)
            {
                lastX = mapWidth - 1;
            }

            if (lastX <= 0)
            {
                lastX = 1;
            }

            return lastX;
        }

        void UpdateHeroPositionOnMap()
        {
            map[Hero.Y, Hero.X] = Hero;
        }

        public void Draw()
        {
            for (var y = 0; y < mapHeight; y++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    Tile tile = map[y, x];
                    Console.Write(tile.Symbol);
                }

                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < mapHeight; y++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    Tile tile = map[y, x];
                    sb.Append(tile.Symbol);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}