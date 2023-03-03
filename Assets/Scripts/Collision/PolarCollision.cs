using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        WordsStateManager.wordsState.ground = other.gameObject;
    }
}
