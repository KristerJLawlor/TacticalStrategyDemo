using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    //awake is called before the application starts and is only called once per lifetime of the script.
    //is used to initialize variables and states without instantiating instances during the game
    private void Awake()
    {
        //create an instance of MouseWorld so we can get the layermask used for the Raycast overload
        instance = this;
    }

    //static makes the function call-able without an instance(object). It belongs to the class, not any individual instance
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //spawn ray to position of cursor
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point; //return the world position where the raycast collides
    }
}
