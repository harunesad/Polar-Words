using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsStateManager : MonoBehaviour
{
    public static WordsStateManager wordsState;
    public LayerMask wordMask, groundMask, wordSelectMask;
    public TextMeshProUGUI �nputWord;
    public List<string> keyWord;
    public List<GameObject> words;
    public List<string> myWord;
    public GameObject ground;
    public GameObject finishGround;

    public WordsBaseState currentState;
    public WordsSelectState selectState = new WordsSelectState();
    public WordsFillingState fillingState = new WordsFillingState();
    public CharacterMoveState moveState = new CharacterMoveState();
    public WordsClearState clearState = new WordsClearState();
    private void Awake()
    {
        wordsState = this;
        finishGround = GameObject.Find("FinishHextile");
        words.Add(finishGround.transform.parent.gameObject);
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