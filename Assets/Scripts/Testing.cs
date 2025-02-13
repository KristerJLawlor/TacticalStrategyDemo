using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;

    // Start is called before the first frame update
    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);

        Debug.Log(new GridPosition(5, 7));
    }
    private void Update()
    {
        //will get the grid position under the mouse
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}
