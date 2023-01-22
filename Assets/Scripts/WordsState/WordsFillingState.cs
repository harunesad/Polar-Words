using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsFillingState : WordsBaseState
{
    int index;
    public override void EnterState(WordsStateManager words)
    {
        //CamLook.cam.SecondPos();
        GameObject hextileIce = words.words[index].transform.GetChild(1).gameObject;
        hextileIce.GetComponent<Animator>().SetTrigger("Wave");
        hextileIce.transform.DOMoveY(0.05f, 0.75f).SetEase(Ease.Linear).OnComplete(
            () => 
            {
                index++;
                if (index == words.words.Count - 1)
                {
                    words.SwitchState(words.moveState);
                }
                words.SwitchState(words.fillingState);
            });
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
