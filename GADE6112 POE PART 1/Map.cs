using System;

namespace PRACTICE_CODE_GADE_SEMESTER_2_PART_1
{
    internal class Map
    {
        // NB:  THE CODE MIGHT THROW AN EXEPTION . WE HAVE NOT HANDLED THE EXEPTION BUT WE WILL. PLEASE KEEP TRYING TO RELOAD 
        // THE PROGRAM BECAUSE IT WILL WORK EVENTUALLY 
        // We still need to figure out how to use the TileType enum to sort out the symbols for the 
        // different chars. We also have set our map to a specific size for now. We know how to make it different sizes ,
        // but it causes the code to bug
        public string heroTile = "H";
        public string enemyTile = "E";
        public string emptyTile = ".";
        public string[] enemies; // need to make 2d possibly for the diff postions
        readonly int minSizeWidth = 8;
        readonly int maxSizeWidth = 17;
        readonly int minSizeHeight = 14;
        readonly int maxSizeHeight = 29;
        public static Random newInt = new();
        public static int sizeW;
        public int sizeH;
        int number = 10;
        public static int positionXE;
        public static int positionYE;
        public static int positionXH;
        public static int positionYH;
        public static string mapChar = "?"; // Hero.TileType             look into this one 
        Tile Tile { get; set; } // we need to figure that one out when the power is back 
        Character obj;
        public static string[,] map; // random size of  map 

        public Map()
        {
            sizeH = newInt.Next(minSizeHeight, maxSizeHeight);
            sizeW = newInt.Next(minSizeWidth, maxSizeWidth);
            map = new string[sizeW, sizeH];

            FillMap();
        }

        public static void MapUpdate() // USED TO UPDATE MAP 
        {
            for (var row = 0; row < 10; row++)
            {
                // set the new positions for chars

                // For all columns
                for (var col = 0; col < 10; col++)
                {
                    if (row == 0)
                    {
                        map[row, col] = "X";
                    }
                    else if (col == 0)
                    {
                        map[row, col] = "X";
                    }
                    else if (row == 9)
                    {
                        map[row, col] = "X";
                    }
                    else if (col == 9)
                    {
                        map[row, col] = "X";
                    }
                    else if (row == positionXE &&
                             col == positionYE) // need to make sure H and e are not the same
                    {
                        map[row, col] = "E";
                    }
                    else if (row == positionXH &&
                             col == positionYH)
                    {
                        map[row, col] = "H";
                    }

                    else
                    {
                        map[row, col] = ".";
                    }
                }
                // where to check  reroll 
            }
        }

        static void Create() // FOR HERO
        {
            positionXH = newInt.Next(2, 9);
            positionYH = newInt.Next(2, 9);
            //  mapBuild[positionXH, positionYH] = type; // fix it to be char
        }

        static void Create(int number) // FOR ENEMY
        {
            // int newNum = number % sizeW; // when we have the random map sorted we will take a number ( probably the width ) and divide to get 
            // the number of enemies. This will then be used to fill the enemies array which will then
            // be used for the combobox and map 
            positionXE = newInt.Next(2, 9);
            positionYE = newInt.Next(2, 9);
            //  enemies = new string[newNum];
            // change
        }

        //public void UpdateVison() // enemy 
        //{

        //}

        public static void FillMap()
        {
            Create();
            Create(1);
            // For all rows
            for (var row = 0; row < 10; row++)
            {
                // For all columns
                for (var col = 0; col < 10; col++)
                {
                    if (row == 0)
                    {
                        map[row, col] = "X";
                    }
                    else if (col == 0)
                    {
                        map[row, col] = "X";
                    }
                    else if (row == 9)
                    {
                        map[row, col] = "X";
                    }
                    else if (col == 9)
                    {
                        map[row, col] = "X";
                    }
                    else if (row == positionXE &&
                             col == positionYE) // need to make sure H and e are not the same
                    {
                        map[row, col] = "E";
                    }
                    else if (row == positionXH &&
                             col == positionYH)
                    {
                        map[row, col] = "H";
                    }

                    else
                    {
                        map[row, col] = ".";
                    }
                }
                // where to check  reroll 
            }
        }
    }
}