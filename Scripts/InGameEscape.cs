using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム中にEscキーを押したときのタイトル画面への遷移の実装
/// </summary>
public class InGameEscape : MonoBehaviour
{
    private GameObject playerController;

    void Start()
    {
        playerController = GameObject.Find("PlayerController");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Destroy(playerController);
            SceneManager.LoadScene ("Title");
            //タイトル画面で操作できるようにカーソルロックを解除
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
