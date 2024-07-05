using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame
{
    public class Ability : MonoBehaviour , ICreator
    {
        protected IAbilitySource _castHandler;
        
        public void Init(IAbilitySource castHandler)
        {
            _castHandler = castHandler;
        }


        #region ICreator

        public void SetupNewEntity(ICreatable createdObject, ActionInfo creationInfo)
        {
            createdObject.SetupSelf(this, creationInfo);
        }

        #endregion
    }

    public class ActionInfo
    {
        public ActionInfo()
        {
        }
        
        public ActionInfo(Enum_TeamType _teamId, float _startTime, float _range,
            float _size, Vector3 _start, Vector3 _end, Vector3 _dir)
        {
            teamId = _teamId;
            startTime = _startTime;
            range = _range;
            size = _size;
            startPoint = _start;
            endPoint = _end;
            direction = _dir;
        }
        
        public Enum_TeamType teamId;
        
        public Vector3 startPoint;
        public Vector3 endPoint;
        public Vector3 direction;

        public float range;
        public float size;
        
        public float startTime;
    }

    public interface IAbilitySource
    {
        public Enum_TeamType GetTeamID();
    }
    
    public interface ICreator
    {
        public void SetupNewEntity(ICreatable creation, ActionInfo creationInfo);
    }
    
    public interface ICreatable
    {
        public void SetupSelf(ICreator ability, ActionInfo castInfo);
    }

    public interface IDestructible
    {
        public void Destroy();
    }
}

