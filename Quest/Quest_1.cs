using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_1 : MonoBehaviour {

    //NIET HERBRUIKBAAR!!! PITTIG SLECHT!!! MAAR HET WERKT!!!

    public bool objective_1_Finish;
    public bool objective_3_Finish;
    public bool objective_4_Finish;
    [SerializeField]
    private GameObject checkmark;
    [SerializeField]
    private GameObject objective_1;
    [SerializeField]
    private GameObject objective_2;
    [SerializeField]
    private GameObject objective_3;
    [SerializeField]
    private GameObject objective_4;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip questFinishAudio;
    [SerializeField]
    private GameObject questManager;
    [SerializeField]
    private GameObject chestObjective;
    [SerializeField]
    private GameObject DiscoveryObjective;
    [SerializeField]
    private GameObject cross;

    Transform mark1;
    Transform mark2;
    Transform mark3;
    Transform mark4;
    QuestManager questActive;
    ChestBehavior chestBehavior;
    DiscoveryManager discovery;
    EnemyHealth _killCount;
    EnemySight hasBeenSpotted;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        questActive = questManager.GetComponent<QuestManager>();
        chestBehavior = chestObjective.GetComponent<ChestBehavior>();
        discovery = DiscoveryObjective.GetComponent<DiscoveryManager>();
    }

    // Update is called once per frame
    void Update() {
        if (questActive.Quest_1_Activated) {
            //Quest1
            if (discovery.HasDiscovered) {
                mark1 = objective_1.transform.Find("Checkmark(Clone)");
                if (mark1 == null) {
                    audioSource.PlayOneShot(questFinishAudio);
                    Instantiate(checkmark, objective_1.transform.position, Quaternion.identity, objective_1.transform);
                }
            }
            //Quest2
            if (chestBehavior.isOpened) {
                mark2 = objective_2.transform.Find("Checkmark(Clone)");
                if (mark2 == null) {
                    audioSource.PlayOneShot(questFinishAudio);
                    Instantiate(checkmark, objective_2.transform.position, Quaternion.identity, objective_2.transform);
                }
            }

            if (EnemyHealth.killCount >= 1) {
                mark3 = objective_3.transform.Find("Checkmark(Clone)");
                if (mark3 == null) {
                    audioSource.PlayOneShot(questFinishAudio);
                    Instantiate(checkmark, objective_3.transform.position, Quaternion.identity, objective_3.transform);
                }
            }
            if (EnemySight.hasBeenSpotted == true) {
                mark4 = objective_4.transform.Find("Checkmark(Clone)");
                if (mark4 == null) {
                    audioSource.PlayOneShot(questFinishAudio);
                }
            }
        }
    }
}
