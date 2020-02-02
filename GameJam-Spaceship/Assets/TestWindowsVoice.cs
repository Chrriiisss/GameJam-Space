using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWindowsVoice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WindowsVoice.speak("The generator is running at 50%");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
