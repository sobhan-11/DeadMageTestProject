using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public abstract class Hitter : MonoBehaviour
    {
        AbilityObject _boss;
    
        [HideInInspector] public ActionInfo castInfo;
        [HideInInspector] public Enum_TeamType team;
    
        public Action<GameObject> actionOnHit;
    
        [HideInInspector] public Trigger[] triggers;
        public UnityEvent<GameObject> onHit;
        public UnityEvent onKill;
        
        public HitInfo[] hitEffects;
        
        public virtual void Init(ActionInfo info)
        {
            castInfo = info;
            team = info.teamId;
    
            triggers = GetComponentsInChildren<Trigger>();
            
            foreach (var t in triggers)
            {
                t.onTriggerEnter += TriggerEnter;
                t.onTriggerExit += TriggerExit;
                t.onTriggerStay += TriggerStay;
            }
    
            _boss = GetComponent<AbilityObject>();
        }
    
        public virtual void TriggerEnter(Collider other)
        {
        }
    
        public virtual void TriggerExit(Collider other)
        {
        }
    
        public virtual void TriggerStay(Collider other)
        {
        }
        
        public bool Hit(GameObject target)
        {
            var res = _boss.Hit(target, hitEffects , _boss.currentSetupInfo);

            if (res)
            {
                FireEvents(target);
            }

            return res;
        }
        
        void FireEvents(GameObject target)
        {
            Actor actorTarget = target.GetComponentInChildren<Actor>();
            var info = new ActionInfo
            {
                direction = transform.position - target.transform.position,
                endPoint = target.transform.position,
            };
            if (actorTarget.statsHandler.GetStatByType(Enum_StatsType.HP).GetCurrentValue() <= 0)
            {
                onKill?.Invoke();
            }
            
            onHit?.Invoke(target);
        }
    }
}

