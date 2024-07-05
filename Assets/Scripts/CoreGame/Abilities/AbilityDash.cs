using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame;
using UnityEngine;

public class AbilityDash : Ability
{
    [Header(" Components ")] 
    [SerializeField] private CharacterController body;
    
    [Header(" Config ")]
    [SerializeField] private LayerMask stopLayer;
    [SerializeField] private float range;
    [SerializeField] private float speed;

    private Vector3 target = Vector3.zero;
    private Vector3 travelPath = Vector3.zero;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private float startTime;
    private float duration;
    private float remainingTime;
    private bool isEnable;
    

    private void FixedUpdate()
    {
        if(!isEnable)
            return;
        HandleDash();
    }

    public void ApplyDash()
    {
        if(isEnable)
            return;
        velocity = body.velocity;
        target = GetOptimalTargetPosition();
        startTime = Time.time;
        startPosition = transform.position;
        travelPath = target - startPosition;
        duration = travelPath.magnitude / speed;
        remainingTime = duration;
        isEnable = true;
    }

    private void HandleDash()
    {
        GatherDashData();
        body.Move(velocity * Time.fixedDeltaTime);
        if(remainingTime<=0)
            OnDashEnd();
    }
    
    private void GatherDashData()
    {
        remainingTime = duration - (Time.time - startTime);
        velocity = transform.forward * speed;
    }

    public void OnDashEnd()
    {
        isEnable = false;
        (_castHandler as CastHandler).EndAbility();
    }


    #region Utils

    private Vector3 GetOptimalTargetPosition()
    {
        var tagretPosition = transform.position + (transform.forward * range);
        var direction = transform.forward;

        var hit= new RaycastHit();
        var raycast = Physics.Raycast(transform.position, direction,out hit, range, stopLayer);
        if (hit.collider != null)
        {
            tagretPosition = transform.position + (transform.forward * hit.distance);
        }

        return tagretPosition;
    }

    #endregion

}
