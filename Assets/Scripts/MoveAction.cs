using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator; //create animator reference
    [SerializeField] private int maxMoveDistance = 4; //distance the unit can move

    private Vector3 targetPosition;
    private Unit unit; //reference to the Unit component

    private void Awake()
    {
        unit = GetComponent<Unit>(); //get the Unit component from the object this script is attached to
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

    //Get a list of valid grid positions that the unit can move to
    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z); //create a new grid position with the offset values
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition; //add the offset to the unit's current grid position
                Debug.Log($"Testing grid position: {testGridPosition}"); //log the test grid position
            }
        }

        return validGridPositionList; //return list
    }
}
