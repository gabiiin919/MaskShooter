using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルト画面と各ボタンを押したときのイベントの実装
/// </summary>
public class Result : MonoBehaviour
{
    public Text resultScore;
    public Text resultTime;
    [SerializeField]
    private AudioClip soundEnter;
    [SerializeField]
    private AudioSource audioSource;
    
    private GameObject inGameUI;

    void Start()
    {
        resultScore.text = "Score: " + InGameUI.gameScore;
        resultTime.text = "Time: " + InGameUI.timeString;
    }

    public void ResultTitleButton() 
    {
        audioSource.PlayOneShot(soundEnter);
        SceneManager.LoadScene ("Title");
    }

    public void ResultRetryButton() 
    {
        audioSource.PlayOneShot(soundEnter);
        SceneManager.LoadScene ("MainGame");
    }

    public void ResultExitButton() 
    {
        audioSource.PlayOneShot(soundEnter);
        Application.Quit();
    }

}
