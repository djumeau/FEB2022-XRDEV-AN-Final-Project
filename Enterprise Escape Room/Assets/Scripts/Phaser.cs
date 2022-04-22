using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Phaser : XRGrabInteractable
{
    private LineRenderer line;
    public Transform startPoint;
    public AudioClip phaserSound;

    private AudioSource audioSource;

    void Start()
    {
        activated.AddListener(FirePhaser);
        audioSource = GetComponent<AudioSource>();
    }

    private void FirePhaser(ActivateEventArgs args)
    {
        // play phaser sound
        audioSource.PlayOneShot(phaserSound);

        // fire phaser
        GetRaycastHit();
    }

    public bool GetRaycastHit()
    {
        RaycastHit hit;

        if(Physics.Raycast(startPoint.position,transform.forward,out hit))
        {
            line.SetPosition(0, startPoint.position);
            line.SetPosition(1, hit.point);
            line.enabled = true;
            return true;
        }
        else
        {
            line.enabled = false;
            return false;
        }
    }

}
