using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCapsule : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;
        }
        //else if (other.CompareTag("B"))
        //{
        //
        //}
        //else if (other.CompareTag("C"))
        //{
        //
        //}
        //else
        //{
        //
        //}
    }
}
