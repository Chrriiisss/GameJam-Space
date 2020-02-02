using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;

    public int clip_ref = 0;
    public int loopsLeft = 2;
    public int min = 1;
    public int max = 3;

    private AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[clip_ref];
        source.loop = false;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (loopsLeft > 0)
            {
                source.Play();
                loopsLeft -= 1;
            }
            else
            {
                clip_ref += 1;
                if (clip_ref >= clips.Length)
                {
                    clip_ref = 0;
                }
                loopsLeft = Random.Range(min, max);
                source.clip = clips[clip_ref];
                source.Play();
            }
        }
    }
}
