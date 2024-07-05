using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace CoreGame
{
    public class CastHandler : MonoBehaviour
    {
        private AbilityViewHUD _abilityViewHUD;
        
        [Header(" Setup ")] 
        public int index;
        public Sprite[] icon;

        public List<Ability> abilities;
        public List<AbilityAction> actions=new();
        public bool isUsing { get; protected set; }
        private int currentActionOrder;

        public void Init()
        {
            OnAbilityEnd();
            for (int i = 0; i < abilities.Count; i++)
            {
                abilities[i].Init(this);
            }
            currentActionOrder = 0;
            //TODO Init HUD

        }
        
        

        #region Events

        public void OnAbilityStart()
        {
            isUsing = true;
        }
        
        public void OnAbilityEnd()
        {
            isUsing = false;
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
    }
}