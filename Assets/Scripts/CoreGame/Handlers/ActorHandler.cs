
namespace CoreGame
{
    public class ActorHandler : IActor
    {
        public Enum_TeamType TeamType { get; set; }

        #region Team

        public void SetTeam(Enum_TeamType team) => TeamType = team;
        
        #endregion
    }

    public enum Enum_TeamType
    {
        None=0,
        Ally=1,
        Enemy=2
    }
}