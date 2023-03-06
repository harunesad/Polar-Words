using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsClearGroundState : WordsBaseState
{
    int index;
    public override void EnterState(WordsStateManager words)
    {
        Debug.Log("sads");
        if (words.words[index] == words.ground.transform.parent.gameObject || words.words[index] == words.finishGround.transform.parent.gameObject)
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            index++;
            words.SwitchState(words.clearGroundState);
        }
        else
        {
            Debug.Log("sassssds");
            words.words[index].GetComponent<Renderer>().materials[1].color = words.firstColor;
            words.words[index].gameObject.layer = 3;

            words.words[index].transform.GetChild(0).gameObject.layer = 7;
            //words.words[index].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Wave");
            words.words[index].transform.GetChild(0).DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.4f).SetEase(Ease.Linear);
            words.words[index].transform.GetChild(0).DOMoveY(-0.25f, 0.4f).OnComplete(
                () =>
                {
                    Navmesh.navmesh.NavMeshSurfaces();
                    words.words.RemoveAt(index);
                    if (words.words.Count == 1 && words.ground == words.start)
                    {
                        index = 0;
                        words.�nputWord.text = "";
                        words.ground.transform.parent.gameObject.layer = 0;
                        words.finishGround.layer = 7;
                        words.camLook.FirstPos();
                        //words.SwitchState(words.selectState);
                    }
                    else if (words.words.Count == 2 && words.ground != words.start)
                    {
                        index = 0;
                        words.�nputWord.text = "";
                        words.ground.transform.parent.gameObject.layer = 0;
                        words.finishGround.layer = 7;
                        Debug.Log("dssad");
                        words.camLook.FirstPos();
                        //words.SwitchState(words.selectState);
                    }
                    else
                    {
                        words.SwitchState(words.clearGroundState);
                    }
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
