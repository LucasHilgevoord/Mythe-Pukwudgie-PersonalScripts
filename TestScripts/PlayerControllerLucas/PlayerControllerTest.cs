using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour {

    [SerializeField]
    private GameObject Arrow;
    [SerializeField]
    private GameObject Rock;
    [SerializeField]
    private GameObject Shootpoint;
    [SerializeField]
    private float moveSpeed = 5f;

    // Update is called once per frame
    void Update() {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown("space")) {
            Instantiate(Arrow, Shootpoint.transform.position, transform.rotation);
        }

        if (Input.GetKeyDown("r")) {
            Instantiate(Rock, Shootpoint.transform.position, Shootpoint.transform.rotation);
        }

    }
   
}
