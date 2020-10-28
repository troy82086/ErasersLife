using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] int horizontalSpeed = 1;
    [SerializeField] int verticalSpeed = 1;
    [SerializeField] int rotatationSpeed = 1;
    [SerializeField] float maxSpeed = 5;
    [SerializeField] float minSpeed = -5;
    [SerializeField] float idleSpeed = 4f;
    [SerializeField] float fallingSpeed = 3.9f;

    public Transform cameraTransform = null;
    public int cost = 5;
    public bool Unlocked = false;
    public float m_speed = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Transform par = transform.parent.transform;
        transform.rotation = Quaternion.identity;

        Vector3 velocity = Vector3.zero;
        velocity.z = verticalSpeed * Input.GetAxis("Up and Down");

        float pitch = verticalSpeed * Input.GetAxis("Up and Down");
        float roll = horizontalSpeed * Input.GetAxis("A and D");
        float yaw = horizontalSpeed * Input.GetAxis("Left and Right");

        transform.RotateAround(transform.position, par.right, pitch);
        transform.RotateAround(transform.position, par.up, -yaw);
        transform.RotateAround(transform.position, par.forward, roll);
        
        if (Input.GetKey(KeyCode.W) && m_speed < maxSpeed)
        {
            m_speed += 0.5f;
        }
        else if (Input.GetKey(KeyCode.S) && m_speed > minSpeed)
        {
            m_speed -= 0.5f;
        }
        else if (m_speed > 0 && m_speed > idleSpeed)
        {
            m_speed -= 0.1f;
        }
        else if (m_speed < 0 && m_speed < -idleSpeed)
        {
            m_speed += 0.1f;
        }

        if (m_speed < fallingSpeed)
        {
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }

        float forward = m_speed * Time.deltaTime;

        Vector3 FORWARD = player.TransformDirection(Vector3.up);

        player.localPosition += FORWARD * forward;

        cameraTransform.eulerAngles = new Vector3(90, 0, -player.eulerAngles.y + 180);
        cameraTransform.localPosition = new Vector3(player.localPosition.x, cameraTransform.localPosition.y, player.localPosition.z);
    }
}

