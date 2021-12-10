using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);


        Quaternion targetOrientationQuaternion = targetOrientationQuaternion.LookRotation(targetOrientation);
        transform.rotation = targetOrientationQuaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}
