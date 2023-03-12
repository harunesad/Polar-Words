using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class WordsStateManager : MonoBehaviour
{
    public static WordsStateManager wordsState;
    public LayerMask wordMask, groundMask, wordSelectMask;
    public TextMeshProUGUI inputWord;
    public List<string> keyWord;
    public List<GameObject> words;
    public List<GameObject> iceWords;
    public List<string> myWord;
    public GameObject ground;
    public GameObject finishGround;
    public GameObject beforeToFinish;
    public GameObject fish;
    public NavMeshAgent agent;
    public Vector3 point;
    public GameObject polar;
    public GameObject start;
    public GameObject firstGround;
    public CamLook camLook;
    public Color firstColor;
    public Color lastColor;
    public int startFishCount;

    public WordsBaseState currentState;
    public WordsSelectState selectState = new WordsSelectState();
    public WordsFillingState fillingState = new WordsFillingState();
    public CharacterMoveState moveState = new CharacterMoveState();
    public WordsClearState clearState = new WordsClearState();
    public WordsFinishState finishState = new WordsFinishState();
    public WordsClearGroundState clearGroundState = new WordsClearGroundState();
    public SnowGlobeState snowGlobeState = new SnowGlobeState();
    private void Awake()
    {
        wordsState = this;
        words.Add(finishGround.transform.parent.gameObject);
        startFishCount = FindObjectsOfType<FishCollision>().Length;
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