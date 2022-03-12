using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マスク残量によるマスク箱の見た目変化の実装
/// </summary>
public class ChangeMaskBox : MonoBehaviour
{
    public GameObject full;
    public GameObject half;
    public GameObject empty;

    private GameObject shootingMask;
    private Shooting shootingScript;
    private int mask;

    void Start()
    {
        half.SetActive(false);
        empty.SetActive(false);
        shootingMask = GameObject.Find ("Muzzle");
        shootingScript = shootingMask.GetComponent<Shooting>();
    }

    void Update()
    {
        mask = shootingScript.shotCount;
        if (mask >= 20)
        {
            full.SetActive(true);
            half.SetActive(false);
            empty.SetActive(false);

        }
        else if (mask >= 10)
        {
            full.SetActive(false);
            half.SetActive(true);
            empty.SetActive(false);
        }
        else
        {
            full.SetActive(false);
            half.SetActive(false);
            empty.SetActive(true);
        }
    }
}
