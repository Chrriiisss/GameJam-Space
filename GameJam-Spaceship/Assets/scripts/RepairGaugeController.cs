using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairGaugeController : MonoBehaviour
{
    
    public SpriteRenderer difficutly;
    public float speed;
    public SpriteRenderer needle;

    public List<Sprite> sprites;

    public List<Vector3> safeZones;


    public Sprite spr;
    public Vector3 safe;
    public float angle;

    public float moved = 0f;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0,3);
        spr = sprites[rand];
        safe = safeZones[rand];


        angle = Random.Range(-20f, -140f);

        difficutly.sprite = spr;
        difficutly.transform.Rotate(0f, 0f, angle);
    }


    void Update() {
        needle.transform.Rotate(0f,0f,-speed);
        moved += speed;

        if(moved > 260f)  {
            Destroy(gameObject);
        }
    }




}
