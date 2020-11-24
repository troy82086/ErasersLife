using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -75;
    private const float ZERO_SPEED_ANGLE = -30;

    [SerializeField] SettingsValues settingsValues = null;
    [SerializeField] Transform needle = null;
    [SerializeField] Transform player = null;
    [SerializeField] Transform camera = null;
    [SerializeField] Transform pauseCamera = null;
    [SerializeField] int turnSpeed = 1;
    [SerializeField] float m_maxSpeed = 1;
    [SerializeField] float m_speed = 1;

    public float energyUsage = 1;
    public int cost = 5;
    public bool Unlocked = false;
    private int impericalOrMetric = 1;

    void Update()
    {
        impericalOrMetric = settingsValues.GetImpericalOrMetric();

        Vector3 velocity = Vector3.zero;
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        float h = turnSpeed * Input.GetAxis("Horizontal");

        Quaternion rotation = player.rotation;
        rotation.eulerAngles += new Vector3(0, h, 0);
        player.transform.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime * 10);

        if (Input.GetKey(KeyCode.W) && m_speed < m_maxSpeed)
        {
            m_speed += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S) && m_speed > -m_maxSpeed / 2)
        {
            m_speed -= 0.1f;
        }
        else if (m_speed > 0.01)
        {
            m_speed -= 0.01f;
        }
        else if (m_speed < -0.01)
        {
            m_speed += 0.01f;
        }

        float forward = m_speed;

        Vector3 FORWARD = player.TransformDirection(Vector3.up);

        
        player.localPosition += FORWARD * forward;
        needle.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        camera.localPosition = new Vector3(player.localPosition.x, camera.localPosition.y, player.localPosition.z);
        camera.eulerAngles = new Vector3(camera.eulerAngles.x, 0, -player.eulerAngles.y + 180);
        pauseCamera.localPosition = new Vector3(player.localPosition.x, pauseCamera.localPosition.y, player.localPosition.z);
        pauseCamera.eulerAngles = new Vector3(pauseCamera.eulerAngles.x, 0, -player.eulerAngles.y + 180);
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormal = 0;
        if (m_speed > 0) speedNormal = m_speed / m_maxSpeed; 
        if (m_speed < 0) speedNormal = -m_speed / m_maxSpeed;
        if (impericalOrMetric == 0) speedNormal *= 1.60934f;
        return ZERO_SPEED_ANGLE - speedNormal * totalAngleSize;
    }
}
