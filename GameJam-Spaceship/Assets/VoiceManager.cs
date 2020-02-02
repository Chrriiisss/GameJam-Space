using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public AudioClip[] clips;

    public float timeToNextClip = 0.0f;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextClip -= Time.deltaTime;
        if (timeToNextClip < 0)
        {
            timeToNextClip = Random.Range(20, 30);
            int nextClip = Random.Range(0, clips.Length - 1);
            source.clip = clips[nextClip];
            source.Play();
        }
    }
}
