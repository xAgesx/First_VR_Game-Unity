
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class doorTrigger : MonoBehaviour {

    public UnityEvent doorTriggered;
    public PlayableDirector pd;
    public AudioSource openingAudio;
    public GameObject player;
    public float triggerDistance;

    public void openDoor() {

        GetComponent<Animator>().SetBool("isOpen",true);
        openingAudio.Play();
        
    }
    public void playTimeline() {
        pd.Play();
    }
    void Update() {
        Debug.Log(Vector3.Distance(player.transform.position,transform.position) );
        if(Vector3.Distance(player.transform.position,transform.position) <= triggerDistance && GetComponent<Animator>().GetBool("isOpen")) {
            
            playTimeline();
        }
        
    }
}
