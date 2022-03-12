using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムドロップの実相
/// </summary>
public class ItemDrops : MonoBehaviour
{
    private Transform president;
    private float x;
    private float y;
    private float z;
    
    [SerializeField]
    private GameObject itemHeart;
    [SerializeField]
    private GameObject itemMaskBox;
    [SerializeField]
    private GameObject itemMask;

    void Update()
    {
        president = GetComponent<Transform>();
        x = president.position.x;
        //アイテムが地面に埋まらないように座標調整
        y = president.position.y + 1.2f;
        z = president.position.z;
    }

    /// <summary>
    /// ドロップ確率の関数
    /// </summary>
    public void ItemDrop()
    {
        float dropProbability = Random.Range(0.0f, 1.0f);
        if (dropProbability < 0.2f)
        {
        float itemProbability = Random.Range(0.0f, 1.0f);
            if (itemProbability < 0.2f)
            {
                Instantiate(itemHeart, new Vector3(x,y,z), itemHeart.transform.rotation); 
            }
            else if (itemProbability < 0.6f)
            {
                Instantiate(itemMaskBox, new Vector3(x,y,z), itemHeart.transform.rotation); 
            }
            else
            {
                Instantiate(itemMask, new Vector3(x,y,z), itemHeart.transform.rotation); 
            }
        }

    }

}
