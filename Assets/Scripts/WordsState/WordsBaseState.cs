using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WordsBaseState
{
    public abstract void EnterState(WordsStateManager words);
    public abstract void UpdateState(WordsStateManager words);
}
