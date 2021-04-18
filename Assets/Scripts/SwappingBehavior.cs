using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwappingBehavior : MonoBehaviour
{
    [SerializeField] Camera[] cameras = null;
    [SerializeField] float finishTimer = 2.5f;
    [SerializeField] GameObject Walking = null;
    [SerializeField] GameObject Car = null;
    [SerializeField] GameObject Plane = null;
    [SerializeField] GameObject panel = null;
    [SerializeField] GameObject[] UISwapTypes = null;
    [SerializeField] Slider imaginationBar = null;
    [SerializeField] Slider energyBar = null;
    [SerializeField] ParticleSystem[] smoke = null;
    [SerializeField] Canvas energyWarning;
    [SerializeField] string gameover;
    [SerializeField] float energyMK2 = 0;

    public static float imagination = 100;
    public static float energy = 100;
    private static int vehicle = 0;

    private bool walkIsUnlocked;
    private bool carIsUnlocked;
    private bool planeIsUnlocked;
    private bool energyActive = true;

    private float timer = 16f;
    private float maxImagination;
    private float maxEnergy;

    private int costOfWalk;
    private int costOfCar;
    private int costOfPlane;

    private void Start()
    {
        maxImagination = imagination;
        maxEnergy = energy;
        costOfWalk = Walking.GetComponent<PlayerWalk>().cost;
        costOfCar = Car.GetComponent<PlayerCar>().cost;
        costOfPlane = Plane.GetComponent<PlayerPlane>().cost;

        walkIsUnlocked = Walking.GetComponent<PlayerWalk>().Unlocked;
        carIsUnlocked = Car.GetComponent<PlayerCar>().Unlocked;
        planeIsUnlocked = Plane.GetComponent<PlayerPlane>().Unlocked;

        if (walkIsUnlocked && vehicle == 0)
        {
            goWalk();
        }
        else if (carIsUnlocked && vehicle == 1)
        {
            goCar();
        }
        else if (planeIsUnlocked && vehicle == 2)
        {
            goPlane();
        }

        imagination = maxImagination;
    }

    void Update()
    {
        energyMK2 = energy;
        walkIsUnlocked = Walking.GetComponent<PlayerWalk>().Unlocked;
        carIsUnlocked = Car.GetComponent<PlayerCar>().Unlocked;
        planeIsUnlocked = Plane.GetComponent<PlayerPlane>().Unlocked;

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (Plane.activeInHierarchy) Plane.transform.eulerAngles = new Vector3(-90, Plane.transform.eulerAngles.y, Plane.transform.eulerAngles.z);
            if (Car.activeInHierarchy) Car.transform.eulerAngles = new Vector3(-90, Car.transform.eulerAngles.y, Car.transform.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            energyActive = !energyActive;
            energy = 100;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            imagination = 100;
        }

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
        }

        
        if (timer >= finishTimer && timer < 10f)
        {
            UISwapTypes[0].SetActive(false);
            UISwapTypes[1].SetActive(false);
            UISwapTypes[2].SetActive(false);
            timer = 11f;
        }

        if (imagination < maxImagination)
        {
            imagination += .25f * Time.deltaTime;
        }
        if (energy > -1 && energyActive)
        {
            if (Walking.activeInHierarchy && energy < maxEnergy)
            {
                energy -= (Walking.GetComponent<PlayerWalk>().energyUsage / 10) * Time.deltaTime;
            }
            else if (Car.activeInHierarchy)
            {
                energy -= (Car.GetComponent<PlayerCar>().energyUsage / 10) * Time.deltaTime;
            }
            else if (Plane.activeInHierarchy)
            {
                energy -= (Plane.GetComponent<PlayerPlane>().energyUsage / 10) * Time.deltaTime;
            }
        }

        if (energy <= 25 && Walking.activeInHierarchy != true)
        {
            energyWarning.enabled = true;
        }
        else
        {
            energyWarning.enabled = false;
        }

        if (energy <= 0)
        {
            SceneManager.LoadScene(gameover);
        }

        imaginationBar.value = imagination;
        energyBar.value = energy;
    }

    public void goWalk()
    {
        PlayerWalk walk = Walking.GetComponent<PlayerWalk>();
        if (Walking.activeInHierarchy != true && walkIsUnlocked && imagination - costOfWalk > 0)
        {
            vehicle = 0;
            panel.SetActive(false);
            smoke[0].Play();
            timer = finishTimer;
            imagination -= costOfWalk;
            cameras[0].Render();
            if (Car.activeInHierarchy == true)
            {
                Walking.transform.position = new Vector3(Car.transform.position.x, Car.transform.position.y + 2.54f, Car.transform.position.z);

                walk.touchingFloor = false;
                Vector3 eulerRotation = new Vector3(Walking.transform.eulerAngles.x, Car.transform.eulerAngles.y, Walking.transform.eulerAngles.z);
                Walking.transform.rotation = Quaternion.Euler(eulerRotation);
            }
            if (Plane.activeInHierarchy == true)
            {
                Walking.transform.position = new Vector3(Plane.transform.position.x, Plane.transform.position.y + 2.54f, Plane.transform.position.z);

                walk.touchingFloor = false;
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
        if (Car.activeInHierarchy != true && carIsUnlocked && imagination - costOfCar > 0)
        {
            vehicle = 1;
            panel.SetActive(true);
            smoke[1].Play();
            timer = finishTimer;
            imagination -= costOfCar;
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
            vehicle = 2;
            panel.SetActive(false);
            smoke[2].Play();
            timer = finishTimer;
            imagination -= costOfPlane;
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
    
    public static void ResetSliders()
    {
        imagination = 100;
        energy = 100;
    }

}
