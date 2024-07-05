using System;

namespace CoreGame
{
    public class StatHP : Stat
    {
        private int CurrentValue;
        private int MaxValue;

        public StatHP(int maxValue , int currentValue)
        {
            statType = Enum_StatsType.HP;
            CurrentValue = currentValue;
            MaxValue = maxValue;
        }

        public void UseStat(int amount , Action onDeath)
        {
            int newCurrentValue = CurrentValue - amount;

            if (newCurrentValue > 0)
            {
                SetCurrentValue(newCurrentValue);
            }
            else
            {
                SetCurrentValue(0);
                onDeath?.Invoke();
            }
        }

        public float GetCurrentValuePercent() => (float) CurrentValue / MaxValue;
        
        public override int GetCurrentValue() => CurrentValue;

        public override void SetCurrentValue(int amount)
        {
            CurrentValue = amount >= MaxValue ? MaxValue : amount;
        }

        public override void UpgradeStat(float percent)
        {
            float currentValuePercent = CurrentValue / MaxValue;
            MaxValue = MaxValue + (int)(MaxValue * percent);
            SetCurrentValue((int)(MaxValue * currentValuePercent));
        }
    }
}