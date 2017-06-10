namespace StreetFighterXKingOfFighter
{
    internal class CheckCollision
    {
        public static bool CheckIntersection()
        {
            if ((GameController.Player1.PosLeft == false) &
                GameController.Player1.PlayerPosition.IntersectsWith(GameController.Player2.PlayerPosition) &
                (GameController.Player1.X + 75 > GameController.Player2.X) &
                (GameController.Player1.Y == GameController.Player2.Y))
                return false;
            return !(GameController.Player1.PosLeft
                     & GameController.Player1.PlayerPosition.IntersectsWith(GameController.Player2.PlayerPosition)
                     & (GameController.Player2.X + 75 > GameController.Player1.X)
                     & (GameController.Player1.Y == GameController.Player2.Y));
        }
    }
}