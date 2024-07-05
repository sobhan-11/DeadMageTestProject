using System;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class AbilityAction : MonoBehaviour
    {
        private CastHandler _castHandler;
        
        [Header("-- Setup --")] 
        public int actionIndex;
        
        [Header("-- Cast Order --")]
        public int castOrder;
        public int changeCurrentOrderBy;

        [Header("-- Timing --")]
        public float preCastTime; 
        public float postCastTime; 
        
        [Header("-- PreCastEvents --") , Space(5)] 
        public ActionPack preCastActions;
        
        [Header("-- PreCastEvents --") , Space(5)] 
        public ActionPack castActions;
        
        [Header("-- CoolDown --") , Space(5)]
        public float coolDown;
        
        [Header("-- Resource --") , Space(5)]
        public ResourceCost[] costs;
        public bool useResource;
        
        [Header("-- AbilityEndAction --")]
        public bool endsAbility;

        /// <summary>
        /// controling main logic loop
        /// </summary>
        protected bool isUsing;
        bool _isStarted;
        public bool isStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; }
        }
        
        bool _isCasted;
        public bool isCasted
        {
            get { return _isCasted; }
            set { _isCasted = value; }
        }
        
        protected float timer;
        protected float lastTime;
        
        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (!isUsing)
            {
                return;
            }

            if (!isStarted)
            {
                StartAction();
                SetTimer(preCastTime);
                lastTime = Time.time;

                return;
            }
            
            if (Time.time - lastTime < timer)
            {
                return;
            }
            
            if (!isCasted)
            {
                CastAction();
                
                SetTimer(postCastTime);
                lastTime = Time.time;
                
                return;
            }

            EndAction();
        }
        
        private void Init()
        {
            _castHandler = transform.parent.gameObject.GetComponent<CastHandler>();
        }

        #region FireEvents
        
        public void InvokeAction()
        {
            if (isUsing)
            {
                return;
            }
            
            isUsing = true;
        }

        private void StartAction()
        {
            isStarted = true;
            preCastActions.FireEvents();
        }
        
        private void CastAction()
        {
            isCasted = true;
            
            castActions.FireEvents();
            HandleCastOrderChange();
        }
        
        private void EndAction()
        {
            isUsing = false;
            isStarted = false;
            isCasted = false;
            
            HandleCoolDown(coolDown);

            if (endsAbility)
            {
                _castHandler.EndAbility();
            }
        }

        #endregion

        #region Utils

        public void HandleCoolDown(float _coolDown)
        {
            if (_coolDown > 0)
            {
                _castHandler.StartCooldown(_coolDown);
            }
        }


        private void HandleCastOrderChange()
        {
            if (changeCurrentOrderBy != 0)
            {
                _castHandler.currentActionOrder += changeCurrentOrderBy;
            }
        }

        private void SetTimer( float value = 0)
        {
            timer = value;
        }
        
        

        #endregion
    }

    public enum Enum_AbilityActionState
    {
        None = 0,
        PreCast = 1,
        Cast = 2,
        PostCast = 3,
    }
    
    [Serializable]
    public class ActionPack
    {
        public UnityEvent actions;
        
        public void FireEvents()
        {
            actions?.Invoke();
        }
    }
}