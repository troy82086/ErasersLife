using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] int turnSpeed = 1;
    [SerializeField] int m_speed = 1;

    public bool Unlocked = false;

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        float h = turnSpeed * Input.GetAxis("Horizontal");

        Quaternion rotation = player.rotation;
        rotation.eulerAngles += new Vector3(0, h, 0);
        player.transform.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime * 10);

        float forward = Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        Vector3 FORWARD = player.TransformDirection(Vector3.up);

        player.transform.localPosition += FORWARD * forward;
    }
}
