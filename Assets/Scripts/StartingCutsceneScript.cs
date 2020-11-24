using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartingCutsceneScript : MonoBehaviour
{
    [SerializeField] Rigidbody planeRB = null;
    [SerializeField] SwappingBehavior sb = null;
    [SerializeField] PlayerWalk walking = null;
    [SerializeField] PlayerCar car = null;
    [SerializeField] PlayerPlane plane = null;
    [SerializeField] Camera[] cameras = null;

    void Update()
    {
        if(planeRB != null && GetComponent<PlayableDirector>().time == 0)
        {
            sb.enabled = true;
            planeRB.isKinematic = false;
            walking.enabled = true;
            car.enabled = true;
            plane.enabled = true;
            cameras[0].enabled = true;
            cameras[1].enabled = true;
            cameras[2].enabled = true;
            cameras[3].enabled = false;
        }
        else
        {
            sb.enabled = false;
            planeRB.isKinematic = true;
            walking.enabled = false;
            car.enabled = false;
            plane.enabled = false;
            cameras[0].enabled = false;
            cameras[1].enabled = false;
            cameras[2].enabled = false;
            cameras[3].enabled = true;
        }
    }
}
