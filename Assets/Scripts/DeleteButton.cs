using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    public Button delete;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void DeleteWord()
    {
        for (int i = 0; i < WordsStateManager.wordsState.words.Count; i++)
        {
            WordsStateManager.wordsState.words[i].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }
        WordsStateManager.wordsState.ýnputWord.text = "";
    }
}
