﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    [SerializeField] private readonly float baseRNG = 0.1f;
    [SerializeField] private readonly float baseSpeed = 1f;
    [SerializeField] private float calculatedAsteroidChance;
    [SerializeField] private bool shieldsActive;
    [SerializeField] private float distanceToEnd;
    [SerializeField] private float speed;
    [SerializeField] private int shipHealth = 20;
    
    private float timeToNextAsteroid = 0.0f;

    private float randomModifiers = 0f;

    private SubsystemController gameController;
    private CameraShake shaker;

    private void Start() {
        gameController = GameObject.Find("SubsystemController").GetComponent<SubsystemController>();
        shaker = GameObject.Find("PlayerCamera").GetComponent<CameraShake>();
        shaker.ShakeCamera(7,10);
        shieldsActive = true;
        distanceToEnd = 180f;
        speed = baseSpeed;
    }

    private void FixedUpdate()
    {
        timeToNextAsteroid = timeToNextAsteroid - Time.deltaTime;
    }

    private void Update()
    {
        if (timeToNextAsteroid < 0) {
            float asteroidDelayModifier = 1.0f / (baseRNG + randomModifiers);
            timeToNextAsteroid = Random.Range(5 + asteroidDelayModifier, 8 + asteroidDelayModifier);
            if (shieldsActive)
            {
                DamageRandomSubsystem();
                shaker.ShakeCamera(3, 3);
            }
            else
            {
                DamageShip();
                shaker.ShakeCamera(5, 5);
            }
        }
        if (distanceToEnd <= 0) {
            GameWin();
        }
        else {
            distanceToEnd -= speed * Time.deltaTime;
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
        int choice = Random.Range(0, subsystems.Count - 1);
        Debug.Log("Choice: " + choice);
        Debug.Log("Count: " + subsystems.Count);
        int damage = Random.Range(10, 100);
        int iteration = 0;
        foreach (ISubsystem subsystem in subsystems) {
            Debug.Log("Iteration: " + iteration);
            if (choice == iteration && subsystem.GetHealth() > 0) {
                subsystem.TakeDamage(damage);
                return;
            }
            else {
                iteration++;
            }
        }
        // Damage first subsystem found with HP
        foreach (ISubsystem subsystem in subsystems) {
            if (subsystem.GetHealth() > 0) {
                subsystem.TakeDamage(damage);
                return;
            }
        }

        // If all subsystems
        DamageShip();
    }

    private void DamageShip() {
        this.shipHealth--;
        if (shipHealth <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    private void GameWin() {
        SceneManager.LoadScene("GameWin");
    }
}
