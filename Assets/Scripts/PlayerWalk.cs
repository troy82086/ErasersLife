using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] Rigidbody rb = null;
    [SerializeField] Transform player = null;
    [SerializeField] Transform camera = null;
    [SerializeField] Transform pauseCamera = null;
    [SerializeField] AudioSource footSteps = null;
    [SerializeField] int horizontalSpeed = 1;
    [SerializeField] int m_speed = 1;
    [SerializeField] int jumpforce = 5;
    [SerializeField] int walkforce = 5;

    public int cost = 5;
    public float energyUsage = -1;
    public bool Unlocked = false;
    private bool touchingFloor;

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");

        float h = horizontalSpeed * Input.GetAxis("Horizontal");

        Quaternion rotation = player.rotation;
        rotation.eulerAngles += new Vector3(0, h, 0);
        player.eulerAngles = new Vector3(0, player.eulerAngles.y, 0);
        player.transform.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime * 10);

        if (Input.GetAxis("Vertical") > 0 && touchingFloor)
        {
            rb.AddForce(new Vector3(0, walkforce, 0));
        }
        float forward = Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        Vector3 FORWARD = player.TransformDirection(Vector3.back);

        player.transform.localPosition += FORWARD * forward;

        if ((Input.GetKey(KeyCode.Space)) && touchingFloor)
        {
            rb.AddForce(new Vector3(0, jumpforce, 0));
        }

        if(touchingFloor && forward != 0f && footSteps.isPlaying == false)
        {
            footSteps.volume = Random.Range(0.8f, 1);
            footSteps.pitch = Random.Range(0.8f, 1.1f);
            footSteps.Play();
        }

        camera.localPosition = new Vector3(player.localPosition.x, camera.localPosition.y, player.localPosition.z);
        camera.eulerAngles = new Vector3(camera.eulerAngles.x, 0, -player.eulerAngles.y + 180);
        pauseCamera.localPosition = new Vector3(player.localPosition.x, pauseCamera.localPosition.y, player.localPosition.z);
        pauseCamera.eulerAngles = new Vector3(pauseCamera.eulerAngles.x, 0, -player.eulerAngles.y + 180);
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
