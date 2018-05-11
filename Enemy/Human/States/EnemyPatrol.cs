using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour {

    private NavMeshAgent NavM;
    private float patrolSpeed = 3.5f;
    [SerializeField]
    private GameObject[] waypoints;
    private int waypointInd;
    private EnemyController _isPatroling;
    private EnemyHealth _isAlive;
    private EnemyHearing _isDetecting;
    private EnemyController _isSearching;

    // Use this for initialization
    void Start() {
        NavM = GetComponent<NavMeshAgent>();
        _isAlive = gameObject.GetComponent<EnemyHealth>();
        _isPatroling = gameObject.GetComponent<EnemyController>();
        _isSearching = gameObject.GetComponent<EnemyController>();
        _isDetecting = gameObject.GetComponent<EnemyHearing>();
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        waypointInd = Random.Range(0, waypoints.Length);

    }

    void Update() {
        

        if (_isPatroling.isPatroling & _isAlive.isAlive & !_isDetecting.heardSomething & !_isSearching.isSearching) {
            if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) >= 2) {
                NavM.SetDestination(waypoints[waypointInd].transform.position);
                NavM.speed = patrolSpeed;
            } else if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) <= 1) {
                waypointInd = Random.Range(0, waypoints.Length);

            }
        } 

    }
}
