using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    //public Button delete;
    CamLook camLook;
    WordsStateManager wordsState;
    void Start()
    {
        camLook = FindObjectOfType<CamLook>();
        wordsState = FindObjectOfType<WordsStateManager>();
    }
    void Update()
    {
        
    }
    public void DeleteWord()
    {
        if (camLook.enabled == false && wordsState.currentState == wordsState.selectState)
        {
            for (int i = 0; i < wordsState.words.Count; i++)
            {
                wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            }
            wordsState.ýnputWord.text = "";
            for (int i = 0; i < wordsState.words.Count; i++)
            {
                wordsState.words[i].layer = 3;
                if (wordsState.ground.transform.parent.gameObject != wordsState.words[i] && wordsState.finishGround.transform.parent.gameObject != wordsState.words[i])
                {
                    Debug.Log("aaaa");
                    wordsState.words.RemoveAt(i);
                    i--;
                }
            }
            //WordsStateManager.wordsState.words.Clear();
        }
    }
    public void Answer()
    {
        for (int i = 0; i < wordsState.keyWord.Count; i++)
        {
            if (wordsState.ýnputWord.text == wordsState.keyWord[i] && wordsState.currentState == wordsState.selectState)
            {
                camLook.enabled = true;
            }
        }
    }
}
