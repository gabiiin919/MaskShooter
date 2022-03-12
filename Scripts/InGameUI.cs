using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム中のUIの実装
/// スコア、タイム、ライフ、残弾数、アイテム取得アナウンス
/// </summary>
public class InGameUI : MonoBehaviour
{
    public Text ammoText;
    private GameObject shootingAmmo;
    private Shooting shootingScript;

    public static int gameScore = 0;
    public Text scoreText;
    public Text HPText;

    private GameObject PlayerObj;
    private PlayerHP PlayerHPScript;

    private int timeCount;
    private float timeCurrent = 0.0f;
    public static string timeString;
    public Text timeText;

    [SerializeField]
    private GameObject heartAnnouncement;
    [SerializeField]
    private GameObject maskBoxAnnouncement;
    [SerializeField]
    private GameObject maskAnnouncement;
    private bool getAnnouncement = false;
    private float getAnnouncementTimeCount = 0.0f;

    void Start()
    {
        gameScore = 0;
        shootingAmmo = GameObject.Find ("Muzzle");
        shootingScript = shootingAmmo.GetComponent<Shooting>();

        PlayerObj = GameObject.Find ("PlayerController");
        PlayerHPScript = PlayerObj.GetComponent<PlayerHP>();

        heartAnnouncement.SetActive(false);
        maskBoxAnnouncement.SetActive(false);
        maskAnnouncement.SetActive(false);

    }

    void Update()
    {
        int am = shootingScript.shotCount;
        ammoText.text = am + " / 30";
        scoreText.text = "score：" + gameScore + "";

        int PlayerHP = PlayerHPScript.hitPoint;
        HPText.text = PlayerHP + "";

        timeCurrent += Time.deltaTime;
        timeCount = (int)timeCurrent;
        var ts = new TimeSpan(0, 0, 0, timeCount);
        timeString = ts.ToString() + "";
        timeText.text = timeString;

        if (getAnnouncement)
        {
            getAnnouncementTimeCount += Time.deltaTime;
            if (getAnnouncementTimeCount > 2.0f)
            {
                heartAnnouncement.SetActive(false);
                maskBoxAnnouncement.SetActive(false);
                maskAnnouncement.SetActive(false);
                getAnnouncement = false;
            }
        }
    }

    public void CountScore()
    {
        gameScore += 1;
    }

    public void GetHeartAnnouncement()
    {
        getAnnouncementTimeCount = 0.0f;
        heartAnnouncement.SetActive(true);
        maskBoxAnnouncement.SetActive(false);
        maskAnnouncement.SetActive(false);
        getAnnouncement = true;
    }

    public void GetMaskBoxAnnouncement()
    {
        getAnnouncementTimeCount = 0.0f;
        heartAnnouncement.SetActive(false);
        maskBoxAnnouncement.SetActive(true);
        maskAnnouncement.SetActive(false);
        getAnnouncement = true;
    }

    public void GetMaskAnnouncement()
    {
        getAnnouncementTimeCount = 0.0f;
        heartAnnouncement.SetActive(false);
        maskBoxAnnouncement.SetActive(false);
        maskAnnouncement.SetActive(true);
        getAnnouncement = true;
    }
}
