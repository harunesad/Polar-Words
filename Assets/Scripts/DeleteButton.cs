using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    public Button delete;
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
            for (int i = 0; i < WordsStateManager.wordsState.words.Count; i++)
            {
                WordsStateManager.wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            }
            WordsStateManager.wordsState.ýnputWord.text = "";
        }
    }
}
