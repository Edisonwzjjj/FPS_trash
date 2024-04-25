using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private float mouseSensitivity = 8.0f;

    [SerializeField]
    private float thrusterForce = 20.0f;

    private ConfigurableJoint joint;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = Input.GetAxis("Horizontal");
        float ymove = Input.GetAxis("Vertical");
        Vector3 velocity = (transform.right * xmove + transform.forward * ymove).normalized * speed;
        controller.Move(velocity);

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        Vector3 yRotation = new Vector3(0f, mouseX, 0f) * mouseSensitivity;
        Vector3 xRotation = new Vector3(mouseY, 0f, 0f) * mouseSensitivity;
        controller.Rotate(yRotation, xRotation);

        Vector3 force = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            force = Vector3.up * thrusterForce;
            joint.yDrive = new JointDrive {
                positionSpring = 0,
                positionDamper = 0,
                maximumForce = 0,
            };
        } else {
            joint.yDrive = new JointDrive {
                positionSpring = 20,
                positionDamper = 0,
                maximumForce = 40,
            };
        }
        controller.Thrust(force);
    }
}


