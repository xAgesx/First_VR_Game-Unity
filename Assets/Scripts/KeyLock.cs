using UnityEngine;

public class KeyLock : MonoBehaviour
{   
    [SerializeField] GameObject helpUI;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Rusty_Key")) {
            helpUI.SetActive(true);
        }
    }
}
