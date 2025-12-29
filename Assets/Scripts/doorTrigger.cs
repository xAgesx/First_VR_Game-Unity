using UnityEngine;
using UnityEngine.Events;

public class doorTrigger : MonoBehaviour {

    public UnityEvent doorTriggered;

    public void openDoor() {

        GetComponent<Animator>().SetBool("isOpen",true);
    }
}
