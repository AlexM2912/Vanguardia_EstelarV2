using UnityEngine;
using System.Collections;

public class SlowMotionController : MonoBehaviour
{
    public float slowFactor = 0.3f; // qué tan lento va el tiempo
    public float duration = 3f;     // duración en segundos reales

    private bool isSlow = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isSlow)
        {
            StartCoroutine(SlowMotion());
        }
    }

    IEnumerator SlowMotion()
    {
        isSlow = true;

        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSecondsRealtime(duration); // tiempo real

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        isSlow = false;
    }
}