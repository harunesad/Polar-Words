using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != 10)
        {
            WordsStateManager.wordsState.ground = other.gameObject;
        }
    }
}
