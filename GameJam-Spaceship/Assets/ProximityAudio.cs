using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityAudio : MonoBehaviour
{
    public AudioClip soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource source = other.GetComponent<AudioSource>();
            source.clip = soundEffect;
            source.loop = true;
            source.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource source = other.GetComponent<AudioSource>();
            source.Stop();
        }
    }

}
