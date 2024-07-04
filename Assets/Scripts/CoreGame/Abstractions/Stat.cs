
namespace CoreGame
{
    public abstract class Stat
    {
        public Enum_StatsType statType;
        private int currentValue;
        private int maxValue;
        public abstract int GetCurrentValue();
        public abstract void SetCurrentValue(int amount);
        public abstract void UpgradeStat(float percent);
    }
}

