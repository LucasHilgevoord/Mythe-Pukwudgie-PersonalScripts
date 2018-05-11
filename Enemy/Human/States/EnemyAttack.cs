using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

    private EnemyController _isAttacking;
    private NavMeshAgent NavM;
    private EnemyHealth _isAlive;
    private EnemyController _target;
    private int damage = 10;
    private bool isAttacking;

    void Start() {
        NavM = GetComponent<NavMeshAgent>();
        _isAlive = gameObject.GetComponent<EnemyHealth>();
        _isAttacking = gameObject.GetComponent<EnemyController>();
        _target = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update () {
        if (_isAttacking.isAttacking & _isAlive.isAlive) {
            NavM.speed = 0;
            if (!isAttacking) {
                StartCoroutine("Attack");
                StartCoroutine(_target.target.GetComponent<PlayerHealth>().Hit(10));
                isAttacking = true;
            }
            

        }
        
    }
    
    IEnumerator Attack() {
        yield return new WaitForSeconds(2f);
        Debug.Log("Test");
        StartCoroutine(_target.target.GetComponent<PlayerHealth>().Hit(10));
        isAttacking = false;
    }
}
