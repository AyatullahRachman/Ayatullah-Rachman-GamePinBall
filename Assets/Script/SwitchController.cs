using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Controller : MonoBehaviour
{
    private enum SwitchState
    {
        off,
        on,
        blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public ScoreManager scoreManager;

    public float score;

    private SwitchState state;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == bola)
        {
            Toggle();
        }
    }

    void Set(bool Active)
    {
       if(Active == true)
        {
            state = SwitchState.on;
            rend.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.off;
            rend.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if(state == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.blink;

        for (int i = 0; i < times; i++)
        {
            rend.material = onMaterial;
            yield return new WaitForSeconds(0.5f);

            rend.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
