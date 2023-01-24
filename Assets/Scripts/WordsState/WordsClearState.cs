using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsClearState : WordsBaseState
{
    CamLook camLook;
    int index;
    public override void EnterState(WordsStateManager words)
    {
        camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();

        if (words.words.Count == 1)
        {
            index = 0;
            words.ýnputWord.text = "";
            words.ground.transform.parent.gameObject.layer = 0;
            words.finishGround.layer = 7;
            camLook.enabled = true;
        }
        if (words.words[index].transform.GetChild(1).gameObject == words.ground)
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            index++;
            words.SwitchState(words.clearState);
        }
        else
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            words.words[index].gameObject.layer = 3;

            words.words[index].transform.GetChild(1).gameObject.layer = 7;
            words.words[index].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Wave");
            words.words[index].transform.GetChild(1).DOMoveY(-0.25f, 1).OnComplete(
                () =>
                {
                    Navmesh.navmesh.NavmeshSurface();
                    words.words.RemoveAt(index);
                    words.SwitchState(words.clearState);
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
