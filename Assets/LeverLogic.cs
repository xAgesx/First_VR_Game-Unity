using UnityEngine;
using UnityEngine.Events;

public class LeverLogic : MonoBehaviour {
    public HingeJoint hinge;
    public float threshold = 35f; 
    public UnityEvent onLeverPulled;
    private bool isActivated = false;

    void Update() {
        if (!isActivated && hinge.angle >= threshold) {
            isActivated = true;
            onLeverPulled.Invoke();
            Debug.Log("Lever Activated!");
        } else if (isActivated && hinge.angle < threshold - 5f) {
            isActivated = false;
        }
    }
}