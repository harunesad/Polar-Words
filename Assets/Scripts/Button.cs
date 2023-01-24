using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    //public Button delete;
    CamLook camLook;
    //WordsStateManager wordsState;
    void Start()
    {
        camLook = FindObjectOfType<CamLook>();
        //wordsState = FindObjectOfType<WordsStateManager>();
    }
    void Update()
    {
        
    }
    public void DeleteWord()
    {
        if (camLook.enabled == false && WordsStateManager.wordsState.currentState == WordsStateManager.wordsState.selectState)
        {
            for (int i = 0; i < WordsStateManager.wordsState.words.Count; i++)
            {
                WordsStateManager.wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            }
            WordsStateManager.wordsState.ýnputWord.text = "";
            for (int i = 0; i < WordsStateManager.wordsState.words.Count; i++)
            {
                WordsStateManager.wordsState.words[i].layer = 3;
                if (WordsStateManager.wordsState.ground.transform.parent.name != WordsStateManager.wordsState.words[i].name)
                {
                    Debug.Log("aaaa");
                    WordsStateManager.wordsState.words.RemoveAt(i);
                    i--;
                }
            }
            //WordsStateManager.wordsState.words.Clear();
        }
    }
    public void Answer()
    {
        for (int i = 0; i < WordsStateManager.wordsState.keyWord.Count; i++)
        {
            if (WordsStateManager.wordsState.ýnputWord.text == WordsStateManager.wordsState.keyWord[i])
            {
                camLook.enabled = true;
            }
        }
    }
}
