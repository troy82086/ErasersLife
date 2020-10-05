using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;
    [SerializeField] Transform player = null;
    [SerializeField] int horizontalSpeed = 1;
    [SerializeField] int m_speed = 1;
    [SerializeField] int jumpforce = 5;

    private bool touchingFloor;

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        float h = horizontalSpeed * Input.GetAxis("Horizontal");

        Quaternion rotation = player.rotation;
        rotation.eulerAngles += new Vector3(0, h, 0);
        player.transform.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime * 10);

        float forward = Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        Vector3 FORWARD = player.TransformDirection(Vector3.back);
        Vector3 UP = player.TransformDirection(Vector3.up);

        player.transform.localPosition += FORWARD * forward;

        if (Input.GetKey(KeyCode.Space) && touchingFloor)
        {
            rb.AddForce(new Vector3(0, jumpforce, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("floor")) touchingFloor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("floor")) touchingFloor = false;
    }
}
