using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsClearState : WordsBaseState
{
    int index;
    public override void EnterState(WordsStateManager words)
    {
        if (words.words[index] == words.ground.transform.parent.gameObject || words.words[index] == words.finishGround.transform.parent.gameObject)
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            index++;
            words.SwitchState(words.clearState);
        }
        else
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            words.words[index].gameObject.layer = 3;

            words.words[index].transform.GetChild(0).gameObject.layer = 7;
            words.words[index].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Wave");
            words.words[index].transform.GetChild(0).DOMoveY(-0.25f, 1).OnComplete(
                () =>
                {
                    Navmesh.navmesh.NavMeshSurfaces();
                    words.words.RemoveAt(index);
                    if (words.words.Count == 2)
                    {
                        index = 0;
                        words.ýnputWord.text = "";
                        words.ground.transform.parent.gameObject.layer = 0;
                        words.finishGround.layer = 7;
                        words.SwitchState(words.selectState);
                    }
                    else
                    {
                        words.SwitchState(words.clearState);
                    }
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
