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
            //hextileIce.GetComponent<Animator>().SetTrigger("Wave");
            hextileIce.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 0.75f).SetEase(Ease.Linear);
            hextileIce.transform.DOMoveY(0.12f, 0.75f).SetEase(Ease.Linear).OnComplete(
    () =>
    {
        index++;
        if (index == words.words.Count)
        {
            Navmesh.navmesh.NavMeshSurfaces();
            index = 0;
            words.start.layer = 7;
            //GameObject fish = GameObject.Find("Fish");
            //Debug.Log(fish);
            //words.fish.gameObject.SetActive(true);
            words.SwitchState(words.moveState);
        }
        else
        {
            Navmesh.navmesh.NavMeshSurfaces();
            words.SwitchState(words.fillingState);
        }
    });
        }
        else
        {
            index++;
            words.SwitchState(words.fillingState);
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
