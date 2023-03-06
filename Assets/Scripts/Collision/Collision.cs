using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (gameObject.layer == 7)
        {
            gameObject.layer = collision.gameObject.layer;
        }
        if (WordsStateManager.wordsState.finishGround == gameObject)
        {
            gameObject.layer = collision.gameObject.layer;
        }
    }
}
