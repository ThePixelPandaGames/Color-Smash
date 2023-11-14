using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeDuration = 1;
    public float shakeForce = 1;

    private Vector3 originalPosition;


    public void StartShake()
    {
        originalPosition = transform.position;

        StartCoroutine(ShakeCo());
    }

    IEnumerator ShakeCo()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitCircle * shakeForce;
            shakeOffset.z = 0;
            transform.position = originalPosition + shakeOffset;
            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; 
    }
}
