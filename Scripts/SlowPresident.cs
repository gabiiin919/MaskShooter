using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 社長のスロウアニメーションへの変更の実装
/// </summary>
public class SlowPresident : MonoBehaviour {
    
    private GameObject presidentAnimation;
    private Animator animator;
    private float slowCount = 0.0f;
    public float slowTime = 1.0f; 

    void Start()
    {
        presidentAnimation = GameObject.Find("PresidentAnimation");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetBool("damagedPresident"))
        {
            slowCount += Time.deltaTime;
            if (slowCount >= slowTime)
            {
                animator.SetBool("damagedPresident", false);
                slowCount = 0.0f;
            }
        }
    }
}
