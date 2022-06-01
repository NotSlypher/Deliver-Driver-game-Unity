using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    public TMP_Text score;

    public float Time_Counter;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(endGame());
    }

    // Update is called once per frame
    void Update()
    {
        Time_Counter += (Time.deltaTime);
        score.text = (2 - (int)Time_Counter / 60).ToString() + ":" + (59 - (int)Time_Counter % 60).ToString();
    }

    // IEnumerator endGame()
    // {
    //     // yeild return new WaitForSeconds(60);
    // }
    
}
