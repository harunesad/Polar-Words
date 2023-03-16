using UnityEngine;
using DG.Tweening;

public class SnowGlobeState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        if (words.firstGround != null && words.startGround.transform.GetChild(0).gameObject != words.firstGround)
        {
            words.firstGround.transform.parent.GetComponent<Renderer>().materials[1].color = words.firstColor;
            words.firstGround.transform.DOMoveY(-0.25f, 0.6f).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    words.words.Remove(words.firstGround.transform.parent.gameObject);
                    words.ground.transform.parent.gameObject.layer = 0;
                    words.firstGround.layer = 7;
                    words.firstGround.transform.parent.gameObject.layer = 3;
                    words.inputWord.text = "";
                    CamLook.cam.FirstPos();
                });
        }
        words.inputWord.text = "";
        CamLook.cam.FirstPos();
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
