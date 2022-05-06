using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    public Transform followTransform;
    public float turnSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetDirection = followTransform.forward;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        
        //turns vector 3 back into a quaternion for rotation
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
