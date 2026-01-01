using UnityEngine;
using UnityEngine.Playables;

public class KeyLock : MonoBehaviour {
    [SerializeField] GameObject helpUI;
    [SerializeField] PlayableDirector unlockTimeline;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Rusty_Key")) {
            helpUI.SetActive(true);
        } else if (other.CompareTag("Key")) {
            unlockTimeline.Play();
            Destroy(other.gameObject);
        }
    }
}
