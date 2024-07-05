using System;
using UnityEngine;

namespace CoreGame
{
    public class HitterSingle : Hitter
    {
        public int maxPossibleHits;
        public bool dontDestroy;

        [HideInInspector] public int targetsHitSoFar;


        public override void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Target"))
                return;
            if (other.gameObject.GetComponent<ITargetable>().ID() == castInfo.teamId)
                return;
            try
            {
                if (Hit(other.gameObject))
                {
                    targetsHitSoFar++;
                }

                if (targetsHitSoFar >= maxPossibleHits)
                {
                    if (!dontDestroy)
                    {
                        GetComponent<IDestructible>().Destroy();
                    }

                    return;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.Log("ERORR HITTER SINGLE : " + other.gameObject.name);
            }
        }
    }
}