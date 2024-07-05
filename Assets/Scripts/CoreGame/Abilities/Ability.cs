using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame
{
    public class Ability : MonoBehaviour
    {
        protected CastHandler _castHandler;
        
        public void Init(CastHandler castHandler)
        {
            _castHandler = castHandler;
        }
    }
}

