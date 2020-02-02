using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{

    public RectTransform bar;
    public float health = 1f;



    void FixedUpdate() {
        bar.sizeDelta = new Vector2(health, bar.sizeDelta.y);
        bar.transform.localPosition = new Vector2((health - 300)/2f, bar.transform.localPosition.y);

        
    }

    

}
