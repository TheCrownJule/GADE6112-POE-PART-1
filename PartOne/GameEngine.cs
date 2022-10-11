namespace PartOne
{
    public class GameEngine
    {
        public Map Map { get; }

        public GameEngine()
        {
            Map = new Map(10, 20, 10, 20, 5);
        }

        // Where you need to plug into, basically your winform needs to call this method with a movement direction
        public bool MovePlayer(MovementEnum direction)
        {
            MovementEnum finalMove = Map.Hero.ReturnMove(direction);
            if (finalMove == MovementEnum.Nothing)
            {
                return false; // we didn't move the player and can also exit early because it has no impact on the game
            }

            Map.Hero.Move(finalMove);

            Map.Update(finalMove);

            return true; // we moved the player and updated the map successfully
        }
    }
}