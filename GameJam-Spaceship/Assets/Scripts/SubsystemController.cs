using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsystemController : MonoBehaviour {

    private List<ISubsystem> subsystems = new List<ISubsystem>();

    public List<Text> values;

    // Start is called before the first frame update
    void Start() {
        this.subsystems.Add(GameObject.Find("Wireless Charging").GetComponent<WirelessCharging>());
        this.subsystems.Add(GameObject.Find("Shield Generator").GetComponent<ShieldGenerator>());
        this.subsystems.Add(GameObject.Find("OxygenGenerator").GetComponent<OxygenGenerator>());
        this.subsystems.Add(GameObject.Find("Computer Terminal").GetComponent<Navigation>());
        this.subsystems.Add(GameObject.Find("Engines").GetComponent<Engines>());
        this.subsystems.Add(GameObject.Find("Ship Computer").GetComponent<ShipComputer>());
    }

    public List<ISubsystem> GetSubsystems() {
        Debug.Log("Found " + subsystems.Count + " Subsystems");
        return this.subsystems;
    }


    void FixedUpdate() {
        for(int i = 0; i < 6; i++) {
            values[i].text = subsystems[i].GetHealth() + "";
            Debug.Log(subsystems[i].GetType() + " " + subsystems[i].GetHealth());
        }
    }
}
