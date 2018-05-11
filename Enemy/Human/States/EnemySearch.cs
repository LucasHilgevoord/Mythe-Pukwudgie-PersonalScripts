using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour {

    private EnemyController _isSearching;
    private EnemyController _isSpotted;
    private bool isPlaying;
    public Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponentInChildren<Animator>();
        _isSearching = gameObject.GetComponent<EnemyController>();
        _isSpotted = gameObject.GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update() {
        if (!_isSearching.isSearching) return;
        if (!isPlaying) {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("EnemySearchingAnim")) {
                isPlaying = true;
            }            
        } else {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 || _isSpotted.isChasing) {
                isPlaying = false;
                _isSearching.isSearching = false;
            }
        }
    }
}
