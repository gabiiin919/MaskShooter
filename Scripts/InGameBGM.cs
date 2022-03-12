using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGMの実装
/// </summary>
public class InGameBGM : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundBGM;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource.PlayOneShot(soundBGM);
    }
}
