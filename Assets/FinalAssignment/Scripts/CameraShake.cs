using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.2f;      // how long the shake lasts
    public float magnitude = 0.1f;     // how much it shakes

    private Vector3 originalPos;

    void Awake()
    {
        originalPos = transform.position;
    }

    public void Shake()
    {
        StopAllCoroutines();  // stop previous shake if any
        StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos; // reset to original
    }
}
