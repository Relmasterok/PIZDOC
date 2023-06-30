using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rb;
    public Joystick _joy_speed;
    public Joystick _joy_rotate;
    public float _speed;
    private float _moveHor;
    private float _moveVert;
    private float _roteHor;
    private float _roteVert;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _moveHor = _joy_speed.Horizontal;
        _moveVert = _joy_speed.Vertical;
        if (_moveHor != 0 && _moveVert != 0)
        {
            _rb.velocity = new Vector3(_moveHor * _speed, 0, _moveVert * _speed);
        }
        _roteHor = _joy_rotate.Horizontal;
        _roteVert = -_joy_rotate.Vertical;
        if (_roteVert != 0 && _roteHor != 0)
        {
            transform.Rotate(_roteVert, _roteHor, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
    }
}
