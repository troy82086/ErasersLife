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
    [SerializeField] float imagination = 100;

    private bool walkIsUnlocked;
    private bool carIsUnlocked;
    private bool planeIsUnlocked;

    private float startAmount;
    private int costOfWalk;
    private int costOfCar;
    private int costOfPlane;

    private void Start()
    {
        startAmount = imagination;
        walkIsUnlocked = Walking.GetComponent<PlayerWalk>().Unlocked;
        carIsUnlocked = Car.GetComponent<PlayerCar>().Unlocked;
        planeIsUnlocked = Plane.GetComponent<PlayerPlane>().Unlocked;
        costOfWalk = Walking.GetComponent<PlayerWalk>().cost;
        costOfCar = Car.GetComponent<PlayerCar>().cost;
        costOfPlane = Plane.GetComponent<PlayerPlane>().cost;

        if (walkIsUnlocked)
        {
            cameras[0].Render();
            Walking.SetActive(true);
            Car.SetActive(false);
            Plane.SetActive(false);
        }
        else if (carIsUnlocked)
        {
            cameras[1].Render();
            Walking.SetActive(false);
            Car.SetActive(true);
            Plane.SetActive(false);
        }
        else if (planeIsUnlocked)
        {
            cameras[2].Render();
            Walking.SetActive(false);
            Car.SetActive(false);
            Plane.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Walking.activeInHierarchy != true && walkIsUnlocked && imagination - costOfWalk > 0)
        {
            imagination -= costOfWalk;
            smoke.Play();
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
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Car.activeInHierarchy != true && carIsUnlocked && imagination - costOfCar > 0)
        {
            imagination -= costOfCar;
            smoke.Play();
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
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Plane.activeInHierarchy != true && planeIsUnlocked && imagination - costOfPlane > 0)
        {
            imagination -= costOfPlane;
            smoke.Play();
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
            Plane.GetComponent<PlayerPlane>().m_speed = 0;
        }
        //smoke.Stop();
        if (imagination < startAmount)
        {
            imagination += .25f * Time.deltaTime;
        }
    }
}
