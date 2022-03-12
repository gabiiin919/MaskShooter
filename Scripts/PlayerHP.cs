using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーのHP管理と削除の実装
/// </summary>
public class PlayerHP : MonoBehaviour
{
    public int hitPoint = 3;  //HP

    void Update () 
    {
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene ("Result");
            //リザルト画面で操作できるようにカーソルロックを解除
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PlayerDamage(int damage)
    {
        hitPoint -= damage;
    }
}