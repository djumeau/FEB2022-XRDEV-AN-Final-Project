using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform followTransform;
    public float offset;

    public Transform groundTranform;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = new Vector3(followTransform.position.x, groundTranform.position.y + offset, followTransform.position.z);

        //transform means this.transform of the object this script is attached to
        transform.position = followPosition;
    }
}
