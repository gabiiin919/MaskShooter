using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム取得イベントの実装
/// </summary>
public class PlayerPickUpItems : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject muzzle;
    private Shooting  shooting;
    private GameObject ui;
    private InGameUI inGameUI;
    [SerializeField]
    private AudioClip soundPickUp;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
        muzzle = GameObject.Find("Muzzle");
        shooting = muzzle.GetComponent<Shooting>();
        ui = GameObject.Find("UI");
        inGameUI = ui.GetComponent<InGameUI>();
    }

    public void PickUpHeart()
    {
        audioSource.PlayOneShot(soundPickUp);
        playerHP.hitPoint = 3;
    }
    public void PickUpMaskBox()
    {
        audioSource.PlayOneShot(soundPickUp);
        //現在のリロード時間が1秒以上なら0.8倍
        if (shooting.reloadTime >= 1.0f)
        {
            shooting.reloadTime *= 0.8f;
        }
    }
    public void PickUpMask()
    {
        audioSource.PlayOneShot(soundPickUp);
        //現在の射撃間隔が0.2秒以上なら0.8倍
        if (shooting.shootingTime >= 0.2f)
        {
            shooting.shootingTime *= 0.8f;
        }
    }

    /// <summary>
    /// アイテムと衝突時の関数呼び出し
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemHeart"))
        {
            PickUpHeart();
            inGameUI.GetHeartAnnouncement();
        }
        else if (other.CompareTag("ItemMaskBox"))
        {
            PickUpMaskBox();
            inGameUI.GetMaskBoxAnnouncement();
        }
        else if (other.CompareTag("ItemMask"))
        {
            PickUpMask();
            inGameUI.GetMaskAnnouncement();
        }
        Destroy(other.gameObject);
    }
}
