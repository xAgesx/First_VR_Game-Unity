using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour {
    public UnityEvent OnPressed;
    // public AudioSource pressSound;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor>()) {
            OnPressed.Invoke();
            // if (pressSound) pressSound.Play();
            transform.localPosition -= new Vector3(0, 0.05f, 0);
        }
    }

    private void OnTriggerExit(Collider other) {
        transform.localPosition += new Vector3(0, 0.05f, 0);
    }
}