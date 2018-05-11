using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour {

    [SerializeField]
    private int damage = 1;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {

            other.gameObject.GetComponent<EnemyHealth>().currentHealth = other.gameObject.GetComponent<EnemyHealth>().currentHealth - damage;
            //Manier om kleiner te maken!!
            Destroy(gameObject);

        }
    }
}
