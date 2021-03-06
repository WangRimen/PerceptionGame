﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource flyaudio;

    public float speed=1.0f;
    public float JumpForce=0.3f;
    public float FlyForce = 0.95f;
    public int fly_count = 0;
    public float camSensitivty = 5f;
    public Transform camtransform;
    public float camMaxAngle = 85.0f;
	public float gravity = -9.18f;

    private CharacterController _controller;
    private Vector3 _velocity;
    private Vector2 mouseLook;

    bool _isGrounded;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();

        
    }

    void Update()
    {


        //Movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.rotation * move;
        _controller.Move(move * Time.deltaTime * speed);
        //if (move != Vector3.zero)
        //    transform.forward = move;


        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        _isGrounded = _controller.isGrounded;
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        if (Input.GetButtonDown("Jump"))
        {
            if (fly_count > 0)
            {
                flyaudio.Play();
                _velocity.y += -FlyForce * gravity;
                fly_count--;
            }
            if (_isGrounded )
            {
                _velocity.y += -JumpForce * gravity;
            }

        }

            
        /*
        if (Input.GetButtonDown("Jump") && _isGrounded)
            
            */


        //Cam Controll

        Vector2 rawMouseInput = new Vector2(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
        mouseLook += rawMouseInput * camSensitivty;
        mouseLook.x = Mathf.Clamp(mouseLook.x, -camMaxAngle, camMaxAngle);
        transform.localEulerAngles = new Vector3(0, mouseLook.y, 0);
        //Debug.Log(mouseLook.y);
        //camtransform.Rotate(new Vector3(-rawMouseInput.x,0, 0));
        camtransform.localEulerAngles = new Vector3(-mouseLook.x,0,0);
        /*
        if (camtransform.eulerAngles.x > 90)
            camtransform.eulerAngles = new Vector3(90,0,0);
        if (camtransform.eulerAngles.x < -90)
            camtransform.eulerAngles = new Vector3(-90, 0, 0);
            */
    }

}
