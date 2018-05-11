using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveryManager : MonoBehaviour {

    private bool playerHasEntered;
    private bool areaDiscoverd;
    public bool HasDiscovered;
    private string stringText;

    [Header("Health Settings")]
    [SerializeField]
    private Text areaName;
    [SerializeField]
    private Text areaDiscription;
    [SerializeField]
    private CanvasGroup canvasGroup = null;
    [SerializeField]
    private float fadeSpeed = 2f;
    [SerializeField]
    public AudioSource audio;
    [SerializeField]
    public AudioClip clip;
    [SerializeField]
    private GameObject discoveryUI;

    // Use this for initialization
    void Start() {
        canvasGroup.alpha = 0;
        discoveryUI.SetActive(false);
    }

    public void OpenWindow(AreaInfo areaInfo) {
        areaName.text = areaInfo.areaName;
        areaDiscription.text = areaInfo.areaDescription;
        StartCoroutine(OpenWindow());       
        StartCoroutine(CloseWindow());
    }

    IEnumerator OpenWindow() {
        stringText = areaName.text;
        if (stringText == "Enemy camp") {
            HasDiscovered = true;
            Debug.Log(stringText);
        }

        discoveryUI.SetActive(true);
        audio.PlayOneShot(clip);
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator CloseWindow() {
        yield return new WaitForSeconds(3f);
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
