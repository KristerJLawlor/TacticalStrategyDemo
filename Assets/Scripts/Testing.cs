using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Unit unit; //reference to the UnitActionSystem script

    // Start is called before the first frame update
    private void Start()
    {

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            //when space is pressed, set the selected unit to the unit reference
            unit.GetMoveAction().GetValidActionGridPositionList();
        }
    }
}
