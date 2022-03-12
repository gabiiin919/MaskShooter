using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ドロップアイテムの回転の実装
/// </summary>
public class ItemRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f));
    }
}
