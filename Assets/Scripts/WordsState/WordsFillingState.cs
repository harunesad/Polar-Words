using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsFillingState : WordsBaseState
{
    int index;
    public override void EnterState(WordsStateManager words)
    {
        GameObject hextileIce = words.words[index].transform.GetChild(0).gameObject;
        if (words.ground != hextileIce && words.finishGround != hextileIce)
        {
            hextileIce.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 0.4f).SetEase(Ease.Linear);
            hextileIce.transform.DOMoveY(0.12f, 0.4f).SetEase(Ease.Linear).OnComplete(
    () =>
    {
        index++;
        if (index == words.words.Count)
        {
            Navmesh.navmesh.NavMeshSurfaces();
            index = 0;
            words.start.layer = 7;
            words.SwitchState(words.moveState);
            return;
        }
        //else
        //{
        //    //Navmesh.navmesh.NavMeshSurfaces();
        //    words.SwitchState(words.fillingState);
        //}
        words.SwitchState(words.fillingState);
    });
            return;
        }
        //else
        //{
        //    index++;
        //    words.SwitchState(words.fillingState);
        //}
        index++;
        words.SwitchState(words.fillingState);
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
