using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteCam : MonoBehaviour
{
    public enum RotAxes
    { RotXY, RotY, RotX }
    public RotAxes _Axes;
    public Joystick _joy_rotate;
    private float _roteHor;
    private float _roteVert;
    public float _speedROT = 2f;
    public GameObject Player;
    void Start()
    {

    }


    void LateUpdate()
    {
        _roteHor = _joy_rotate.Horizontal * Time.deltaTime;
        _roteVert = -_joy_rotate.Vertical * Time.deltaTime;
        if (_Axes == RotAxes.RotY)
        {
            transform.Rotate(0, _roteHor * _speedROT, 0);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0f);
        }
        if (_Axes == RotAxes.RotX)
        {
            transform.Rotate(_roteVert * _speedROT, 0, 0);
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.7f, Player.transform.position.z-0.5f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Player.transform.eulerAngles.y, 0f);
        }
        if (_Axes == RotAxes.RotXY)
        {
            transform.Rotate(_roteVert * _speedROT, _roteVert * _speedROT, 0);
        }
    }
}