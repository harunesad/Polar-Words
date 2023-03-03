using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        JsonSave.json.so.fishCount++;
        JsonSave.json.Save();
        Destroy(gameObject, 0.1f);
    }
}
