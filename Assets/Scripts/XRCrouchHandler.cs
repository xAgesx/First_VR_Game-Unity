using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCrouchHandler : MonoBehaviour {
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private InputActionProperty crouchAction;

    [SerializeField] private float standingHeight = 1.3f;
    [SerializeField] private float crouchHeight = 0.3f ;

    [SerializeField] private float transitionSpeed = 5f;

    private float targetHeight;

    void Awake() {
        targetHeight = standingHeight;

        if (xrOrigin == null) {
            xrOrigin = GetComponent<XROrigin>();
        }
    }

    void OnEnable() {
        crouchAction.action.performed += ToggleCrouch;
        Debug.Log("Enabled");
    }

    void OnDisable() {
        crouchAction.action.performed -= ToggleCrouch;
        Debug.Log("Disabled");

    }

    void Update() {
        float currentHeight = xrOrigin.CameraYOffset;
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, Time.deltaTime * transitionSpeed);
        xrOrigin.CameraYOffset = currentHeight;
    }

    private void ToggleCrouch(InputAction.CallbackContext context) {
        Debug.Log("Crouch");

        if (targetHeight == standingHeight) {
            targetHeight = crouchHeight;
        } else {
            targetHeight = standingHeight;
        }
    }
}