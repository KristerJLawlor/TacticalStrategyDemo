using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private const float MIN_FOLLOW_OFFSET_Y = 2f;
    private const float MAX_FOLLOW_OFFSET_Y = 12f;
    private CinemachineTransposer cinemachineTransposer;
    private Vector3 targetFollowOffset;

    private void Start()
    {
        // Set the initial follow offset to the current value
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;

    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        //lateral camera movement 
        Vector3 inputMoveDir = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        float moveSpeed = 10f;

        // Calculate the move vector based on the camera's forward and right directions,
        // such that moving forward/back/left/right is relative to the camera's rotational orientation.
        Vector3 moveVector = (transform.forward * inputMoveDir.z) + (transform.right * inputMoveDir.x);
        transform.position += moveVector * moveSpeed * Time.deltaTime;


    }

    private void HandleRotation()
    {
        //rotational camera movement
        Vector3 rotationVector = new Vector3(0,0,0);
        
        if (Input.GetKey(KeyCode.Q))
            {
                rotationVector.y = +1f;
            }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }

        float rotationSpeed = 100f;

        //calculate whether the camera rotates in a positive or negative y direction
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
        
    }

    private void HandleZoom()
    {
        //change the zoom level of the camera based on scroll wheel input within the set boundaries
        float zoomAmount = 1f;
        float zoomSpeed = 5f;

        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount;
        }
        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_OFFSET_Y, MAX_FOLLOW_OFFSET_Y);
        //ease the camera zoom in and out with Lerp
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);

    }

}
