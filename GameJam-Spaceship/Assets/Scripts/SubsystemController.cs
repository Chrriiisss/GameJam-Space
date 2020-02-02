using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsystemController : MonoBehaviour {

    private List<ISubsystem> subsystems = new List<ISubsystem>();
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
        return this.subsystems;
    }
}
