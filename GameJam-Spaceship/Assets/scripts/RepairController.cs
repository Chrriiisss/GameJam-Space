using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    public float detectDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

         if(Physics.Raycast(transform.position, transform.forward, out hit, detectDistance)     &&
                     hit.collider.gameObject.CompareTag("Repairable")) {
 
             

             

         }
    }
}
