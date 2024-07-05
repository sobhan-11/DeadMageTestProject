using UnityEngine;

namespace CoreGame
{
    public class Trigger : MonoBehaviour
    {
        public event OnTriggerDelegate onTriggerEnter;
        public event OnTriggerDelegate onTriggerExit;
        public event OnTriggerDelegate onTriggerStay;

        protected virtual void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke(other);
        }

        protected virtual void OnTriggerExit(Collider other)
        {

            onTriggerExit?.Invoke(other);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            onTriggerStay?.Invoke(other);
        }
    }
    public delegate void OnTriggerDelegate(Collider other);
}