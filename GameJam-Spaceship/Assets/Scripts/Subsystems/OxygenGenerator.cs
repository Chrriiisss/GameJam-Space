﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenGenerator : MonoBehaviour, ISubsystem {

    private GameDirector gameDirector;
    [SerializeField] private int componentHealth;
    private readonly int maxHealth = 100;

    // Start is called before the first frame update
    void Start() {
        this.componentHealth = maxHealth;
        this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public int GetHealth() {
        return this.componentHealth;
    }

    public void TakeDamage(int damageAmount) {
        this.componentHealth = Mathf.Max(0, this.componentHealth - damageAmount);
        if (componentHealth == 0) {
            ActivateEffect();
        }
    }

    public void Repair() {
        this.componentHealth = maxHealth;
        ActivateEffect();
        if (GetPercentHealth() == 100)
        {
            WindowsVoice.speak("The " + ToString() + " has been repaired");
        }
    }

    private void ActivateEffect() {
        gameDirector.ModifyRNG(((float)maxHealth - componentHealth) / 200);
    }

    public override string ToString()
    {
        return "Oxygen Generator";
    }

    public int GetPercentHealth()
    {
        return componentHealth * 100 / maxHealth;
    }

    public string GetDescription()
    {
        return "Improves pilot's avoidance skillss";
    }
}
