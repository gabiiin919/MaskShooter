using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーと社長の衝突イベントの実装
/// </summary>
public class PlayerCollided : MonoBehaviour 
{
    [SerializeField]
    private int damage;
    private PlayerHP playerHP;
    [SerializeField]
    private AudioClip soundDamage;
    [SerializeField]
    private AudioSource audioSource;
 
    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
    }

    /// <summary>
    /// Presidentと衝突時にPlayerHPクラスのPlayerDamage関数を呼び出す
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("President"))
        {
            audioSource.PlayOneShot(soundDamage);
            playerHP.PlayerDamage(damage);
            Destroy(other.gameObject);
        }
    }
}