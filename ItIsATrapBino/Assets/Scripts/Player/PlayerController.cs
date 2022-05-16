using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private float _gravity = 9.81f;

    [SerializeField]
    private CharacterController _controller;

    void Start() => _controller = GetComponent<CharacterController>();

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 Direction = new Vector3(HorizontalInput, 0, VerticalInput);
        Vector3 Velocity = Direction * _speed;
        Velocity.y -= _gravity;

        Velocity = transform.transform.TransformDirection(Velocity);

        _controller.Move(Velocity * Time.deltaTime);
    }

    public void ChangeSpeed(float speed) => _speed = speed;
}
