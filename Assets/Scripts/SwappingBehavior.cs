using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwappingBehavior : MonoBehaviour
{
    [SerializeField] Camera[] cameras = null;
    [SerializeField] float imagination = 100;
    [SerializeField] float finishTimer = 2.5f;
    [SerializeField] GameObject Walking = null;
    [SerializeField] GameObject Car = null;
    [SerializeField] GameObject Plane = null;
    [SerializeField] GameObject[] UISwapTypes = null;
    [SerializeField] Slider imaginationBar = null;
    [SerializeField] ParticleSystem smoke = null;

    private bool walkIsUnlocked;
    private bool carIsUnlocked;
    private bool planeIsUnlocked;

    private float timer = 16f;
    private float startAmount;


    private int costOfWalk;
    private int costOfCar;
    private int costOfPlane;

    private float topPlane = 350, bottomPlane = 288, leftPlane = 475, rightPlane = 540;
    private float topCar = 287, bottomCar = 221, leftCar = 435, rightCar = 500;
    private float topWalk = 287, bottomWalk = 221, leftWalk = 515, rightWalk = 580;

    private void Start()
    {
        startAmount = imagination;
        costOfWalk = Walking.GetComponent<PlayerWalk>().cost;
        costOfCar = Car.GetComponent<PlayerCar>().cost;
        costOfPlane = Plane.GetComponent<PlayerPlane>().cost;

        walkIsUnlocked = Walking.GetComponent<PlayerWalk>().Unlocked;
        carIsUnlocked = Car.GetComponent<PlayerCar>().Unlocked;
        planeIsUnlocked = Plane.GetComponent<PlayerPlane>().Unlocked;

        if (walkIsUnlocked)
        {
            goWalk();
        }
        else if (carIsUnlocked)
        {
            goCar();
        }
        else if (planeIsUnlocked)
        {
            goPlane();
        }
    }

    void Update()
    {
        walkIsUnlocked = Walking.GetComponent<PlayerWalk>().Unlocked;
        carIsUnlocked = Car.GetComponent<PlayerCar>().Unlocked;
        planeIsUnlocked = Plane.GetComponent<PlayerPlane>().Unlocked;

        if (Input.GetKey(KeyCode.Tab)) timer = 0f;
        if (Input.GetKey(KeyCode.Tab) || timer <= 5f)
        {
            timer += Time.deltaTime;

            if (planeIsUnlocked)
            {
                UISwapTypes[0].SetActive(true);
            }
            if (carIsUnlocked)
            {
                UISwapTypes[1].SetActive(true);
            }
            if (walkIsUnlocked)
            {
                UISwapTypes[2].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && Walking.activeInHierarchy != true && walkIsUnlocked && imagination - costOfWalk > 0)
            {
                goWalk();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && Car.activeInHierarchy != true && carIsUnlocked && imagination - costOfCar > 0)
            {
                goCar();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && Plane.activeInHierarchy != true && planeIsUnlocked && imagination - costOfPlane > 0)
            {
                goPlane();
            }
        }

        if (timer >= finishTimer && timer < 10f)
        {
            mouseOver();
            UISwapTypes[0].SetActive(false);
            UISwapTypes[1].SetActive(false);
            UISwapTypes[2].SetActive(false);
            timer = 11f;
        }

        if (imagination < startAmount)
        {
            imagination += .25f * Time.deltaTime;
        }

        imaginationBar.value = imagination;
    }

    public void goWalk()
    {
        Debug.Log("GoWalk Ran");
        if (Walking.activeInHierarchy != true && walkIsUnlocked && imagination - costOfWalk > 0)
        {
            timer = finishTimer;
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
    }

    public void goCar()
    {
        Debug.Log("GoCar Ran");
        if (Car.activeInHierarchy != true && carIsUnlocked && imagination - costOfCar > 0)
        {
            timer = finishTimer;
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
    }

    public void goPlane()
    {
        if (Plane.activeInHierarchy != true && planeIsUnlocked && imagination - costOfPlane > 0)
        {
            timer = finishTimer;
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
            PlayerPlane pp = Plane.GetComponent<PlayerPlane>();
            Walking.SetActive(false);
            Car.SetActive(false);
            Plane.SetActive(true);
            pp.m_speed = 0;
            pp.cameraTransform.rotation = new Quaternion(pp.cameraTransform.rotation.eulerAngles.x, pp.cameraTransform.rotation.eulerAngles.y, Plane.transform.rotation.eulerAngles.z, 90f);
        }
    }

    private void mouseOver()
    {
        if (Input.mousePosition.x > leftPlane && Input.mousePosition.x < rightPlane)
        {
            if (Input.mousePosition.y > bottomPlane && Input.mousePosition.y < topPlane)
            {
                goPlane();
            }
        }

        if (Input.mousePosition.x > leftCar && Input.mousePosition.x < rightCar)
        {
            if (Input.mousePosition.y > bottomCar && Input.mousePosition.y < topCar)
            {
                goCar();
            }
        }

        if (Input.mousePosition.x > leftWalk && Input.mousePosition.x < rightWalk)
        {
            if (Input.mousePosition.y > bottomWalk && Input.mousePosition.y < topWalk)
            {
                goWalk();
            }
        }
    }
}
