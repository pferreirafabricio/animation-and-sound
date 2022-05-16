using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class SimplePlayerController : MonoBehaviour
{
    public Camera m_camera;
    public float moveSpeed = 0.1f;
    private Vector3 currentInput;
    private Vector3 inputVector;
    private CharacterController characterController;
    private SimpleCameraController cameraController;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraController = m_camera.GetComponent<SimpleCameraController>();
    }
 
    void Update()
    {
        // read inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        currentInput = new Vector3(h, 0, v);
    }
 
    public Vector3 GetCurrentInputVector()
    {
        return currentInput;
    }
 
    void FixedUpdate()
    {
        inputVector = currentInput * moveSpeed;
 
        inputVector.x = 0; // no diagonal movement, because player will be driven by the vertical input
 
        Vector3 eulerAngles = this.transform.rotation.eulerAngles;
        eulerAngles.x = eulerAngles.z = 0;
        inputVector = Quaternion.Euler(eulerAngles) * inputVector; // input vector relativ to player and world space
        characterController.Move(inputVector);
        cameraController.RotatePlayer();
        cameraController.PositionCamera();
    }
 
}