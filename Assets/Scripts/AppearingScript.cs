using System.Collections;
using UnityEngine;

public class AppearingScript : MonoBehaviour
{
    public float fadeSpeed;
    private Collider platformCollider;
    public float interval = 5f;

    void Start()
    {
        // Get the Collider component of the platform
        platformCollider = GetComponent<Collider>();

        // Start the coroutine to fade in and out at regular intervals
        StartCoroutine(FadeInOutPeriodically());
    }

    IEnumerator FadeInOutPeriodically()
    {
        while (true)
        {
            // Enable the collider before fading in
            platformCollider.enabled = true;

            // Fade in
            yield return StartCoroutine(FadeRoutine(1.0f));

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            // Fade out
            yield return StartCoroutine(FadeRoutine(0.0f));

            // Disable the collider after fading out
            platformCollider.enabled = false;

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        // Set the flag to start the fade process
        bool isFading = true;

        while (isFading)
        {
            Color objectC = GetComponent<Renderer>().material.color;
            float fadeAm = Mathf.MoveTowards(objectC.a, targetAlpha, fadeSpeed * Time.deltaTime);

            objectC = new Color(objectC.r, objectC.g, objectC.b, fadeAm);
            GetComponent<Renderer>().material.color = objectC;

            // Check if the target alpha is reached
            if (Mathf.Approximately(objectC.a, targetAlpha))
            {
                isFading = false;
            }

            yield return null;
        }
    }
}
