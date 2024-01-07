using System.Collections;
using UnityEngine;

public class AppearingScript : MonoBehaviour
{
    public float fadeSpeed;
    private Collider platformCollider;
    public float interval = 5f;

    void Start()
    {
        platformCollider = GetComponent<Collider>();
        StartCoroutine(FadeInOutPeriodically());
    }

    IEnumerator FadeInOutPeriodically()
    {
        while (true)
        {
            platformCollider.enabled = true;
            yield return StartCoroutine(FadeRoutine(1.0f));
            yield return new WaitForSeconds(interval);
            yield return StartCoroutine(FadeRoutine(0.0f));
            platformCollider.enabled = false;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        bool isFading = true;

        while (isFading)
        {
            Color objectC = GetComponent<Renderer>().material.color;
            float fadeAm = Mathf.MoveTowards(objectC.a, targetAlpha, fadeSpeed * Time.deltaTime);

            objectC = new Color(objectC.r, objectC.g, objectC.b, fadeAm);
            GetComponent<Renderer>().material.color = objectC;
            if (Mathf.Approximately(objectC.a, targetAlpha))
            {
                isFading = false;
            }
            yield return null;
        }
    }
}
