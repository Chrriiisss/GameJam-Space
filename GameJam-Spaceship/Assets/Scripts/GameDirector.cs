using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {

    [SerializeField] private readonly float baseRNG = 0.1f;
    private float modifiers = 0f;
    [SerializeField] private bool shieldsActive;

    private void Start() {
        shieldsActive = true;
    }

    private void Update() {
        // Do Random Damage checks
    }

    public void ModifyRNG(float amount) {
        modifiers += amount;
    }

    private float GetRNG() {
        return baseRNG + modifiers;
    }

    public void SetShields(bool state) {
        shieldsActive = state;
    }

    

}
