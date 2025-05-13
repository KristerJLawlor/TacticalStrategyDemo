using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    //make LevelGrid class a singleton
    public static LevelGrid Instance { get; private set; } //static instance of the class

    [SerializeField] private Transform gridDebugObjectPrefab;

    private GridSystem gridSystem;

    private void Awake()
    {
        //check if Instance has already been set before (we dont want that)
        if (Instance != null)
        {
            Debug.LogError("There is more than one ActionSystem!" + transform + " " + Instance);
            Destroy(gameObject);    //destroy this object to prevent duplicating the pre-existing instance
            return;
        }
        Instance = this;

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit); //set the unit at the grid position
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList(); //get the unit at the grid position
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit); //remove the unit value at the grid position
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit); //clear the unit at the old grid position
        AddUnitAtGridPosition(toGridPosition, unit); //set the unit at the new grid position
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return gridSystem.GetGridPosition(worldPosition);
    }
}

