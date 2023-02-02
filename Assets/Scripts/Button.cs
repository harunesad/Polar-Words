using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    CamLook camLook;
    WordsStateManager wordsState;
    void Start()
    {
        camLook = FindObjectOfType<CamLook>();
        wordsState = FindObjectOfType<WordsStateManager>();
    }
    public void DeleteWord()
    {
        if (camLook.enabled == false && wordsState.currentState == wordsState.selectState)
        {
            for (int i = 0; i < wordsState.words.Count; i++)
            {
                wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            }
            wordsState.�nputWord.text = "";
            for (int i = 0; i < wordsState.words.Count; i++)
            {
                if (wordsState.ground.transform.parent.gameObject != wordsState.words[i] && wordsState.finishGround.transform.parent.gameObject != wordsState.words[i])
                {
                    wordsState.words[i].layer = 3;
                    wordsState.words.RemoveAt(i);
                    i--;
                }
            }
        }
    }
    //public void ClearGround()
    //{
    //    if (wordsState.currentState == wordsState.moveState)
    //    {
    //        wordsState.start.layer = 6;
    //        wordsState.SwitchState(wordsState.clearGroundState);
    //    }
    //}
    public void Answer()
    {
        for (int i = 0; i < wordsState.keyWord.Count; i++)
        {
            if (wordsState.�nputWord.text == wordsState.keyWord[i] && wordsState.currentState == wordsState.selectState)
            {
                wordsState.SwitchState(wordsState.fillingState);
            }
        }
    }
}
