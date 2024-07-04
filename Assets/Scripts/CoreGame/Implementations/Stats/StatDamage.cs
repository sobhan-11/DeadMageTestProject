
namespace CoreGame
{
    public class StatDamage : Stat
    {
        private int CurrentValue;
        private int MaxValue;

        public StatDamage(int maxValue , int currentValue)
        {
            statType = Enum_StatsType.Damage;
            CurrentValue = currentValue;
            MaxValue = maxValue;
        }
        public override int GetCurrentValue() => CurrentValue;

        public override void SetCurrentValue(int amount)
        {
            CurrentValue = amount >= MaxValue ? MaxValue : amount;
        }
        
        public override void UpgradeStat(float percent)
        {
            MaxValue = MaxValue + (int)(MaxValue * percent);
        }
    }
}