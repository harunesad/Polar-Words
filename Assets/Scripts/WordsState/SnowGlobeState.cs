using UnityEngine;
using DG.Tweening;

public class SnowGlobeState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        Debug.Log("a");
        if (words.firstGround != null && words.startGround.transform.GetChild(0).gameObject != words.firstGround)
        {
            words.firstGround.transform.parent.GetComponent<Renderer>().materials[1].color = words.firstColor;
            words.firstGround.transform.DOMoveY(-0.25f, 0.6f).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    words.words.Remove(words.firstGround.transform.parent.gameObject);
                    words.ground.transform.parent.gameObject.layer = 0;
                    //Button.button.skillActive = true;
                    words.firstGround.layer = 7;
                    words.firstGround.transform.parent.gameObject.layer = 3;
                    words.inputWord.text = "";
                    CamLook.cam.FirstPos();
                    return;
                    //words.words
                });
        }
        //if (words.ground != words.start && words.words.Count == 1 && !words.words.Contains(words.ground))
        //{
        //    words.inputWord.text = "";
        //    CamLook.cam.FirstPos();
        //    return;
        //}
        //if (words.ground != words.start && words.words.Count == 2 && words.words.Contains(words.ground.transform.parent.gameObject))
        //{
        //    words.inputWord.text = "";
        //    Debug.Log("ddd");
        //    CamLook.cam.FirstPos();
        //    return;
        //}
        //if (words.ground == words.start && words.words.Count == 1)
        //{
        //    words.inputWord.text = "";
        //    CamLook.cam.FirstPos();
        //    return;
        //}
        //if (words.ground != words.words[words.words.Count - 1])
        //{
        //    words.words[words.words.Count - 1].layer = 0;
        //    words.words.RemoveAt(words.words.Count - 1);
        //    words.SwitchState(words.snowGlobeState);
        //}
        words.inputWord.text = "";
        //Button.button.skillActive = true;
        CamLook.cam.FirstPos();
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
