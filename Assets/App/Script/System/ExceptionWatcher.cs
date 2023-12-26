using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class ExceptionWatcher : MonoBehaviour
{
    private XRInteractionManager interactionManager;
    public float hideDuration = 0.1f; // Dur?e pendant laquelle l'objet sera cach?

    private void Start()
    {
        // R?cup?ration du GameObject avec XRInteractionManager
        interactionManager = FindObjectOfType<XRInteractionManager>();
        if (interactionManager == null)
        {
            Debug.LogWarning("Aucun XRInteractionManager trouv? dans la sc?ne.");
            return;
        }

        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {

        if (type == LogType.Exception &&
            logString.Contains("NullReferenceException") &&
            stackTrace.Contains("UnityEngine.InputSystem.InputActionState.ApplyProcessors[TValue]"))
        {
            if (interactionManager != null)
            {
                StartCoroutine(HideObjectTemporarily(interactionManager.gameObject, hideDuration));
            }
        }
    }

    IEnumerator HideObjectTemporarily(GameObject obj, float duration)
    {
        obj.SetActive(false); // Cacher l'objet
        yield return new WaitForSeconds(duration);
        obj.SetActive(true);  // R?afficher l'objet
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }
}