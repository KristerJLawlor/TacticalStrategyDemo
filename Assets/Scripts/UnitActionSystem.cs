using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private void Update()
    {
        if(TryHandleUnitSelection())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit.Move(MouseWorld.GetPosition()); //call getposition from class MouseWorld to find where cursor is
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //spawn ray to position of cursor
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            //if raycast hits unit
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                selectedUnit = unit;
                return true;
            }
        }
        return false;
    }

}
