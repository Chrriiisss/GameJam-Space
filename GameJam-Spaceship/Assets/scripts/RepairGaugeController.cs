using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairGaugeController : MonoBehaviour
{
    
    public SpriteRenderer ren;

    public List<Sprite> sprites;


    // Start is called before the first frame update
    void Start()
    {
        ren.sprite = sprites[Random.Range(0,3)];
        ren.transform.Rotate(0f, 0f, Random.Range(-20f, -140f));
    }

}
