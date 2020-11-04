using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] float rotateSpeed = 5;
    
    private Vector3 offset;
    private GameObject target;

    private void Start()
    {
        target = targets[2];
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //for(int i = 0; i < targets.Length; i++) if (targets[i].activeInHierarchy) target = targets[i];
        //if(offset != target.transform.position - transform.position) offset = target.transform.position - transform.position;
        
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
