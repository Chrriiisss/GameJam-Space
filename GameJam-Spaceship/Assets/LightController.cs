using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private WirelessCharging charger;

    public float timeToNextPossibleOccurrence = 0;
    private Light light;
    private bool flickering = false;
    private float flickerTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        charger = FindObjectOfType<WirelessCharging>();
        light = gameObject.GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        flickerTimer -= Time.deltaTime;
        timeToNextPossibleOccurrence -= Time.deltaTime;
        float health = charger.GetPercentHealth();
        if ( timeToNextPossibleOccurrence < 0 && health < 90)
        {
            float rand_val = Random.Range(0, 100);
            if (rand_val > health + 20)
            {
                if (rand_val > 90 + health / 50)
                {
                    flickering = true;
                    timeToNextPossibleOccurrence = Random.Range(1.0f, 1.7f) + ((rand_val / 100) - health);
                }
                else
                {
                    light.intensity = health / 80 + 0.1f;
                    flickering = false;
                    timeToNextPossibleOccurrence = Random.Range(1, 6) + health / 10;
                }
            }
            else
            {
                flickering = false;
                if (light.intensity < 2)
                {
                    light.intensity = 2;
                }
                timeToNextPossibleOccurrence = Random.Range(2, 7)  + health / 10;
            }
        }
        else if (health >= 90)
        {
            flickering = false;
            if (light.intensity < 2.0f)
            {
                light.intensity = 2.0f;
            }
            timeToNextPossibleOccurrence = Random.Range(2, 7) + health / 10;
        }
        else if(flickering)
        {
            //Debug.Log("FLICKERING");
            if (flickerTimer < 0)
            {
                if (light.intensity > 0)
                {
                    light.intensity = 0;
                }
                else
                {
                    light.intensity = Random.Range(0.5f, 2.0f);
                }

                flickerTimer = Random.Range(0.05f, 0.15f);
            }
        }
    }
}
