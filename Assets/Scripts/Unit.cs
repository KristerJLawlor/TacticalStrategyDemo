using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition; //create grid position reference
    private MoveAction moveAction; //create move action reference

    private void Awake()
    {
        //get the MoveAction component from the unit object
        moveAction = GetComponent<MoveAction>();
    }

    private void Start()
    {
        //when the unit starts, it calculates its own grid position and sets itself to that position
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position); //set the grid position of the unit to the unit object 
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position); //get position of unit from LevelGrid instance
        if(newGridPosition != gridPosition) //if the unit has moved to a new grid position. Requires override code in GridPosition.cs
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition; //update the grid position of the unit
        }
    }

    public MoveAction GetMoveAction()
    {
        return moveAction; //return the MoveAction component
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition; //return the grid position of the unit
    }
}
