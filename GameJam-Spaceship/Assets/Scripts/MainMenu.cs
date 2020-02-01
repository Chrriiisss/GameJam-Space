using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if (SceneManager.GetActiveScene().name == "GameWin") {
                SceneManager.LoadScene("MainMenu");
            }
            else {
                SceneManager.LoadScene("TheGame");
            }            
        }        
    }
}
