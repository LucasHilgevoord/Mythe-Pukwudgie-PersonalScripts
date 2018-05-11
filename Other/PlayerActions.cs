using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    [SerializeField]
    private GameObject Arrow;
    [SerializeField]
    private GameObject Rock;
    [SerializeField]
    private GameObject Shootpoint;
    [SerializeField]

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("r")) {
            Instantiate(Arrow, Shootpoint.transform.position, transform.rotation);
        }

        if (Input.GetKeyDown("t")) {
            Instantiate(Rock, Shootpoint.transform.position, Shootpoint.transform.rotation);
        }

        if (Input.GetKeyDown("p")) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
