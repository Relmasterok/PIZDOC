using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnMENUDIED : MonoBehaviour
{
    private GameObject DIED;
    public GameObject MENU;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DIED = GameObject.FindGameObjectWithTag("MainCamera");
        if (DIED == null)
            Invoke("POS", 2f);
    }
    private void POS()
    {
        MENU.active = true;
    }
}
