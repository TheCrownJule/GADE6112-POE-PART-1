namespace PRACTICE_CODE_GADE_SEMESTER_2_PART_1
{
    internal class Hero : Character
    {
        protected static int
            HX = Map.positionXH; // Once we have a better understanding of properties we will adjust these accordingly

        protected static int HY = Map.positionYH;

        public Hero(int x, int y)
            : base(x, y)
        {
            HP = 10;
            maxHP = maxHP;
            damage = 2;
            this.x = HX; // uses the values from the map to set the postion of the hero
            this.y = HY;
        }

        public void
            UpdateVision() // We cannot access the vision array in the map class , so a method has been created in  this class instead 
        {
            // also there is a bug with the postioning. Something was probably miscoded, but will fix it.
            vision[0] = Map.positionXH - 1; // west
            vision[1] = Map.positionXH + 1; // east     // FOR HERO
            vision[2] = Map.positionYH - 1; // north
            vision[3] = Map.positionYH + 1; // south
        }

        // we dont know how to use the return move method as yet .
        public override int ReturnMove(int num) =>
            // a loop to check the vision array againt the move given .. how would we check valid movement ? 
            // so if the . = . then movemnt is vaild 
            // if the . = sth else then its no movement , the value retuened from enum is 0 
            // a number from the enum must then be used in main code to move the char in the dicrection
            //if(num == 0) // 
            //{
            //    if (this.damage > 0)
            //    {
            //    }
            //}
            //else if ()
            //{
            //}
            num;

        //randomizes a direction
        public override string ToString()
        {
            damage.ToString();
            x.ToString();
            y.ToString();
            //This is defined in the Character subclasses and overrides the traditional Object ToString() method.
            return " Hero at: " + HX + HY + " " + damage;
        }

        public void
            UpdateHero(
                Movement move) // this method moves the hero. We attempted to use the Move() method but the method would not run for
        {
            // reasons we cannot figure out
            if (move == Movement.up)
            {
                Map.positionYH = Map.positionYH - 1;
            }
            else if (move == Movement.down)
            {
                Map.positionYH = Map.positionYH + 1;
            }
            else if (move == Movement.left)
            {
                Map.positionXH = Map.positionXH + 1;
            }
            else if (move == Movement.right)
            {
                Map.positionXH = Map.positionXH - 1;
            }
        }
    }
}