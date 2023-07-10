using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coin;
    public MeshCollider plane;

    public int quantityCoin;
    private float x, z;
    private int k = 0;

    Vector3 spawnPos;

    Vector3 sizeCol = new Vector3(1f, 1f, 1f);
    Vector3 center = new Vector3(0f, .5f, 0f);

    public Collider[] colliders;

    bool check;

    private void Start()
    {
        while (k < quantityCoin)
        {
            StartPos();
        }
    }

    void StartPos()
    {
        x = Random.Range(plane.transform.position.x - Random.Range(0, plane.bounds.extents.x), plane.transform.position.x + Random.Range(0, plane.bounds.extents.x));
        z = Random.Range(plane.transform.position.z - Random.Range(0, plane.bounds.extents.z), plane.transform.position.z + Random.Range(0, plane.bounds.extents.z));
        spawnPos = new Vector3(x, 1.15f, z);

        check = CheckSpawnCoin(spawnPos);
        if (check)
        {
            GameObject obj = Instantiate(coin, spawnPos, Quaternion.identity);
            k++;
        }
        else
        {
            StartPos();
        }

    }

    bool CheckSpawnCoin(Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(spawnPos, sizeCol);

        if (colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
