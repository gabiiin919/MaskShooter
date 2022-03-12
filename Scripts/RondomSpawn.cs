using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 社長の範囲内ランダムスポーンの実装
/// </summary>
public class RondomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject createPrefab;
    [SerializeField]
    private Transform spawnCoord1;
    [SerializeField]
    private Transform spawnCoord2;

    public float spawnCool = 4.0f;
    private float spawnCoolCount = 0.0f;

    public float spawnAcceleration = 60.0f;
    private float spawnAccelerationCount = 0.0f;

    void Update()
    {
        spawnCoolCount += Time.deltaTime;
        spawnAccelerationCount += Time.deltaTime;

        if (spawnCoolCount > spawnCool)
		{
            float x = Random.Range(spawnCoord1.position.x, spawnCoord2.position.x);
            float y = Random.Range(spawnCoord1.position.y, spawnCoord2.position.y);
            float z = Random.Range(spawnCoord1.position.z, spawnCoord2.position.z);
            Instantiate(createPrefab, new Vector3(x,y,z), createPrefab.transform.rotation);
            spawnCoolCount = 0f;
        }

        //60秒ごとにspawnCoolが短くなっていく
        if (spawnAccelerationCount > spawnAcceleration)
        {
            if (spawnCool > 1)
            {
            spawnCool -= 0.5f;
            }
            spawnAccelerationCount = 0f;
        }
    }
}