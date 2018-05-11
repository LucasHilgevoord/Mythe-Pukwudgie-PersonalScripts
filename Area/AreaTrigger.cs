using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTrigger : MonoBehaviour {

    private bool playerHasEntered;
    private bool areaDiscoverd;

    public AreaInfo areaInfo;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !playerHasEntered) {
            playerHasEntered = true;

            if (!areaDiscoverd) {
                areaDiscoverd = true;
                FindObjectOfType<DiscoveryManager>().OpenWindow(areaInfo);
            }

        } else {
            playerHasEntered = false;
        }
    }
}
