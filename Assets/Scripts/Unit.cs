using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator; //create animator reference
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        
        float stoppingDistance = .1f;   
        //prevent stuttering while attempting to reach destination
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;   //get direction with value between 0 and 1
            
            float moveSpeed = 4f;
            float rotateSpeed = 10f;
            //update position by adding vector values to current position
            //moveDirection is a normalized vector for just direction
            //moveSpeed is the magnitude of the direction
            //deltaTime prevents higher and lower framerates having different movement speeds
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            this.transform.forward = Vector3.Lerp(this.transform.forward, moveDirection, Time.deltaTime * rotateSpeed); //face the normalized direction vector smoothly

            unitAnimator.SetBool("IsWalking", true);    //set animation to walking
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);   //set animation to idle
        }
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
