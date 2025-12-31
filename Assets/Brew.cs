using UnityEngine;

public class Brew : MonoBehaviour {
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BrewedPotion")) {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<MeshRenderer>().enabled = true;

            Destroy(other.gameObject);
        }
    }
}
