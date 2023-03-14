using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    CamLook _camLook;
    WordsStateManager _wordsState;
    public GameObject snowGlobe;
    string[] _lines;
    List<string> _newWord;
    public bool buttonClick;
    public bool skillActive;
    private void Awake()
    {
        uIManager = this;

        string filePath = Application.dataPath + "/dictionary.csv";
        _lines = File.ReadAllLines(filePath);
        _newWord = new List<string>(_lines);
        _newWord.AddRange(_lines);

        _camLook = FindObjectOfType<CamLook>();
        _wordsState = FindObjectOfType<WordsStateManager>();
        snowGlobe.GetComponent<Button>().onClick.AddListener(SnowGlobe);
    }
    //void Start()
    //{
    //    camLook = FindObjectOfType<CamLook>();
    //    wordsState = FindObjectOfType<WordsStateManager>();
    //}
    public void DeleteWord()
    {
        if ((int)_camLook.gameObject.transform.localEulerAngles.x == 90 && _wordsState.currentState == _wordsState.selectState)
        {
            foreach (var words in _wordsState.words)
            {
                words.GetComponent<Renderer>().materials[1].color = _wordsState.firstColor;
            }
            /*
            for (int i = 0; i < _wordsState.words.Count; i++)
            {
                _wordsState.words[i].GetComponent<Renderer>().materials[1].color = _wordsState.firstColor;
            }
            */
            _wordsState.inputWord.text = "";
            for (int i = 0; i < _wordsState.words.Count; i++)
            {
                if (_wordsState.ground.transform.parent.gameObject != _wordsState.words[i] && _wordsState.finishGround.transform.parent.gameObject != _wordsState.words[i])
                {
                    _wordsState.words[i].layer = 3;
                    _wordsState.words.RemoveAt(i);
                    i--;
                }
            }
        }
    }
    public void Answer()
    {
        string inputWord = _wordsState.inputWord.text;
        var word = inputWord.ToCharArray();
        inputWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i]== 'I')
            {
                word[i]= 'i';
            }
            inputWord = inputWord + word[i];
        }
        if (_wordsState.currentState == _wordsState.selectState && _newWord.Contains(inputWord.ToLower()))
        {
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] words = lines[i].Split(',');
            //    //newWords = new List<string>(words);
            //    string word = words[i];
            //    Debug.Log(word);
            //    newWords.Add(word);
            //}
            //if (newWord.Contains(wordsState.inputWord.text.ToLower()))
            //{
            //    CamLook.cam.SecondPos();
            //}
            //skillActive = false;
            if (buttonClick && snowGlobe.GetComponent<Image>().color == new Color(r:1, 1, 1, 0.5f))
            {
                skillActive = true;
                buttonClick = false;
                snowGlobe.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            CamLook.cam.SecondPos();
        }
        //for (int i = 0; i < wordsState.keyWord.Count; i++)
        //{
        //    if (wordsState.inputWord.text == wordsState.keyWord[i] && wordsState.currentState == wordsState.selectState)
        //    {
        //        //camLook.enabled = true;
        //        //wordsState.SwitchState(wordsState.fillingState);
        //        CamLook.cam.SecondPos();
        //    }
        //}
    }
    public void SnowGlobe()
    {
        if (_wordsState.currentState == _wordsState.selectState && skillActive == false)
        {
            buttonClick = !buttonClick;
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