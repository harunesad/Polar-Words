using UnityEngine;
using UnityEngine.SceneManagement;

public class WordsFinishState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        words.agent.SetDestination(words.point);
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Vector3.Distance(words.polar.transform.position, words.point) < 0.1f)
        {
            int levelId = SceneManager.GetActiveScene().buildIndex;
            int fishCount = GameObject.FindObjectsOfType<Collisions.FishCollision>().Length;

            Json.JsonSave.json.so.levelFinish[levelId].levelState = true;

            if (words.startFishCount > 0 && fishCount == 0)
            {
                Json.JsonSave.json.so.levelFinish[Json.JsonSave.json.so.fishLevel].fishState = true;
            }
            Json.JsonSave.json.Save();
        }
    }
}
