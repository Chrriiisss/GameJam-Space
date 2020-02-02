using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    public Camera cam;


    public GameObject cogs;
    
    public float center;
    
    public float detectDistance = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3( center* Screen.width/4f, Screen.height/2f, cam.nearClipPlane));
        Debug.DrawRay(CameraCenter, cam.transform.forward, Color.red, detectDistance);
        RaycastHit hit;
        if(Physics.Raycast(CameraCenter, cam.transform.forward, out hit, detectDistance)) {
             Debug.Log(hit.collider.gameObject.tag);
             if((hit.collider.gameObject.CompareTag("Machine") || hit.collider.transform.GetChild(0).CompareTag("Machine")) && Vector3.Distance(transform.position, hit.transform.position) < 2f) {
                 cogs.SetActive(true);
                   Debug.Log(hit.transform.name);

                   Debug.Log(hit.transform.GetComponentInParent<ISubsystem>().GetHealth());

                    if(Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button0)) {
                        Debug.Log("Click");
                        hit.transform.GetComponentInParent<ISubsystem>().Repair();
                    }
             }
        }else {
                cogs.SetActive(false);
            }

             

         
    }



}
