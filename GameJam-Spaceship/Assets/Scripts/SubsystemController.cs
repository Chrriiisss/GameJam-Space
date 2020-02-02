using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsystemController : MonoBehaviour {

    public List<GameObject> subsystems;

    public List<Text> values;

    // Start is called before the first frame update
    void Awake() {
        /*this.subsystems.Add(GameObject.Find("Wireless Charging").GetComponent<WirelessCharging>());
        this.subsystems.Add(GameObject.Find("Shield Generator").GetComponent<ShieldGenerator>());
        this.subsystems.Add(GameObject.Find("OxygenGenerator").GetComponent<OxygenGenerator>());
        this.subsystems.Add(GameObject.Find("Computer Terminal").GetComponent<Navigation>());
        this.subsystems.Add(GameObject.Find("Engines").GetComponent<Engines>());
        this.subsystems.Add(GameObject.Find("Ship Computer").GetComponent<ShipComputer>());*/

        //Debug.Log("I Hate Everything");
    }

    public List<ISubsystem> GetSubsystems() {
        Debug.Log("Found " + subsystems.Count + " Subsystems");

        List<ISubsystem> tmp = new List<ISubsystem>();

        foreach(GameObject sys in subsystems) {
            tmp.Add(sys.GetComponent<ISubsystem>());
        }


        return tmp;
    }


    void FixedUpdate() {
        for(int i = 0; i < 6; i++) {
            values[i].text = subsystems[i].GetComponent<ISubsystem>().GetHealth() + "";
            //Debug.Log(subsystems[i].GetType() + " " + subsystems[i].GetHealth());
        }


        foreach(GameObject sys in subsystems) {
           // Debug.Log(sys.name);
        }
    }

}
