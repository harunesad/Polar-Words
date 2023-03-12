using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        ////if (gameObject.layer == 7 && WordsStateManager.wordsState.currentState == WordsStateManager.wordsState.fillingState)
        ////{
        ////    gameObject.layer = collision.gameObject.layer;
        ////}
        if (gameObject.layer == 7 && WordsStateManager.wordsState.currentState != WordsStateManager.wordsState.clearState)
        {
            gameObject.layer = collision.gameObject.layer;
        }
        if (WordsStateManager.wordsState.finishGround == gameObject)
        {
            gameObject.layer = collision.gameObject.layer;
        }
    }
}
