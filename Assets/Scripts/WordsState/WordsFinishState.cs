using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordsFinishState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        Debug.Log("s");
        //CamLook.cam.SecondPos();
        words.agent.SetDestination(words.point);
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Vector3.Distance(words.polar.transform.position, words.point) < 0.1f)
        {
            int levelId = SceneManager.GetActiveScene().buildIndex;
            //GameObject fish = GameObject.Find("Fish");
            int fishCount = GameObject.FindObjectsOfType<FishCollision>().Length;

            JsonSave.json.so.levelFinish[levelId].levelState = true;

            if (words.startFishCount > 0 && fishCount == 0)
            {
                JsonSave.json.so.levelFinish[JsonSave.json.so.fishLevel].fishState = true;
            }
            JsonSave.json.Save();
        }
    }
}
