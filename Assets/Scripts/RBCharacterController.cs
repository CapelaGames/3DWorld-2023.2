using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class RBCharacterController : MonoBehaviour
{
    public float Speed = 10f;
    public float Jump = 5f;
    public float GroundCheckDistance = 1.5f;

    private bool _isGrounded;
    
    private Animator _animator;
    private Vector3 _input;
    private Rigidbody _rigidbody;
    private Camera _camera;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        JumpAction();
        UpdateAnimation();
        RotateToCameraDirection();
    }

    private void JumpAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * Jump, ForceMode.VelocityChange);
        }
    }

    private bool IsGroundedCheck()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position + new Vector3(0,0.1f,0),
                Vector3.down,
                out hitInfo, 
                GroundCheckDistance))
        {
            //Debug.Log(hitInfo.transform.name);
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position + new Vector3(0,0.1f,0), Vector3.down * GroundCheckDistance);
    }

    void RotateToCameraDirection()
    {
        Vector3 newForward = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up);//.normalized;
        newForward.Normalize();

        if (newForward != Vector3.zero)
        {
            transform.forward = newForward;
        }
        else
        {
            transform.forward = _camera.transform.up;
        }
    }

    void UpdateAnimation()
    {
        if (_animator == null)
        {
            return;
        }
        if (_input.magnitude > 0.01f)
        {
           _animator.SetBool("IsWalking", true); 
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = IsGroundedCheck();
        Vector3 movement = _input ;

        movement = _camera.transform.TransformDirection(movement);
        movement = Vector3.ProjectOnPlane(movement, Vector3.up).normalized;
        movement *= Speed;

        if (_input != Vector3.zero && movement == Vector3.zero)
        {
            movement = transform.TransformDirection(_input).normalized * Speed;
        }
        
        _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
    }
}
