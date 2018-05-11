using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public bool Quest_1_Activated;
    [SerializeField]
    private GameObject NothingActivatedText;
    [SerializeField]
    private GameObject NothingCompleteText;
    [SerializeField]
    private GameObject Quest_1_Title;
    [SerializeField]
    private GameObject Quest_1_Info;
    [SerializeField]
    private GameObject Quest_1_Complete;


    //NIET HERBRUIKBAAR... TE WEINIG TIJD.

    // Update is called once per frame
    void Start () {
        NothingActivatedText.SetActive(true);
        Quest_1_Info.SetActive(false);
        Quest_1_Title.SetActive(false);
    }

    public void Quest1() {
        Quest_1_Activated = true;
        NothingActivatedText.SetActive(false);
        Quest_1_Info.SetActive(true);
        Quest_1_Title.SetActive(true);
    }

    public void Quest1Complete() {
        NothingActivatedText.SetActive(true);
        Quest_1_Title.SetActive(false);
        NothingCompleteText.SetActive(false);
        Quest_1_Complete.SetActive(true);
    }
}
