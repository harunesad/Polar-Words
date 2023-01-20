using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsStateManager : MonoBehaviour
{
    public LayerMask mask;
    public TextMeshProUGUI ýnputWord;
    public string keyWord;
    public List<GameObject> words;

    WordsBaseState currentState;
    public WordsSelectState selectState = new WordsSelectState();
    public WordsFillingState fillingState = new WordsFillingState();
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