using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchercontroller : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxForce;
    public float maxTimeHold;

    private bool isHold = false;
    private void Update()
    {
        if (Input.GetKeyDown(input) && !isHold)
        {
            if (bola != null && bola.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
            {
                StartCoroutine(StartHold(bola));
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    void ReadInput(Collider collider)
    {
        if (Input.GetKeyDown(input) && !isHold) // Pastikan isHold == false saat memulai
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;

        // Loop selama tombol masih ditekan
        while (Input.GetKey(input))
        {
            // Kalkulasi Force dengan Lerp
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            // Tambahkan waktu hold
            timeHold += Time.deltaTime;

            // Pastikan tidak melebihi maxTimeHold
            timeHold = Mathf.Clamp(timeHold, 0, maxTimeHold);

            yield return null;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);

        isHold = false;
    }
}
