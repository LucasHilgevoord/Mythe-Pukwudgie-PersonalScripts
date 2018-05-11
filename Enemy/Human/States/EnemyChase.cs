using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour {

    private float chaseSpeed = 4f;
    private EnemyController _target;
    private EnemyController _isChasing;
    private NavMeshAgent NavM;
    private EnemyHealth _isAlive;
    

    void Start() {
        NavM = GetComponent<NavMeshAgent>();
        _isChasing = gameObject.GetComponent<EnemyController>();
        _isAlive = gameObject.GetComponent<EnemyHealth>();
        _target = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update () {
        if (_isChasing.isChasing & _isAlive.isAlive) {
            var targetRotation = Quaternion.LookRotation(_target.target.transform.position - transform.position);
            targetRotation.x = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
            NavM.SetDestination(_target.target.transform.position);
            NavM.speed = chaseSpeed;
            
        } 
    }
}


