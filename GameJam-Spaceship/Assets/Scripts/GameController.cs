using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int shipHealth; // Health of the ship, reaching 0 means game over.
    private List<ISubsystem> subsystems = new List<ISubsystem>();
    // Start is called before the first frame update
    void Start() {
        this.shipHealth = 100;
    }

    int GetShipHealth() {
        return this.shipHealth;
    }

    List<ISubsystem> GetSubsystems() {
        return this.subsystems;
    }
}
