using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribble : MonoBehaviour
{
    public bool doDuplicate = true;
    public float respawnTime = 5f;
    private float duplicateCountdown;
    public Tribble tribblePrefab;

    public GameObject unstunnedIcon;
    public GameObject stunnedIcon;

    void Start()
    {
        duplicateCountdown = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(doDuplicate == true)
        {
            duplicateCountdown -= Time.deltaTime;
            if(duplicateCountdown <= 0f)
            {
                Duplicate();
                duplicateCountdown = respawnTime;
            }
            unstunnedIcon.SetActive(true);
            stunnedIcon.SetActive(false);
        }
        else
        {
            unstunnedIcon.SetActive(false);
            stunnedIcon.SetActive(true);
        }
    }

    public void Duplicate()
    {
        var tribble = Instantiate(tribblePrefab);
        Vector2 position = randomPoint(new Vector2(transform.position.x, transform.position.z), 0.2f);

        tribble.transform.position = new Vector3(position.x, transform.position.y, position.y);
    }

    public Vector2 randomPoint(Vector2 center,float radius)
    {
        var point = center + Random.insideUnitCircle * radius;
        return point;
    }
}
