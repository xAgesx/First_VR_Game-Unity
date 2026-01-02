using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class doorTrigger : MonoBehaviour {

    public UnityEvent doorTriggered;
    public PlayableDirector pd;

    public void openDoor() {

        GetComponent<Animator>().SetBool("isOpen",true);
    }
    public void playTimeline() {
        pd.Play();
    }
}
