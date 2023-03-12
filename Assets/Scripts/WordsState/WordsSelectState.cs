using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WordsSelectState : WordsBaseState
{
    CamLook camLook;
    public override void EnterState(WordsStateManager words)
    {
        camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();
    }

    public override void UpdateState(WordsStateManager words)
    {
        //if (words.finishGround.layer == 6)
        //{
        //    words.point = new Vector3(words.finishGround.transform.position.x, words.polar.transform.position.y, words.finishGround.transform.position.z);
        //    words.camLook.enabled = true;
        //    words.SwitchState(words.finishState);
        //    return;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordMask) && camLook.gameObject.transform.localEulerAngles.x == 90)
            {
                words.firstColor = hit.transform.GetComponent<Renderer>().materials[1].color;
                hit.transform.GetComponent<Renderer>().materials[1].color = words.lastColor;

                words.inputWord.text = words.inputWord.text + hit.transform.name;
                words.words.Add(hit.transform.gameObject);
                hit.transform.gameObject.layer = 9;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordSelectMask) && camLook.gameObject.transform.localEulerAngles.x == 90)
            {
                hit.transform.gameObject.layer = 3;
                hit.transform.GetComponent<Renderer>().materials[1].color = words.firstColor;

                var word = words.inputWord.text.ToCharArray();

                for (int i = 0; i < word.Length; i++)
                {
                    words.myWord.Add(word[i].ToString());
                }

                words.myWord.Remove(hit.transform.name);
                words.inputWord.text = "";

                for (int i = 0; i < words.myWord.Count; i++)
                {
                    words.inputWord.text = words.inputWord.text + words.myWord[i];
                }
                words.myWord.Clear();
                words.words.Remove(hit.transform.gameObject);
            }
        }
    }
}
