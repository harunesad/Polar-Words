using UnityEngine;

public class WordsSelectState : WordsBaseState
{
    CamLook _camLook;
    public override void EnterState(WordsStateManager words)
    {
        _camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();
    }

    public override void UpdateState(WordsStateManager words)
    {
        //if (words.finishGround.layer == 6)
        //{
        //    words.point = new Vector3(words.finishGround.transform.position.x, words.polar.transform.position.y, words.finishGround.transform.position.z);
        //    words._camLook.enabled = true;
        //    words.SwitchState(words.finishState);
        //    return;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordMask) && (int)_camLook.gameObject.transform.localEulerAngles.x == 90)
            {
                words.firstColor = hit.transform.GetComponent<Renderer>().materials[1].color;
                hit.transform.GetComponent<Renderer>().materials[1].color = words.lastColor;

                words.inputWord.text = words.inputWord.text + hit.transform.name;
                words.words.Add(hit.transform.gameObject);
                hit.transform.gameObject.layer = 9;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordSelectMask) && (int)_camLook.gameObject.transform.localEulerAngles.x == 90)
            {
                hit.transform.gameObject.layer = 3;
                hit.transform.GetComponent<Renderer>().materials[1].color = words.firstColor;

                var word = words.inputWord.text.ToCharArray();

                foreach (var letters in word)
                {
                    words.myWord.Add(letters.ToString());
                }
                /*
                for (int i = 0; i < word.Length; i++)
                {
                    words.myWord.Add(word[i].ToString());
                }
                */

                words.myWord.Remove(hit.transform.name);
                words.inputWord.text = "";

                foreach (var myWord in words.myWord)
                {
                    words.inputWord.text = words.inputWord.text + myWord;
                }
                /*
                for (int i = 0; i < words.myWord.Count; i++)
                {
                    words.inputWord.text = words.inputWord.text + words.myWord[i];
                }
                */
                words.myWord.Clear();
                words.words.Remove(hit.transform.gameObject);
            }
        }
    }
}
