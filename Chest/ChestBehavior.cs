using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour {

    private GameObject target;
    public Animator anim;
    [SerializeField]
    private GameObject loot;
    private Vector3 pos;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openChest;
    [SerializeField]
    private AudioClip shootItem;

    private int interactRange = 4;
    private bool openAnim;
    public bool isOpened;
    private bool spawnedItems;

    

    // Use this for initialization
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        pos = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(target.transform.position, transform.position) < interactRange) {
            if (Input.GetKeyDown("f")) {
                if (!isOpened) {
                    //Open crate
                    audioSource.PlayOneShot(openChest);
                    isOpened = true;
                    anim.SetBool("openAnim", true);
                    StartCoroutine(Interact());
                    StartCoroutine(SpawnItems());
                }
            }
        }
    }

    IEnumerator Interact() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject.transform.Find("particles").gameObject);
    }

    IEnumerator SpawnItems() {
    for (int i = 0; i < Random.Range(5, 10); i++) {
        yield return new WaitForSeconds(.3f);
        audioSource.PlayOneShot(shootItem);
        GameObject newitem = Instantiate(loot, new Vector3(pos.x + .3f, pos.y + 1f, pos.z), Quaternion.Euler(-90, 0, 0)) as GameObject;
        Vector3 direction = new Vector3(Random.Range(-5, 4), 1.5f, Random.Range(-5, 0));
            newitem.GetComponent<Rigidbody>().AddForce(direction * 90);
        }
    }
}
