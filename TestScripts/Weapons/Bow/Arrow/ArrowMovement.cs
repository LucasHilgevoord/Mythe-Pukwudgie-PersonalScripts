using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

    [SerializeField]
    private int arrowSpeed = 10;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter() {
        Destroy(gameObject);
    }
}
