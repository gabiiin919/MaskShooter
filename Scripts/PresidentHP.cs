using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 社長のHP管理とアニメーション管理、削除の実装
/// </summary>
public class PresidentHP : MonoBehaviour {
 
    public int hitPoint = 100;  //HP
    private GameObject canvas;
    private InGameUI cp;
    private GameObject preAni;
    private Animator ani;
    private ItemDrops item;
	
    void Start() {
        canvas = GameObject.Find("UI");
        cp = canvas.GetComponent<InGameUI>();
        preAni = GameObject.Find("PresidentAnimation");
        ani = GetComponent<Animator>();
        item = GetComponent<ItemDrops>();
    }

    void Update () {
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            item.ItemDrop();
            cp.CountScore();
        }
    }
 
    public void PresidentDamage(int damage)
    {
        hitPoint -= damage;
        //ダメージ時ゆっくり歩くアニメーションへ変更
        ani.SetBool("damagedPresident", true);
    }
}
