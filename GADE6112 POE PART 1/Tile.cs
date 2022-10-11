namespace PRACTICE_CODE_GADE_SEMESTER_2_PART_1
{
    // Understanding the getting and setting for the tiles has been challenging
    // We sort of know where to go from here now. However there is not enough time to implement

    public abstract class Tile //Base class
    {
        //variables
        protected int x;
        protected int y;

        public enum TileType
        {
            Hero, // 0
            Enemy, // 1
            Gold, // 2
            Weapon // 3
        }

        public Tile()
        {
        }

        //public Tile is the constructor and the brackets are the parameters
        public Tile(int x, int y) //Constructor that recieves initial values for these variables
        {
            this.x = x; // only in this class 
            this.y = y;
        }
    }
}