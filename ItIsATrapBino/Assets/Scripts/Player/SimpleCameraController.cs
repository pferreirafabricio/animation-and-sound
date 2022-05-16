using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SimpleCameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset = new Vector3(0, -0.9f, 3.8f);
    public float rotationSpeed = 2f;
    public float followSpeed = 25f;
    private SimplePlayerController simplePlayerController;
    private CharacterController charController;
 
    // Start is called before the first frame update
    void Start()
    {
        simplePlayerController = player.gameObject.GetComponent<SimplePlayerController>();
        charController = player.gameObject.GetComponent<CharacterController>();
    }
 
    // Position the camera to match the player
    public void PositionCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - player.transform.TransformDirection(cameraOffset), Time.fixedDeltaTime * followSpeed);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
 
    // Rotates the player to match the input
    public void RotatePlayer()
    {
        // not rotate the player if no user input
        Vector3 inputVector = simplePlayerController.GetCurrentInputVector();
        if ((inputVector.x != 0) || (inputVector.z != 0))
        {
            // not rotate the player if vertical input is negativ
            // this isn't perfect because the player cant run a backward loop
            // the solution was to flip the vertical input here
            if (inputVector.z < 0) inputVector.z = -inputVector.z;
 
            Vector3 eulerRotation = player.transform.eulerAngles;
            Quaternion lookRotation = this.transform.rotation;
            eulerRotation.y = Quaternion.LookRotation(lookRotation * inputVector.normalized).eulerAngles.y;
            eulerRotation.y = Mathf.LerpAngle(player.transform.eulerAngles.y, eulerRotation.y, rotationSpeed * Time.fixedDeltaTime);
            player.transform.eulerAngles = eulerRotation;
        }
    }
}