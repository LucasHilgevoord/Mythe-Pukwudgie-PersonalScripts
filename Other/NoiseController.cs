using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour {

    [SerializeField]
    private int soundRadius;
    private bool activateSound;
    public Vector3 soundPos;
    private EnemyHearing enemyHearingScript;

    void Update() {
        if (activateSound) {
            soundPos = transform.position;
            //soundPos.y = 1.5f;

            Collider[] colliders = Physics.OverlapSphere(soundPos, soundRadius);
            foreach (Collider hit in colliders) {
                enemyHearingScript = hit.gameObject.GetComponent<EnemyHearing>();
                if (enemyHearingScript != null) {
                    enemyHearingScript.heardSomething = true;
                    enemyHearingScript.lastDetectionPos = soundPos;
                }
            }
        }
    }

    void OnCollisionEnter(Collision other) {
        activateSound = true;
        Destroy(gameObject, 2f);
    }

    void OnDrawGizmos() {
        if (activateSound) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, soundRadius);
        }  
    }
}