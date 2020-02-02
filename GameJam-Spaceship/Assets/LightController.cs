using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightController : MonoBehaviour
{

    private WirelessCharging charger;

    private float timeToNextPossibleOccurrence = 0;
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
        float health = charger.maxHealth - charger.componentHealth;
        if ( timeToNextPossibleOccurrence < 0 && health < 90)
        {
            float rand_val = Random.Range(0, 100);
            if (rand_val > health)
            {
                if (rand_val > 80)
                {
                    flickering = true;
                    timeToNextPossibleOccurrence = Random.Range(0.3f, 0.8f) + rand_val / 100;
                }
                else
                {
                    light.intensity = health / 100;
                    flickering = false;
                }
            }
            else
            {
                flickering = false;
                if (light.intensity < 2)
                {
                    light.intensity = 2;
                }
            }

            timeToNextPossibleOccurrence = Random.Range(1,6) * health / 10;
        }
        else if (health >= 90)
        {
            if (light.intensity < 2.0f)
            {
                light.intensity = 2.0f;
            }
        }
        else if(flickering)
        {
            Debug.Log("IT'S FLICKERING");
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
