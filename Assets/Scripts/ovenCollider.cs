using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ovenCollider : MonoBehaviour
{
    [SerializeField] Oven ovenScript;
    [SerializeField] GameObject potionprefab;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Flammable")) {
            var value = other.gameObject.GetComponent<ObjectDetails>().details.tempIncrease;
            ovenScript.increaseTemp(value);


            Destroy(other.gameObject);
        }
    }
}
