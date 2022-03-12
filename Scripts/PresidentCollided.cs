using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// 社長とマスクの衝突イベントの実装
/// </summary>
public class PresidentCollided : MonoBehaviour 
{
    [SerializeField]
    private int damage;
    private GameObject president;
    private PresidentHP presidentHP;

    void Start()
    {
        president = transform.parent.gameObject;
        presidentHP = president.GetComponent<PresidentHP>();
    }
 

    /// <summary>
    /// BulletMaskと衝突時にPresidentHPクラスのPresidentDamage関数を呼び出す
    /// </summary>
    void OnTriggerEnter(Collider other){
 
        if (other.CompareTag("BulletMask"))
        {
            presidentHP.PresidentDamage(damage);
            Destroy(other.gameObject);
        }
    }
}