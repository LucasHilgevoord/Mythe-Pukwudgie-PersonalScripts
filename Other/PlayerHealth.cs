using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 50;
    public int currentHealth;
    public bool isAlive = true;
    public static int killCount;
    [SerializeField]
    Slider healthSlider;

    void Start() {
        currentHealth = maxHealth;
        isAlive = true;
        healthSlider.value = currentHealth;
    }

    void Update() {
        //healthSlider.value = currentHealth;
        if (currentHealth <= 0) {
            Die();
        }
    }

    public IEnumerator Hit(int damage) {
        for (int i = 0; i < damage; i++) {
            yield return new WaitForSeconds(0.1f);
            currentHealth -= 1;
            healthSlider.value = currentHealth;
        }
    }


    void Die() {
        if (isAlive) {
            killCount += 1;
            EnemySight.isSpottedAudio = false;
            isAlive = false;
            Application.LoadLevel(Application.loadedLevel);            
        }
        
        //Tel pointValue op bij playerPoints
    }
}
