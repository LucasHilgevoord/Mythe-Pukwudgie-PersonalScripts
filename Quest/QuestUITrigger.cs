using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUITrigger : MonoBehaviour {

    [SerializeField]
    private GameObject questMenu;
    private bool isOpen;

    // Use this for initialization
    void Start () {
        questMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q")) {
            if (!isOpen) {
                OpenWindow();
            } else {
                CloseWindow();
            }
        }
    }

    void OpenWindow() {
        questMenu.SetActive(true);
        isOpen = true;
    }

    void CloseWindow() {
        questMenu.SetActive(false);
        isOpen = false;
    }
}
