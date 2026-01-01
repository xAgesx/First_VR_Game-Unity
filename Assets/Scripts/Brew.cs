


using Unity.Mathematics;
using UnityEngine;

public class Brew : MonoBehaviour {
    [SerializeField] GameObject keyPrefab;
    public float spawnVelocity;
    public Vector3 offset;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BrewedPotion")) {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<MeshRenderer>().enabled = true;

            Destroy(other.gameObject);
        }else if (other.CompareTag("Rusty_Key")) {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).GetComponent<ParticleSystem>().Play();
            var newKey = Instantiate(keyPrefab,transform.parent.position - offset,quaternion.identity);
            newKey.GetComponent<Rigidbody>().AddForce(Vector3.up*spawnVelocity);
            Destroy(other.gameObject);
        }
    }
}
