using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    private Camera cam;

    public Canvas canvas;

    public GameObject healthBarPre;

    public bool showing = false;
    
    
    public float detectDistance = 100f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width/2f, Screen.height/2f, cam.nearClipPlane));
        
        RaycastHit hit;

         if(Physics.Raycast(CameraCenter, cam.transform.forward, out hit, detectDistance)     &&
                     hit.collider.gameObject.CompareTag("Repairable")) {
 
                    if(!showing) {
                        GameObject healthBar = Instantiate(healthBarPre, new Vector3(0,0,0), Quaternion.identity, canvas.transform);
                        healthBar.transform.position = new Vector3(0,0,0);
                        
                    }
                    showing = true;
                    
            }

             

         
    }
}
