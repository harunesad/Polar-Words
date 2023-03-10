using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Button : MonoBehaviour
{
    public static Button button;
    CamLook camLook;
    WordsStateManager wordsState;
    public GameObject snowGlobe;
    string[] lines;
    List<string> newWord;
    public int buttonClickCount;
    private void Awake()
    {
        button = this;
        string filePath = Application.dataPath + "/dictionary.csv";
        lines = File.ReadAllLines(filePath);
        newWord = new List<string>(lines);
        newWord.AddRange(lines);
    }
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
        string ýnputWord = wordsState.ýnputWord.text;
        var word = ýnputWord.ToCharArray();
        ýnputWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i]== 'I')
            {
                word[i]= 'i';
            }
            ýnputWord = ýnputWord + word[i];
        }
        if (wordsState.currentState == wordsState.selectState && newWord.Contains(ýnputWord.ToLower()))
        {
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] words = lines[i].Split(',');
            //    //newWords = new List<string>(words);
            //    string word = words[i];
            //    Debug.Log(word);
            //    newWords.Add(word);
            //}
            //if (newWord.Contains(wordsState.ýnputWord.text.ToLower()))
            //{
            //    CamLook.cam.SecondPos();
            //}
            if (snowGlobe.GetComponent<Image>().color == new Color(1, 1, 1, 0.5f) && buttonClickCount == 0)
            {
                buttonClickCount++;
            }
            CamLook.cam.SecondPos();
        }
        //for (int i = 0; i < wordsState.keyWord.Count; i++)
        //{
        //    if (wordsState.ýnputWord.text == wordsState.keyWord[i] && wordsState.currentState == wordsState.selectState)
        //    {
        //        //camLook.enabled = true;
        //        //wordsState.SwitchState(wordsState.fillingState);
        //        CamLook.cam.SecondPos();
        //    }
        //}
    }
    public void SnowGlobe()
    {
        if (buttonClickCount == 0 && wordsState.currentState == wordsState.selectState)
        {
            //bool state = snowGlobe.activeSelf;
            //snowGlobe.SetActive(!state);
            ColorChange();
        }
        else
        {

        }
    }
    void ColorChange()
    {
        if (snowGlobe.GetComponent<Image>().color == new Color(1, 1, 1, 1))
        {
            snowGlobe.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (snowGlobe.GetComponent<Image>().color == new Color(1, 1, 1, 0.5f))
        {
            snowGlobe.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
