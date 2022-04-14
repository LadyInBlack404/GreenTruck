using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour

{

    // Variables
    //public float speed = 5.0f;
    //public float turnSpeed;
    //private float horizontalInput;
    //private float verticalInput;
    //private float velocity;
    //public float _Acc = 0.0f;           // Current Acceleration
    //public float _AccSpeed = 0.05f;      // Amount to increase Acceleration with.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
        ////Player input
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //if (Input.GetKey(KeyCode.UpArrow))
        //    _Acc += _AccSpeed;
        //else if (Input.GetKey(KeyCode.DownArrow))
        //    _Acc -= _AccSpeed;
        //else
        //{

        //    _Acc = 0;
        //    velocity *= 0.9f;
        //}
        //// Move the vehicle forward
        //velocity += _Acc * Time.deltaTime;
        //transform.Translate(Vector3.forward * Time.deltaTime * velocity);

        //// transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

        //// Turn the vehicle
        //transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);






        //        Console.WriteLine("Rozmiar zmiennej typu int: {0}", sizeof(int));
        //        Console.ReadLine();

       


    //}
    public float turnSpeed = 50f;
    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 15.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 0.1f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 10.0f;        // Max Acceleration
    public float _MinAcc = -10.0f;       // Min Acceleration


    void Update()
    {
        bool isCHnginAcceleration = false;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _Acc += _AccSpeed;
            isCHnginAcceleration=true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { 
            _Acc -= _AccSpeed;
            isCHnginAcceleration = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);


        if (_Acc > _MaxAcc)
            _Acc = _MaxAcc;
        else if (_Acc < _MinAcc)
            _Acc = _MinAcc;
        if (isCHnginAcceleration)
            _Velocity += _Acc;
        else
            _Velocity *= 0.99f;
        if (_Velocity > _MaxVelocity)
            _Velocity = _MaxVelocity;
        else if (_Velocity < -_MaxVelocity)
            _Velocity = -_MaxVelocity;

        transform.Translate(Vector3.forward * _Velocity * Time.deltaTime);
    }
}
