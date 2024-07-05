using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class Mover : MonoBehaviour
    {
        [Header("-- SETUP --")]
        public string moveName;
        public float speed;
        public AnimationCurve easeCurve;
        
        public bool isEnable;
        public bool destroyAtEnd;
        
        [Header("Look and Rotation Settings"),Space]
        public bool lookDirection;
        
        //---PV vars
        private Vector3 travelPath;
        private Vector3 destination;
        private Vector3 pos;
        private Vector3 startPos;
        private float startTime;
        private Transform target;
        private float duration;
        private float remainingTime;
        Vector3 lastPos;
        Vector3 lookDir;

        //public actions to subscribe in code
        public Action onReach;

        //unity events for inspector
        public UnityEvent onReachDestination;
        

        void Update()
        {
            if (!isEnable)
            {
                return;
            }

            if (target != null)
            {
                destination = target.position;
                travelPath = destination - startPos;
            }

            Run();
        }
        
        public void Run()
        {
            if (duration == 0)
            {
                return;
            }
            
            HandleMove();

            SetLookDirection();

            if (remainingTime <= 0)
            {
                EndOfPath();
            }
        }

        #region Config-Mover

        public void StartMove(Vector3 _origin, Vector3 _destination)
        {
            startTime = Time.time;
            isEnable = true;
            startPos = _origin;
            destination = _destination;
            travelPath = destination - startPos;
            duration = travelPath.magnitude / speed;
            remainingTime = duration;
        }

        public void StartMove(Vector3 _origin, Transform _target)
        {
            startTime = Time.time;
            isEnable = true;
            transform.position = _origin;
            startPos = _origin;
            target = _target;
            destination = target.position;
            travelPath = destination - startPos;
            duration = travelPath.magnitude / speed;
            remainingTime = duration;
        }
        
        public void StopMove()
        {
            isEnable = false;
        }
        
        public void ContinueMove()
        {
            isEnable = true;
        }

        #endregion

        #region Handle-Move

        void HandleMove()
        {
            remainingTime = duration - (Time.time - startTime);
            float t = (float)(1 - remainingTime / duration);
            
            float x = easeCurve.Evaluate(t);
            
            pos = startPos + (travelPath * x);

            lastPos = transform.position;

            transform.position = pos;
        }
        
        void SetLookDirection()
        {
            if (target)
            {
                lookDir = (target.position - transform.position).normalized;
            }
            else if (lookDirection)
            {
                lookDir = transform.position - lastPos;
            }

            lookDir.y = 0;
            transform.forward = lookDir;
        }

        void EndOfPath()
        {
            isEnable = false;

            onReach?.Invoke();
            onReachDestination?.Invoke();
            
            if (destroyAtEnd)
            {
                Destroy(this.gameObject,1f);
            }
        }

        #endregion
    }
}