using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int shipHealth; // Health of the ship, reaching 0 means game over.
    private List<ISubsystem> subsystems = new List<ISubsystem>();
    // Start is called before the first frame update
    void Start() {
        this.shipHealth = 100;
        subsystems.Add(GameObject.Find("WirelessCharging").GetComponent<WirelessCharging>());
        subsystems.Add(GameObject.Find("ShieldGenerator").GetComponent<ShieldGenerator>());
        subsystems.Add(GameObject.Find("OxygenGenerator").GetComponent<OxygenGenerator>());
        subsystems.Add(GameObject.Find("Navigation").GetComponent<Navigation>());
        subsystems.Add(GameObject.Find("Engines").GetComponent<Engines>());
        //  subsystems.Add(GameObject.Find("ShipComputer").GetComponent<WirelessCharging>()); !!Potential extension!!
    }

    int GetShipHealth() {
        return this.shipHealth;
    }

    List<ISubsystem> GetSubsystems() {
        return this.subsystems;
    }
}
