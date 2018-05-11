using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    public Animator anim;
    private EnemyController _isIdleling;
    private EnemyController _isPatroling;
    private EnemyController _isChasing;
    private EnemyController _isAttacking;
    private EnemyController _isSearching;
    private EnemyHealth _isAlive;
    

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        _isIdleling = gameObject.GetComponent<EnemyController>();
        _isPatroling = gameObject.GetComponent<EnemyController>();
        _isChasing = gameObject.GetComponent<EnemyController>();
        _isAttacking = gameObject.GetComponent<EnemyController>();
        _isAlive = gameObject.GetComponent<EnemyHealth>();
        _isSearching = gameObject.GetComponent<EnemyController>();

    }
	
	// Update is called once per frame
	void Update () {
        

        if (_isIdleling.isIdleling) {
            anim.SetBool("idleAnim", true);
            anim.SetBool("walkingAnim", false);
            anim.SetBool("attackingAnim", false);
            anim.SetBool("searchingAnim", false);
        }

        else if (_isPatroling.isPatroling) {
            anim.SetBool("walkingAnim", true);
            anim.SetBool("attackingAnim", false);
            anim.SetBool("idleAnim", false);
            anim.SetBool("searchingAnim", false);
        }

         else if (_isSearching.isSearching) {
            anim.SetBool("searchingAnim", true);
            anim.SetBool("walkingAnim", false);
            anim.SetBool("attackingAnim", false);
            anim.SetBool("idleAnim", false);
        }

         else if (_isChasing.isChasing) {
            anim.SetBool("walkingAnim", true);
            anim.SetBool("attackingAnim", false);
            anim.SetBool("idleAnim", false);
            anim.SetBool("searchingAnim", false);
        }

         else if (_isAttacking.isAttacking) {
            anim.SetBool("attackingAnim", true);
            anim.SetBool("walkingAnim", false);
            anim.SetBool("idleAnim", false);
            anim.SetBool("searchingAnim", false);
        } 

         else if (!_isAlive.isAlive) {
            anim.SetBool("attackingAnim", false);
            anim.SetBool("walkingAnim", false);
            anim.SetBool("idleAnim", false);
            anim.SetBool("dieAnim", true);
            anim.SetBool("searchingAnim", false);
        }
	}
}
