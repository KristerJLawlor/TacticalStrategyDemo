using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cannot extend GridSystem from MonBehaviour because it will not allow you to build a constructor
public class GridSystem
{
    private int width;
    private int length;
    private float cellSize;
    public GridSystem(int width, int length,float cellSize) 
    { 
        this.width = width;
        this.length = length;
        this.cellSize = cellSize;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + Vector3.right * .2f, Color.white, 1000);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.x / cellSize)
            );
    }
}
