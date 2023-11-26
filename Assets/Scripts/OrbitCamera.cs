using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    
    public Transform _focus;
    public float RotationSpeed = 100f;
    public float OrbitDistance = 5f;
    public float MinAngle = -20f;
    public float MaxAngle = 90f;
    
    private Vector3 _input;
    [SerializeField]
    private Vector3 _orbitAngle = new Vector3(45f, 0, 0);

    private void Start()
    {
        LockMouse();
    }

    private void Update()
    {
        _input = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0 );
    }
    private void LateUpdate()
    {
        ManualRotation();
        ConstrainAngles();
        
        Quaternion lookRotation = transform.localRotation;

        lookRotation = Quaternion.Euler(_orbitAngle);

        //If we multiply a quaternion and a vector, you will rotate that vector
        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 camPosition = _focus.position - lookDirection * OrbitDistance;
        
        transform.SetPositionAndRotation( camPosition ,lookRotation);
    }
    private void ManualRotation()
    {
        _orbitAngle += _input * RotationSpeed * Time.deltaTime;
    }

    void ConstrainAngles()
    {
        _orbitAngle.x = Mathf.Clamp(_orbitAngle.x,MinAngle,MaxAngle);
    }

    void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
