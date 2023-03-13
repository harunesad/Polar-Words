using UnityEngine;
using DG.Tweening;

public class WordsFillingState : WordsBaseState
{
    int _index;
    public override void EnterState(WordsStateManager words)
    {
        GameObject ice = words.words[_index].transform.GetChild(0).gameObject;
        if (words.ground != ice && words.finishGround != ice)
        {
            ice.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 0.6f).SetEase(Ease.Linear);
            ice.transform.DOMoveY(0.12f, 0.6f).SetEase(Ease.Linear).OnComplete(
        () =>
        {
            _index++;
            if (_index == words.words.Count)
            {
                Navmesh.navmesh.NavMeshSurfaces();
                _index = 0;
                words.startGround.transform.GetChild(0).gameObject.layer = 7;
                if (UIManager.uIManager.skillActive == true)
                {
                    for (int i = words.words.Count - 1; i > 0; i--)
                    {
                        if (words.ground.transform.parent.gameObject != words.words[i])
                        {
                            words.words[i].layer = 0;
                            words.iceWords.Add(words.words[i]);
                        }
                    }
                    for (int i = words.words.Count - 1; i > 0; i--)
                    {
                        if (words.words[i] != words.ground.transform.parent.gameObject)
                        {
                            words.words.RemoveAt(i);
                        }
                    }
                }
                words.SwitchState(words.moveState);
                return;
            }
            words.SwitchState(words.fillingState);
        });
            //return;
        }
        else if (words.ground == ice || words.finishGround == ice)
        {
            _index++;
            words.SwitchState(words.fillingState);
        }
        //_index++;
        //words.SwitchState(words.fillingState);

    }

    public override void UpdateState(WordsStateManager words)
    {

    }
}
