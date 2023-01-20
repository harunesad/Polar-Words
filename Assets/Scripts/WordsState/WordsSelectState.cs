using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordsSelectState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.mask))
            {
                if (hit.transform.GetComponent<Renderer>().material.color == new Color(1,1,1,1))
                {
                    hit.transform.GetComponent<Renderer>().material.color = Color.green;

                    Transform canvas = hit.transform.GetChild(0);
                    TextMeshProUGUI letter = canvas.GetChild(0).GetComponent<TextMeshProUGUI>();
                    words.ýnputWord.text = words.ýnputWord.text + letter.text;

                    words.words.Add(hit.transform.gameObject);
                }
            }
        }
        if (words.ýnputWord.text == words.keyWord)
        {
            words.SwitchState(words.fillingState);
        }
    }
}
