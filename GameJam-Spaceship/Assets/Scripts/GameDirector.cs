using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {

    [SerializeField] private readonly float baseRNG = 0.1f;
    [SerializeField] private readonly float baseSpeed = 1f;
    [SerializeField] private float calculatedAsteroidChance;
    [SerializeField] private bool shieldsActive;
    [SerializeField] private float distanceToEnd;
    [SerializeField] private float speed;

    private readonly float minTimeBetweenAsteroids = 5f;
    private float timeSinceLastAsteroid = 0f;
    private float randomModifiers = 0f;

    private GameController gameController;

    private void Start() {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        shieldsActive = true;
        distanceToEnd = 1000f;
        speed = baseSpeed;
    }
    
    private void Update() {
        if (timeSinceLastAsteroid > minTimeBetweenAsteroids) {
            calculatedAsteroidChance = baseRNG + randomModifiers;
            if (Random.Range(0f, 1f) < calculatedAsteroidChance) {
                timeSinceLastAsteroid = 0f;
                DamageRandomSubsystem();
            }
        }
    }

    public void ModifyRNG(float amount) {
        randomModifiers += amount;
    }

    private float GetRNG() {
        return baseRNG + randomModifiers;
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

    private void DamageRandomSubsystem() {
        List<ISubsystem> subsystems = gameController.GetSubsystems();
        int choice = Random.Range(0, subsystems.Count);
        int damage = Random.Range(10, 100);
        int iteration = 0;
        foreach (ISubsystem subsystem in subsystems) {
            if (choice == iteration) {
                subsystem.TakeDamage(damage);
                return;
            }
            else {
                iteration++;
            }
        }
    }
}
