using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsFinishState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        CamLook.cam.SecondPos();
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
