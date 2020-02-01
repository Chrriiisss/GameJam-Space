using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {

    [SerializeField] private readonly float baseRNG = 0.1f;
    [SerializeField] private readonly float baseSpeed = 1f;
    private float modifiers = 0f;
    [SerializeField] private bool shieldsActive;
    [SerializeField] private float distanceToEnd;
    [SerializeField] private float speed;

    private void Start() {
        shieldsActive = true;
        distanceToEnd = 1000f;
        speed = baseSpeed;
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

    public void SetSpeed(int speed) {
        if (speed == 0) {
            this.speed = baseSpeed;
        }
        else {
            this.speed = baseSpeed / speed;
        }
    }

}
