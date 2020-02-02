using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WirelessCharging : MonoBehaviour, ISubsystem {

    private GameDirector gameDirector;
    [SerializeField] private float componentHealth;
    private readonly float maxHealth = 100;
    public GameObject visionBlackout;

    // Start is called before the first frame update
    void Start() {
        this.componentHealth = maxHealth;
        this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    public int GetHealth() {
        return (int) this.componentHealth;
    }

    public void TakeDamage(int damageAmount) {
        this.componentHealth = Mathf.Max(0, this.componentHealth - damageAmount);
        ActivateEffect();
    }

    public void Repair() {
        this.componentHealth = maxHealth;
        ActivateEffect();
    }

    private void ActivateEffect() {
        float size = (maxHealth - componentHealth) / 100f;
        this.visionBlackout.GetComponent<RectTransform>().sizeDelta = new Vector2(1750f * size, 1750f * size);
    }
}
