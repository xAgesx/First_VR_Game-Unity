using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class PlayerControlManager : MonoBehaviour {
    public void SetMovement(bool enabled) {
        var locomotion = GetComponentInChildren<LocomotionProvider>();
        if (locomotion != null) locomotion.enabled = enabled;
    }
}