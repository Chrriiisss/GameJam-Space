using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if (SceneManager.GetActiveScene().name == "GameWin")
            {
                source.Play();
                float delayTime = 1.0f;
                float timer = 0.0f;
                while (timer < delayTime)
                {
                    timer += Time.deltaTime;
                }
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                source.loop = false;
                source.Play();
                float delayTime = 1.0f;
                float timer = 0.0f;
                while (timer < delayTime)
                {
                    timer += Time.deltaTime;
                }
                SceneManager.LoadScene("TheGame");
            }            
        }        
    }
}
