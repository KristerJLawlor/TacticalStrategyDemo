using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    //singleton to define instance of this class with public get and private set methods that can be called from any other script
    //singleton pattern ensures only one instance of its type exists by checking in awake that it has no duplicates
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChanged;  //use event delegate to handle event when selected unit is changed by triggering all functions associated with it
    
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;


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
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection())
            {
                return;
            }
            else
            {
                selectedUnit.Move(MouseWorld.GetPosition()); //call getposition from class MouseWorld to find where cursor is
            }
           
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
                SetselectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SetselectedUnit(Unit unit)
    {
        selectedUnit = unit;
        //check if there are event subscribers, then call delegate function if true
        //will fire if selected unit changes
        //this delegate's broadcast is being listened to in the UnitSelectedVisual script
        if(OnSelectedUnitChanged != null)
        {
            OnSelectedUnitChanged(this, EventArgs.Empty);   //pass unit as parameter
        }
        //OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty); <-shorthand for above code block    
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;    //publicly access the private unit variable
    }

}
