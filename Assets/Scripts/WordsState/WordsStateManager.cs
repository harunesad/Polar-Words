using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsStateManager : MonoBehaviour
{
    public static WordsStateManager wordsState;
    public LayerMask mask;
    public TextMeshProUGUI ýnputWord;
    public string keyWord;
    public List<GameObject> words;
    public List<string> myWord;

    WordsBaseState currentState;
    public WordsSelectState selectState = new WordsSelectState();
    public WordsFillingState fillingState = new WordsFillingState();
    private void Awake()
    {
        wordsState = this;
    }
    void Start()
    {
        currentState = selectState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(WordsBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}