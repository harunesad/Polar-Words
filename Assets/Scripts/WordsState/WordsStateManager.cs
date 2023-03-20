using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class WordsStateManager : MonoBehaviour
{
    public static WordsStateManager wordsState;
    public LayerMask wordMask, groundMask, wordSelectMask;
    public TextMeshProUGUI inputWord;
    public List<GameObject> words;
    public List<GameObject> iceWords;
    public List<string> myWord;
    public GameObject ground;
    public GameObject finishGround;
    public GameObject snowEffect;
    public NavMeshAgent agent;
    public Vector3 point;
    public GameObject polar;
    public GameObject startGround;
    public GameObject firstGround;
    public CamLook camLook;
    public Color firstColor;
    public Color lastColor;
    public int startFishCount;

    public WordsBaseState currentState;
    public readonly WordsSelectState selectState = new WordsSelectState();
    public readonly WordsFillingState fillingState = new WordsFillingState();
    public readonly CharacterMoveState moveState = new CharacterMoveState();
    public readonly WordsClearState clearState = new WordsClearState();
    public readonly WordsFinishState finishState = new WordsFinishState();
    public readonly WordsClearGroundState clearGroundState = new WordsClearGroundState();
    public readonly SnowGlobeState snowGlobeState = new SnowGlobeState();
    private void Awake()
    {
        wordsState = this;
        words.Add(finishGround.transform.parent.gameObject);
        startFishCount = FindObjectsOfType<Collisions.FishCollision>().Length;
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