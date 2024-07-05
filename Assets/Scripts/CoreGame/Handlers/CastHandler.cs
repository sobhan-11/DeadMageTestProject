using System;
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
            //TODO Init HUD

        }
        
        public void StartCast(ActionInfo info)
        {
            _currentAction = actions.Find(x => x.castOrder == currentActionOrder);
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
                }

                onEndAbility?.Invoke();
                
                isUsing = false;
                StopAllCoroutines();
            }
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
        
        public void StartCooldown(float _cooldown)
        {
            if (coolDown > _cooldown)
            {
                return;
            }

            coolDown = _cooldown;
            lastUsed = Time.time;
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

            if (_abilityViewHUD == null)
                return;
            
            // try 
            // { 
            //     string keyName = string.Empty; 
            //     Sprite abilityIcon = null;
            //         if (inputHandler != null)
            //         {
            //             keyName = inputHandler.key.ToString();
            //         }
            //
            //         if (icon.Length > 0)
            //         {
            //             abilityIcon = icon[0];
            //         }
            //         else
            //         {
            //             if (abilities.Length > 0)
            //             {
            //                 abilityIcon = abilities[0].icon;
            //             }
            //         }
            //
            //         int abilityCost;
            //
            //         if (actions[0].costs.Length <= 0 || actions[0].costs == null)
            //         {
            //             abilityCost = 0;
            //         }
            //         else
            //         {
            //             abilityCost = actions[0].costs[0].cost;
            //         }
            //
            //         _abilityViewHUD.InitAbility(keyName, abilityCost, abilityIcon, LevelUpButtonOnClick, CastButtonOnClick);
            //     }
            //     catch (Exception)
            //     {
            //         Debug.LogWarning(" ... NO ICONE OR PROPPER KEY!");
            //     }
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

        #endregion

        
    }
    
    [Serializable]
    public class ResourceCost
    {
        public Enum_StatsType resource;
        public int cost;
    }
}