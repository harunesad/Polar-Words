using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        gameObject.layer = collision.gameObject.layer;
        Destroy(this);
    }
}
