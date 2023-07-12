using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnV2 : MonoBehaviour
{
    private GameObject[] _points;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        _points = GameObject.FindGameObjectsWithTag("Points");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
