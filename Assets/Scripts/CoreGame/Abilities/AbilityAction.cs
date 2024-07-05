using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class AbilityAction : MonoBehaviour
    {
        [Header("-- PreCastEvents --")] 
        public UnityEvent onStart;
        
        

    }

    public enum Enum_AbilityActionState
    {
        None = 0,
        PreCast = 1,
        Cast = 2,
        PostCast = 3,
    }
}