using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHearing : MonoBehaviour {

    public bool heardSomething = false;
    public Vector3 lastDetectionPos;
    private EnemyController _isHearing;
    private EnemySight _isSpotted;
    private bool markCreate;
    private EnemyController _target;

    private NavMeshAgent NavM;
    [SerializeField]
    private GameObject questionMark;

    // Use this for initialization
    void Start () {
        NavM = GetComponent<NavMeshAgent>();
        _isHearing = gameObject.GetComponent<EnemyController>();
        _isSpotted = gameObject.GetComponent<EnemySight>();
        _target = gameObject.GetComponent<EnemyController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (heardSomething && _isHearing.isHearing && !_isSpotted.isSpotted) {
            if (!markCreate) {
                //GameObject newItem = Instantiate(questionMark, transform.position + transform.up * 2f, Quaternion.Euler(-90, 0, 0), transform) as GameObject;
                Instantiate(questionMark, transform.position + transform.up * 2f, Quaternion.identity, transform);
                markCreate = true;
            }
            NavM.SetDestination(lastDetectionPos);
            if (Vector3.Distance(transform.position, lastDetectionPos) <= 4) {
                gameObject.GetComponent<EnemyController>().Searching();
                heardSomething = false;
            }
            if (_isSpotted.isSpotted) {
                heardSomething = false;
            }

            } else {
            if (markCreate) {
                Destroy(gameObject.transform.Find("questionMark(Clone)").gameObject);
                markCreate = false;
            }
        }
    }

}
