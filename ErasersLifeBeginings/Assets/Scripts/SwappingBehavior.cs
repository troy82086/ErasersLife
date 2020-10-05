using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingBehavior : MonoBehaviour
{
    [SerializeField] GameObject Walking = null;
    [SerializeField] GameObject Car = null;
    [SerializeField] GameObject Plane = null;
    [SerializeField] Camera[] cameras = null;
    [SerializeField] ParticleSystem smoke = null;

    private void Start()
    {
        cameras[0].Render();
        Walking.SetActive(true);
        Car.SetActive(false);
        Plane.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Walking.activeInHierarchy != true)
        {
            cameras[0].Render();
            if (Car.activeInHierarchy == true)
            {
                Walking.transform.position = new Vector3(Car.transform.position.x, Car.transform.position.y + 2.54f, Car.transform.position.z);
            
                Vector3 eulerRotation = new Vector3(Walking.transform.eulerAngles.x, Car.transform.eulerAngles.y, Walking.transform.eulerAngles.z);
                Walking.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            if (Plane.activeInHierarchy == true)
            {
                Walking.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y + 2.54f, Plane.transform.position.z);
               
                Vector3 eulerRotation = new Vector3(Walking.transform.eulerAngles.x, Plane.transform.eulerAngles.y, Walking.transform.eulerAngles.z);
                Walking.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            Walking.SetActive(true);
            Car.SetActive(false);
            Plane.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Car.activeInHierarchy != true)
        {
            cameras[1].Render();
            if (Walking.activeInHierarchy == true)
            {
                Car.transform.position = new Vector3(Walking.transform.position.x, Walking.transform.position.y - 2.54f, Walking.transform.position.z);

                Vector3 eulerRotation = new Vector3(Car.transform.eulerAngles.x, Walking.transform.eulerAngles.y, Car.transform.eulerAngles.z);
                Car.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            if (Plane.activeInHierarchy == true)
            {
                Car.transform.position = Plane.transform.position;

                Vector3 eulerRotation = new Vector3(Car.transform.eulerAngles.x, Plane.transform.eulerAngles.y, Car.transform.eulerAngles.z);
                Car.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            Walking.SetActive(false);
            Car.SetActive(true);
            Plane.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Plane.activeInHierarchy != true)
        {
            cameras[2].Render();
            if (Walking.activeInHierarchy == true)
            {
                Plane.transform.position = new Vector3(Walking.transform.position.x, Walking.transform.position.y - 2.54f, Walking.transform.position.z);
               
                Vector3 eulerRotation = new Vector3(Plane.transform.eulerAngles.x, Walking.transform.eulerAngles.y, Plane.transform.eulerAngles.z);
                Plane.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            if (Car.activeInHierarchy == true)
            {
                Plane.transform.position = Car.transform.position;

                Vector3 eulerRotation = new Vector3(Plane.transform.eulerAngles.x, Car.transform.eulerAngles.y, Plane.transform.eulerAngles.z);
                Plane.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            Walking.SetActive(false);
            Car.SetActive(false);
            Plane.SetActive(true);
            PlayerPlane.m_speed = 0;
        }
    }
}
