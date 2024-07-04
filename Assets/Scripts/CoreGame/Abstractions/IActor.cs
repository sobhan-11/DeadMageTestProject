
namespace CoreGame
{
    public interface IActor
    {
        public Enum_TeamType TeamType { get; }

        public void OnTakeDamage(float currentHp);
    }

    public enum Enum_TeamType
    {
        None = 0,
        Wizard = 1,
        Dummy = 2
    }
}