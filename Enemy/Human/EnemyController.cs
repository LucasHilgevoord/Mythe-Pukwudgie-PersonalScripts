using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [Header("State Settings")]
    public bool isIdleling;
    public bool isSearching;
    public bool isPatroling;
    public bool isWatching;
    public bool isHearing;
    public bool isChasing;
    public bool isAttacking;
    
    public GameObject target;

    [Header("Range Settings")]
    [SerializeField]
    private int searchRange = 30;
    [SerializeField]
    private int attackRange = 3;
    

    // Use this for initialization
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        Patrol();
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(target.transform.position, transform.position) < searchRange) {
            Watching();
            isWatching = true;
            isHearing = true;
        } else {
            isWatching = false;
            isHearing = false;
        }
    }

    public void Searching() {
        isSearching = true;
    }

    public void Patrol() {
        isPatroling = true;
    }

    void Watching() {
        isChasing = gameObject.GetComponent<EnemySight>().isSpotted;
        if (isChasing) {
            isPatroling = false;
            Chase();
        } else {
            isPatroling = true;
        }
    }

    void Chase() {
        if (Vector3.Distance(target.transform.position, transform.position) < attackRange) {
            Attack();
            isChasing = false;
        } else {
            isAttacking = false;
            isChasing = true;
        }
    }

    void Attack() {
        isAttacking = true;
        isChasing = false;
    }
}
