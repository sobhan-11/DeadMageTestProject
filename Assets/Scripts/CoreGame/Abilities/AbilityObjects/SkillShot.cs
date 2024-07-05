using UnityEngine;

namespace CoreGame
{
    public class SkillShot : AbilityObject
    {
        public bool isUnlimited;
        
        protected override void Start()
        {
            base.Start();
            Shoot();
        }

        protected override void Update()
        {
            if (Time.time - currentSetupInfo.startTime > lifeTime && !isUnlimited)
            {
                Destroy();
            }
        }

        public override void Shoot()
        {
            if (mover != null)
            {
                var endPoint = currentSetupInfo.endPoint;
                endPoint.y = currentSetupInfo.startPoint.y;
                mover.StartMove(currentSetupInfo.startPoint, endPoint);
            }
        }
    }
}