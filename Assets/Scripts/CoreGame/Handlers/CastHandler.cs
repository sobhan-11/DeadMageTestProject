using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class CastHandler : MonoBehaviour , IAbilitySource
    {
        private Actor _owner;
        private ActionHandler _actionHandler;
        private AbilityViewHUD _abilityViewHUD;
        
        [Header(" Setup ")] 
        public int index;
        public Sprite[] icon;
        

        public List<Ability> abilities;
        public List<AbilityAction> actions=new();
        public bool isUsing { get; protected set; }
        public int currentActionOrder;
        
        [Header(" Events "),Space(5)]
        public UnityEvent onStartAbility;
        public UnityEvent onEndAbility;
        
        
        private AbilityAction _currentAction;
        [HideInInspector] public ActionInfo currentActionInfo;

        private Coroutine resetAbilityRoutine;

        public void Init(Actor actor,ActionHandler actionHandler)
        {
            _owner = actor;
            _actionHandler = actionHandler;
            isUsing = false;
            for (int i = 0; i < abilities.Count; i++)
            {
                abilities[i].Init(this);
            }
            
            currentActionOrder = 0;
            
            InitHud();
        }
        
        public void StartCast(ActionInfo info)
        {
            _currentAction = actions.Find(x => x.castOrder == currentActionOrder);

            if (!IsReady())
            {
                return;
            }

            isUsing = true;
            onStartAbility?.Invoke();
            InvokeAction(_currentAction,info);
        }
        
        #region Events
        
        public void EndAbility(bool setCoolDown = true)
        {
            if (isUsing)
            {
                EnableMove();
                
                var endAction = actions.Find(x => x.endsAbility == true);
                if (endAction && setCoolDown)
                {
                    var coolDown = endAction.coolDown;
                    endAction.HandleCoolDown(coolDown);
                    ResetActionOrder();
                    StopAllCoroutines();
                }
                
                isUsing = false;
                onEndAbility?.Invoke();
            }
        }
        
        public void ResetAbility()
        {
            ResetActionOrder(); 
            isUsing = false;
            EnableMove();
        }

        #endregion

        #region CoolDown

        private float coolDown; 
        private float lastUsed;
        
        public float remainingCoolDown
        {
            get
            {
                if (lastUsed == 0)
                    return 0;
                var c = (coolDown - (Time.time - lastUsed));
                return c > 0 ? c : 0;
            }
        }
        
        private bool IsReady()
        {
            return remainingCoolDown <= 0;
        }
        
        public void StartCooldown(float _cooldown)
        {
            if (coolDown > _cooldown)
            {
                return;
            }

            coolDown = _cooldown;
            lastUsed = Time.time;
            _abilityViewHUD.StartCoolDown(remainingCoolDown);
        }

        #endregion

        #region HUD

        void InitHud()
        {
            // Index 0 for Dash
            if (index is 0)
            {
                return;
            }

            _abilityViewHUD = HUDManager.instance.GetAbilityViewByIndex(index);
        }

        #endregion

        #region Action

        private void InvokeAction(AbilityAction action , ActionInfo info)
        {
            action.InvokeAction(info);
        }
        
        #endregion

        #region IAbilitySource

        public Enum_TeamType GetTeamID()
        {
            return _owner.TeamType;
        }

        #endregion

        #region Utils

        public void EnableMove() => _actionHandler.EnableMove();
        public void DisableMove() => _actionHandler.DisableMove();

        public void ResetActionOrder() => currentActionOrder = 0;

        public void StartResetTimer(float timer)
        {
            if(resetAbilityRoutine!=null)
                StopCoroutine(resetAbilityRoutine);
            resetAbilityRoutine = StartCoroutine(ResetTimer(timer));
        }
        
        private IEnumerator ResetTimer(float timer)
        {
            yield return new WaitForSeconds(timer);
            ResetAbility();
        }

        #endregion

        
    }
    
    [Serializable]
    public class ResourceCost
    {
        public Enum_StatsType resource;
        public int cost;
    }
}