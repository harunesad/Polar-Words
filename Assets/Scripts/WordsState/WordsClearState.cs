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

        //Debug.Log(words.ground.name);
        //Debug.Log(words.words[0].transform.GetChild(1).name);
        if (words.words.Count == 1)
        {
            //words.SwitchState(words.selectState);
            Debug.Log("sss");
            index = 0;
            words.�nputWord.text = "";
            words.ground.transform.parent.gameObject.layer = 0;
            words.finishGround.layer = 7;
            camLook.enabled = true;
        }
        if (words.words[index].transform.GetChild(1).gameObject == words.ground)
        {
            Debug.Log(words.ground.name);
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            index++;
            //words.words.RemoveAt(0);
            words.SwitchState(words.clearState);
            //return;
        }
        else
        {
            words.words[index].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            words.words[index].gameObject.layer = 3;

            words.words[index].transform.GetChild(1).gameObject.layer = 7;
            words.words[index].transform.GetChild(1).DOMoveY(-0.25f, 1).OnComplete(
                () =>
                {
                    //words.words[0].layer = 7;
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
