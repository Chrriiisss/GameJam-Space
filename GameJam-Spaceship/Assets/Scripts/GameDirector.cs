using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    [SerializeField] private readonly float baseRNG = 0.1f;
    [SerializeField] private readonly float baseSpeed = 1f;
    [SerializeField] private float calculatedAsteroidChance;
    [SerializeField] private bool shieldsActive;
    [SerializeField] private float distanceToEnd;
    [SerializeField] private float speed;
    [SerializeField] private int shipHealth;
    private int shipHealthMax = 20;

    public AudioClip[] clips;


    public GameObject progressBar;
    public GameObject healthBar;


    private float timeToNextAsteroid = 2.0f;

    private float randomModifiers = 0f;

    private SubsystemController gameController;
    private CameraShake[] shakers;
    private AudioSource source;

    private void Start() {
        gameController = GameObject.Find("SubsystemController").GetComponent<SubsystemController>();
        shakers = GameObject.FindObjectsOfType<CameraShake>();
        source = GetComponent<AudioSource>();
        shieldsActive = true;
        distanceToEnd = 180f;
        speed = baseSpeed;
        shipHealth = shipHealthMax;
    }

    private void FixedUpdate()
    {
        timeToNextAsteroid = timeToNextAsteroid - Time.deltaTime;
    }

    private void Update()
    {
        if (timeToNextAsteroid < 0) {
            float asteroidDelayModifier = 0.5f / ((baseRNG + randomModifiers) * 1.7f);
            timeToNextAsteroid = Random.Range(5 + asteroidDelayModifier, 8 + asteroidDelayModifier);
            if (shieldsActive)
            {
                DamageRandomSubsystem();
                foreach (CameraShake shaker in shakers)
                {
                    shaker.ShakeCamera(3, 3);
                }
                source.clip = clips[Random.Range(0, clips.Length - 1)];
                source.Play();
            }
            else
            {
                DamageShip();
                foreach (CameraShake shaker in shakers)
                {
                    shaker.ShakeCamera(5, 5);
                }
                source.clip = clips[Random.Range(0, clips.Length - 1)];
                source.Play();
            }
        }
        if (distanceToEnd <= 0) {
            GameWin();
        }
        else {
            distanceToEnd -= speed * Time.deltaTime;
        }

        progressBar.GetComponent<ProgressController>().currentProgress = (180f - distanceToEnd) / 180f;

        healthBar.GetComponentInChildren<Text>().text = shipHealth + "";

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
        int damage = Random.Range(60, 100);
        int iteration = 0;
        foreach (ISubsystem subsystem in subsystems) {
            Debug.Log("Iteration: " + iteration);
            Debug.Log("Object: " + subsystem);
            if (choice == iteration && subsystem.GetHealth() > 0) {
                subsystem.TakeDamage(damage);
                WindowsVoice.speak("The " + subsystem.ToString() + " is at " + subsystem.GetPercentHealth() + "% health");
                return;
            }
            else {
                iteration++;
            }
        }
        //Damage first subsystem found with HP
        foreach (ISubsystem subsystem in subsystems)
        {
            if (subsystem.GetHealth() > 0)
            {
                subsystem.TakeDamage(damage);
                return;
            }
        }

        // If all subsystems
        DamageShip();
        WindowsVoice.speak("Hull strength is at " + GetShipHealthPercent() + "%");
    }

    private void DamageShip() {
        this.shipHealth -= 7;
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

    private int GetShipHealthPercent()
    {
        return shipHealth * 100 / shipHealthMax;
    }
}
