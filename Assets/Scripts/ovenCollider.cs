using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ovenCollider : MonoBehaviour {
    [SerializeField] Oven ovenScript;
    [SerializeField] Material transformedMat;
    [SerializeField] GameObject progressCanvasPrefab; 
    [SerializeField] Vector3 offset = new Vector3(0, 0.5f, 0); 
    [SerializeField] float transformationDuration = 3.0f;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Flammable")) {
            var details = other.gameObject.GetComponent<ObjectDetails>();
            if (details != null) {
                ovenScript.increaseTemp(details.details.tempIncrease);
            }
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("Potion")) {
            PotionTracker tracker = other.gameObject.GetComponent<PotionTracker>();
            if (tracker == null) tracker = other.gameObject.AddComponent<PotionTracker>();

            if (!tracker.isTransformed && !tracker.isCooking) {
                tracker.StartTransforming(transformationDuration, transformedMat, progressCanvasPrefab, offset);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Potion")) {
            PotionTracker tracker = other.gameObject.GetComponent<PotionTracker>();
            if (tracker != null) {
                tracker.StopTransforming();
            }
        }
    }
}

public class PotionTracker : MonoBehaviour {
    public bool isTransformed = false;
    public bool isCooking = false;
    
    private Coroutine activeRoutine;
    private GameObject activeUI;

    public void StartTransforming(float duration, Material newMat, GameObject uiPrefab, Vector3 offset) {
        isCooking = true;
        activeRoutine = StartCoroutine(TransformRoutine(duration, newMat, uiPrefab, offset));
    }

    public void StopTransforming() {
        if (isTransformed) return; // Don't stop if it's already finished

        isCooking = false;
        if (activeRoutine != null) {
            StopCoroutine(activeRoutine);
            activeRoutine = null;
        }

        if (activeUI != null) {
            Destroy(activeUI);
        }
    }

    private IEnumerator TransformRoutine(float duration, Material newMat, GameObject uiPrefab, Vector3 offset) {
        Slider progressBar = null;

        // Create UI
        if (uiPrefab != null) {
            activeUI = Instantiate(uiPrefab, transform.position + offset, Quaternion.identity, transform);
            progressBar = activeUI.GetComponentInChildren<Slider>();
        }

        float elapsed = 0;
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            if (progressBar != null) {
                progressBar.value = elapsed / duration;
            }
            yield return null;
        }

        // Complete Transformation
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null && newMat != null) {
            Material[] mats = renderer.sharedMaterials;
            for (int i = 0; i < mats.Length; i++) mats[i] = newMat;
            renderer.materials = mats;
        }

        isTransformed = true;
        isCooking = false;
        if (activeUI != null) Destroy(activeUI);
    }
}