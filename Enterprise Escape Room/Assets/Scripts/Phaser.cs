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
    public Transform hitTribble;
    private AudioSource audioSource;

    RaycastHit hit;

    void Start()
    {
        activated.AddListener(FirePhaser);
        audioSource = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
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
        

        if(Physics.Raycast(startPoint.position,transform.forward,out hit))
        {
            line.SetPosition(0, startPoint.position);
            line.SetPosition(1, hit.point);
            line.enabled = true;
            if (hit.transform.CompareTag("Tribble"))
            {
                Tribble tribble = hit.transform.GetComponent<Tribble>();
                tribble.doDuplicate = false;
            }
            return true;
        }
        else
        {
            line.enabled = false;
            return false;
        }
    }

}
