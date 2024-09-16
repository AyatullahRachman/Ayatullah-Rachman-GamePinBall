using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject VFXsource;

    public void PlayVFX(Vector3 spawnPosition)
    {
        Instantiate(VFXsource, spawnPosition, Quaternion.identity);
    }
}
