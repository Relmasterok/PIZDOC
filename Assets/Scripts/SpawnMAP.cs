using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMAP : MonoBehaviour
{
    public GameObject[] Prefabs;
    private float spawnPosX = 0;
    private float spawnPosY = 0;
    private float PrefSizeX = 30;
    private float PrefSizeY = 30;
    void Start()
    {
        for(int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(Prefabs[Random.Range(0, Prefabs.Length)],new Vector3(PrefSizeX*i, 0f, PrefSizeY * j), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
