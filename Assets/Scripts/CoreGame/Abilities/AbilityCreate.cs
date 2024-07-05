using CoreGame;
using UnityEngine;

public class AbilityCreate : Ability
{
    [Header("-- CREATION --"),Space(5)]
    public GameObject myObjectPrefab;
    [Space(10)] public Transform spawnPlace;


    #region Create

    public void CreateAbilityObject(ActionInfo castInfo)
    {
        var go = Instantiate(myObjectPrefab, spawnPlace.position, Quaternion.LookRotation(transform.forward));
        var obj = go.GetComponent<ICreatable>();
        
        if (_castHandler != null)
        {
            castInfo.teamId = _castHandler.GetTeamID();
            castInfo.startPoint = spawnPlace.position;
        }
        else
        {
            Debug.LogWarning("ab needs atleast one ab Handler ===>" + gameObject.name);
        }
        
        SetupNewEntity(obj, castInfo);
    }

    #endregion
}
