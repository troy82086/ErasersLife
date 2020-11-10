using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartingCutsceneScript : MonoBehaviour
{
    [SerializeField] Rigidbody planeRB = null;
    [SerializeField] PlayerWalk walking = null;
    [SerializeField] PlayerCar car = null;
    [SerializeField] PlayerPlane plane = null;

    void Update()
    {
        if(planeRB != null && GetComponent<PlayableDirector>().time == 0)
        {
            planeRB.isKinematic = false;
            walking.enabled = true;
            car.enabled = true;
            plane.enabled = true;
        }
        else
        {
            planeRB.isKinematic = true;
            walking.enabled = false;
            car.enabled = false;
            plane.enabled = false;
        }
    }
}
