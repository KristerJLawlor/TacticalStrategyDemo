using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;  //grid container
    private GridPosition gridPosition; //position on grid
    private List<Unit> unitList; //unit list for grid

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>(); //initialize unit list
    }

    public override string ToString()
    {
        string unitString = "";
        foreach (Unit unit in unitList) //for each unit in the unit list
        {
            unitString += unit + "\n"; //add unit to string
        }
        return gridPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit); //add unit to unit list
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit); //remove unit to unit list
    }


    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0; //return true if there is at least one unit in the list
    }

}

