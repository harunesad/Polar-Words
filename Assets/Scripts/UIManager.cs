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
    public GameObject snowEffect;
    public GameObject snow;
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
    public void DeleteWord()
    {
        if ((int)_camLook.gameObject.transform.localEulerAngles.x == 90 && _wordsState.currentState == _wordsState.selectState)
        {
            foreach (var words in _wordsState.words)
            {
                words.GetComponent<Renderer>().materials[1].color = _wordsState.firstColor;
            }
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
            if (buttonClick)
            {
                snowGlobe.GetComponent<Button>().interactable = false;
                skillActive = true;
                buttonClick = false;
                snowGlobe.GetComponent<Button>().onClick.RemoveAllListeners();
            }
            CamLook.cam.SecondPos();
        }
    }
    public void SnowGlobe()
    {
        if (_wordsState.currentState == _wordsState.selectState && skillActive == false)
        {
            buttonClick = !buttonClick;
            //ColorChange();
            if (snow != null)
            {
                Destroy(snow, 2f);
                snow.GetComponent<ParticleSystem>().startSize = 0;
            }
            else
            {
                var snow = Instantiate(snowEffect, snowEffect.transform.position, Quaternion.identity);
                this.snow = snow;
            }
        }
    }
    void ColorChange()
    {
        if (snowGlobe.GetComponent<Image>().color == new Color(1, 1, 1, 1))
        {
            Debug.Log("s");
            var snow = Instantiate(snowEffect, snowEffect.transform.position, Quaternion.identity);
            this.snow = snow;
            snowGlobe.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (snowGlobe.GetComponent<Image>().color == new Color(1, 1, 1, 0.5f))
        {
            Debug.Log("a");
            Destroy(snow, 2f);
            snow.GetComponent<ParticleSystem>().startSize = 0;
            snowGlobe.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
