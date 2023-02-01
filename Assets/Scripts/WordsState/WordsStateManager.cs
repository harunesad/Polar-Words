using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class WordsStateManager : MonoBehaviour
{
    public static WordsStateManager wordsState;
    public LayerMask wordMask, groundMask, wordSelectMask;
    public TextMeshProUGUI ýnputWord;
    public List<string> keyWord;
    public List<GameObject> words;
    public List<string> myWord;
    public GameObject ground;
    public GameObject finishGround;
    public NavMeshAgent agent;
    public Vector3 point;
    public GameObject polar;
    public GameObject start;
    public CamLook camLook;

    public WordsBaseState currentState;
    public WordsSelectState selectState = new WordsSelectState();
    public WordsFillingState fillingState = new WordsFillingState();
    public CharacterMoveState moveState = new CharacterMoveState();
    public WordsClearState clearState = new WordsClearState();
    public WordsFinishState finishState = new WordsFinishState();
    public WordsClearGroundState clearGroundState = new WordsClearGroundState();
    private void Awake()
    {
        wordsState = this;
        finishGround = GameObject.Find("FinishHextile");
        start = GameObject.Find("StartHextile");
        words.Add(finishGround.transform.parent.gameObject);
        polar = GameObject.Find("Polar");
        agent = polar.GetComponent<NavMeshAgent>();
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