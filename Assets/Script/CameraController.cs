using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private Vector3 defaultPosition;

    public Transform target;
    public float returnTime;
    public float followSpeed;
    public float length;

    public bool hasTarget {get { return target != null; } }

    private void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    public void FollowTarget(Transform targetTransform, float Targetlength)
    {
        target = targetTransform;
        length = Targetlength;
        StopAllCoroutines();
    }

    public void GoBackToDefault()
    {
        target = null;

        StopAllCoroutines();
        //gerakan ke posisi default
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    public IEnumerator MovePosition(Vector3 Target, float time)
    {
        float timer = 0f;
        Vector3 start = transform.position;

        while (timer < time)
        {
            //pindahkan posisi camera secara bertahap
            transform.position = Vector3.Lerp(start, Target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));

            timer = timer + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = Target;
    }
}
