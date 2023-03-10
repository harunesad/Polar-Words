using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnowGlobeState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        Debug.Log("a");
        if (words.firstGround != null && words.start != words.firstGround)
        {
            words.firstGround.transform.DOMoveY(-0.25f, 0.6f).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    words.words.Remove(words.firstGround.transform.parent.gameObject);
                    words.ground.transform.parent.gameObject.layer = 0;
                    //words.words
                });
        }
        if (words.ground != words.start && words.words.Count == 2)
        {
            words.ýnputWord.text = "";
            CamLook.cam.FirstPos();
            return;
        }
        if (words.ground == words.start && words.words.Count == 1)
        {
            words.ýnputWord.text = "";
            CamLook.cam.FirstPos();
            return;
        }
        if (words.ground != words.words[words.words.Count - 1])
        {
            words.words.RemoveAt(words.words.Count - 1);
            words.SwitchState(words.snowGlobeState);
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
