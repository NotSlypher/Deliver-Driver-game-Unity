using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text score;
    public GameObject endscreen;
    public GameObject startscreen;

    private float score_Counter;
    // Start is called before the first frame update
    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void startGame()
    {
        startscreen.SetActive(false);
        Time.timeScale = 1f;
    }

    void Start()
    {
        Time.timeScale = 0f;
        startscreen.SetActive(true);
        endscreen.SetActive(false);
        StartCoroutine(endGame());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(180);
        Time.timeScale = 0f;
        endscreen.SetActive(true);
    }

}
