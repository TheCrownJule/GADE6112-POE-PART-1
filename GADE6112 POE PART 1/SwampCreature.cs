namespace PRACTICE_CODE_GADE_SEMESTER_2_PART_1
{
    internal class SwampCreature : Enemy
    {
        public string Name
        {
            get;
            // get method 
            set;
        } = "kes";

        public SwampCreature(
            int damage,
            int startingHP,
            int maxHP,
            int x,
            int y)
            : base(damage, startingHP, maxHP, x, y) //x and y positions)  /// constructor initializer??
        {
            this.maxHP = 10;
            this.damage = 1;
            this.x = x; // delagting back to the other class??
            this.y = y;
        }

        public void UpdateVision() // how to write this in map, cannot access the array
        {
            vision[0] = Map.positionXE - 1; // west
            vision[1] = Map.positionXE + 1; // east     // FOR ENEMY
            vision[2] = Map.positionYE - 1; // north
            vision[3] = Map.positionYE + 1; // south
        }

        // an idea of what return move is supposed to do 
        public override int ReturnMove(int num)
        {
            num = rnd.Next();
            if (num == 0)
            {
                // if position of enemy is not = obsticle 
            }
            else
            {
                // reroll
                num = rnd.Next();
            }

            return num;
            //randomizes a direction
        }
    }
}