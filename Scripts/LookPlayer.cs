using UnityEngine;

/// <summary>
/// 社長がプレイヤーに向かう機能の実装
/// </summary>
public class LookPlayer : MonoBehaviour
{
    private GameObject lookTarget;
 
    void Start()
    {
        lookTarget = GameObject.Find("PlayerController");
    }

    //----------------------他人の書いたコード----------------------
    void Update()
    {
        var direction = lookTarget.transform.position - transform.position;
        //y座標を０にすることで社長が上下をむかないようにする
        direction.y = 0;
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.3f);
    }
    //------------------------------------------------------------
}