using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    [SerializeField]
    private float sight = 20;
    public bool isSpotted;
    [SerializeField]
    private GameObject exclamationMark;
    private bool markCreate;
    private EnemyController _target;
    private EnemyController _isWatching;
    private AudioController spottedAudio;
    [SerializeField]
    public GameObject model;
    private LayerMask layerMask = 9;
    public static bool isSpottedAudio = false;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip alertSound;
    public static bool hasBeenSpotted;
    




    //Stap 1: Bepaal welke richting hij kijkt, in dit geval:
    //  Vector3 fwd = transform.TransformDirection(Vector3.forward);
    //Stap 2: Bepaal de via de enemy waar de player is.
    //Stap 3: Als de hoek van de richting waarnaar hij toe kijken en de player minder dan 45 graden schiet hij een raycast uit die kijkt of er iets tussen zit
    //Stap 4: Zit er er iets tussen de raycast en player doe niks, anders isSpotted = true;

    void Start() {
        _isWatching = gameObject.GetComponent<EnemyController>();
        _target = gameObject.GetComponent<EnemyController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (_isWatching.isWatching) {
            Vector3 targetDir = _target.target.transform.position - model.transform.position;
            float angleToPlayer = (Vector3.Angle(targetDir, -model.transform.forward));
            Vector3 origin = model.transform.position;
            Debug.DrawLine(origin, model.transform.position + -model.transform.forward * sight, Color.green);

            if (angleToPlayer >= -45 && angleToPlayer <= 45) {
                RaycastHit hit;
                if (Physics.Raycast(origin, targetDir, out hit, sight, layerMask)) {

                    if (hit.collider.CompareTag("Player")) {
                        Debug.DrawLine(origin, hit.point, Color.red);
                        isSpottedAudio = true;
                        isSpotted = true;
                        if (!markCreate) {
                            Instantiate(exclamationMark, transform.position + transform.up * 2f, Quaternion.identity, transform);
                            markCreate = true;
                            audioSource.PlayOneShot(alertSound);
                            hasBeenSpotted = true;
                        }
                    } else {
                        Debug.DrawLine(origin, hit.point, Color.yellow);
                        isSpotted = false;
                        isSpottedAudio = false;
                        if (markCreate) {
                            markCreate = false;
                            Destroy(gameObject.transform.Find("exclamationMark(Clone)").gameObject);
                            hasBeenSpotted = false;
                        }
                    }
                } else {
                    isSpotted = false;
                    isSpottedAudio = false;
                    if (markCreate) {
                        markCreate = false;
                        Destroy(gameObject.transform.Find("exclamationMark(Clone)").gameObject);
                        hasBeenSpotted = false;
                    }
                }
            }
        }
    }
}