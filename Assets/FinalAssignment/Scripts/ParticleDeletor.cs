using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeletor : MonoBehaviour
{
    public float durationTimer = 0;
    public float maxDurationTime;

    // Update is called once per frame
    void Update()
    {
        durationTimer += Time.deltaTime;
        if (durationTimer > maxDurationTime)
        {
            Destroy(gameObject);
        }
    }
}
