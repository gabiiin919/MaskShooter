using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マスク射出の実装
/// </summary>
public class Shooting : MonoBehaviour {
 
    public GameObject maskPrefab;
    public float shotSpeed = 3000;
    public int shotCount = 30;
    public int destroyCount = 5;
    public float reloadTime = 3.0f;
    private float reloadCount = 0.0f;
    public bool reloading = false;
    public float shootingTime = 2.0f;
    private float shootingCount = 0.0f;
    public bool shooting = false;
    [SerializeField]
    private AudioClip soundShoot;
    [SerializeField]
    private AudioSource audioSource;
 
    void Update()
    {
        if (Input.GetMouseButton(0) & shooting == false)
        {
            if (shotCount > 0)
            {
                shotCount -= 1;
                shooting = true;
                audioSource.PlayOneShot(soundShoot);
                //----------------------他人の書いたコード----------------------
                GameObject mask = (GameObject)Instantiate(maskPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody maskRigidbody = mask.GetComponent<Rigidbody>();
                maskRigidbody.AddForce(transform.forward * shotSpeed);
                Destroy(mask, destroyCount);
                //------------------------------------------------------------
            }
 
        }
            //マスクがなくなるかRを押すとリロード
            //左クリック押したままだとリロードしない
            else if (Input.GetKeyDown(KeyCode.R) || shotCount == 0 & reloading == false)
        {
            shotCount = 0;
            reloading = true;
        }
            if (reloading)
            {
                reloadCount += Time.deltaTime;
                if (reloadCount >= reloadTime)
                {
                    shotCount = 30;
                    reloadCount = 0.0f;
                    reloading = false;
                }
            }
            if (shooting)
            {
                shootingCount += Time.deltaTime;
                if (shootingCount >= shootingTime)
                {
                    shootingCount = 0.0f;
                    shooting = false;
                }
            }
    }
}