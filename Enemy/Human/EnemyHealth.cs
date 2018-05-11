using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 10;
    public int currentHealth;
    //[SerializeField]
    //private int pointValue;
    public bool isAlive = true;
    private NavMeshAgent NavM;
    public static int killCount;

    void Start () {
        currentHealth = maxHealth;
        isAlive = true;
        NavM = GetComponent<NavMeshAgent>();
}
	
	void Update () {
        if (currentHealth <= 0) {
            Die();
        }
	}

    void Die() {
        if (isAlive) {
            killCount += 1;
            EnemySight.isSpottedAudio = false;
            isAlive = false;
        }
        
        Destroy(gameObject, 2.4f);
        NavM.speed = 0;
        //Tel pointValue op bij playerPoints
    }
}
