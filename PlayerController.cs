using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 yRotation = Vector3.zero; // 角色旋转
    private Vector3 xRotation = Vector3.zero; // 摄像机旋转 

    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private Camera cam;

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Thrust(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

    public void Rotate(Vector3 _yRotation, Vector3 _xRotation)
    {
        yRotation = _yRotation;
        xRotation = _xRotation;
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce);
        }
    }

    private void PerformRotation()
    {
        if (yRotation != Vector3.zero)
        {
            // rb.MoveRotation(rb.rotation * Quaternion.Euler(yRotation));
            rb.transform.Rotate(yRotation);
        }
        if (xRotation != Vector3.zero)
        {
            cam.transform.Rotate(-xRotation);
        }
    }
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}
