using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;

    private void Update()
    {
        float stoppingDistance = .1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;   //get direction with value between 0 and 1

            float moveSpeed = 4f;
            //update position 
            transform.position += (moveDirection * moveSpeed) * Time.deltaTime;   //deltaTime prevents higher and lower framerates having different movement speeds
        }
    }

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
