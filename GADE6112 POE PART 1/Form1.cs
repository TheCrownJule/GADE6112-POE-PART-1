using System;
using System.Windows.Forms;

namespace PRACTICE_CODE_GADE_SEMESTER_2_PART_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // creating objects
        Map obj = new();

        readonly SwampCreature
            swampCreature = new(
                1,
                1,
                1,
                'x',
                'y'); // have not understood how to call a constructer w variables. Just placeholders for now

        readonly Hero
            hero = new(1, 1); // have not understood how to call a constructer w variables. Just placeholders for now

        /// <summary>
        ///     NOTES:
        ///     we definitely can improve on our understanding of objects and properties. I believe this is what set us back
        ///     in this project. Further it was difficult piecing together what exactly the examiner wanted from us.
        ///     Things are slowly making sense as the code is being typed out. For part 2 we hope to have less hard coding
        ///     and have all the methods working as they should in their respective classes
        /// </summary>
        void Form1_Load(object sender, EventArgs e)
        {
            AddItems();
            Map.FillMap();
            PrintMap();
            lblEnemyStats.Text = swampCreature.ToString();
            lblHeroStats.Text = hero.ToString();
            lblEnemyStats.Text = swampCreature.ToString();
            swampCreature.UpdateVision();
            hero.UpdateVision();
        }

        public void AddItems()
        {
            //This will be used to fill the combo box with the array of enemies
        }

        // Currently caanot figure out how to access the buttons in the game engine class. Once we have
        // the code will be moved there
        void btnUp_Click(object sender, EventArgs e)
        {
            hero.UpdateHero(Character.Movement.right); // for now we have only figured out how to get the hero to move.
            Map.MapUpdate(); // We had to create a different method to do this. The approoriate methods will be used 
            hero.UpdateVision(); // once we have figured out some of the other things in the code
            lblNewMap.Text = "";
            PrintUpdatedMap();
        }

        void btnLeft_Click(object sender, EventArgs e)
        {
            hero.UpdateHero(Character.Movement.up);
            hero.UpdateVision();
            Map.MapUpdate();
            lblNewMap.Text = "";
            PrintUpdatedMap();
        }

        void btnRight_Click(object sender, EventArgs e)
        {
            hero.UpdateHero(Character.Movement.down);
            hero.UpdateVision();
            Map.MapUpdate();
            lblNewMap.Text = "";
            PrintUpdatedMap();
        }

        void btnDown_Click(object sender, EventArgs e)
        {
            hero.UpdateHero(Character.Movement.left);
            hero.UpdateVision();
            Map.MapUpdate();
            lblNewMap.Text = "";
            PrintUpdatedMap();
        }

        // below are some methods for map. Since we do not know how to access labels in the 
        // map class the code has been left here for now

        public void PrintMap()
        {
            for (var row = 0; row < 10; row++)
            {
                // For all columns
                for (var col = 0; col < 10; col++)
                {
                    lblNewMap.Text += Map.map[row, col];
                }

                lblNewMap.Text += Environment.NewLine;
            }
        }

        public void PrintUpdatedMap()
        {
            for (var row = 0; row < 10; row++)
            {
                // For all columns
                for (var col = 0; col < 10; col++)
                {
                    lblNewMap.Text += Map.map[row, col];
                }

                lblNewMap.Text += Environment.NewLine;
            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}