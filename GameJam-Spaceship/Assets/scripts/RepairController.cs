using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    private Camera cam;


    public GameObject cogs;
    
    
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
        Debug.DrawRay(CameraCenter, cam.transform.forward, Color.green, detectDistance);
        RaycastHit hit;

         if(Physics.Raycast(CameraCenter, cam.transform.forward, out hit, detectDistance)     &&
                     hit.collider.gameObject.CompareTag("Repairable")) {
 
                   cogs.SetActive(true);
                   Debug.Log(hit.transform.name);

                   Debug.Log(hit.transform.GetComponentInParent<ISubsystem>().GetHealth());

                    if(Input.GetKeyUp(KeyCode.E)){
                        Debug.Log("Click");
                        hit.transform.GetComponentInParent<ISubsystem>().Repair();
                    }
                   
                    
            } else {
                cogs.SetActive(false);
            }

             

         
    }



}
