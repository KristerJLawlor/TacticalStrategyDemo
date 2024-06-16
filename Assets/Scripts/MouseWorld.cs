using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.position = MouseWorld.GetPosition();  //move object to cursor location
    }

    //static makes the function call-able without an instance(object). It belongs to the class, not any individual instance
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }
}
