using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面と各ボタンを押したときのイベントの実装
/// </summary>
public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject titleMainPanel;
    [SerializeField]
    private GameObject titleInstructionPanel;
    [SerializeField]
    private AudioClip soundEnter;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        titleMainPanel.SetActive(true);
        titleInstructionPanel.SetActive(false);
    }

    void TitleStartButton() 
    {
        audioSource.PlayOneShot(soundEnter);
        SceneManager.LoadScene ("MainGame");
    }

    void TitleInstructonButton()
    {
        audioSource.PlayOneShot(soundEnter);
        titleMainPanel.SetActive(false);
        titleInstructionPanel.SetActive(true);
    }

    void TitleReturnButton()
    {
        audioSource.PlayOneShot(soundEnter);
        titleMainPanel.SetActive(true);
        titleInstructionPanel.SetActive(false);
        //ボタンが見た目上押しっぱになるためシーンを再ロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TitleExitButton() 
    {
        audioSource.PlayOneShot(soundEnter);
        Application.Quit();
    }
}
