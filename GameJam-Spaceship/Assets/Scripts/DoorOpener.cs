using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    protected int numNear = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            numNear += 1;
        }
        setDoorState();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            numNear -= 1;
            if (numNear < 0)
            {
                numNear = 0;
            }
            setDoorState();
        }
    }

    private void setDoorState()
    {
        if (numNear > 0)
        {
            transform.Find("Door1").gameObject.GetComponent<Animator>().SetInteger("Open", 1);
            transform.Find("Door2").gameObject.GetComponent<Animator>().SetInteger("Open", 1);
        }
        else if (numNear <= 0)
        {
            transform.Find("Door1").gameObject.GetComponent<Animator>().SetInteger("Open", 0);
            transform.Find("Door2").gameObject.GetComponent<Animator>().SetInteger("Open", 0);
            numNear = 0;
        }
    }
}
