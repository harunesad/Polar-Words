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
        if (camLook.gameObject.transform.localEulerAngles.x == 90 && wordsState.currentState == wordsState.selectState)
        {
            for (int i = 0; i < wordsState.words.Count; i++)
            {
                //wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                wordsState.words[i].GetComponent<Renderer>().materials[1].color = wordsState.firstColor;
            }
            wordsState.ýnputWord.text = "";
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
    public void Answer()
    {
        for (int i = 0; i < wordsState.keyWord.Count; i++)
        {
            if (wordsState.ýnputWord.text == wordsState.keyWord[i] && wordsState.currentState == wordsState.selectState)
            {
                //camLook.enabled = true;
                //wordsState.SwitchState(wordsState.fillingState);
                CamLook.cam.SecondPos();
            }
        }
    }
}
