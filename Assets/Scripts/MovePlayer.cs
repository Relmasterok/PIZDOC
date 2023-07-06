using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

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
    public float _speedROT;

    public Text _scoreTEXT;
    private int score;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _moveHor = _joy_speed.Horizontal;
        _moveVert = _joy_speed.Vertical;
        if (_moveVert > 0) transform.localPosition += transform.right * _moveHor * _speed;
        if (_moveVert < 0) transform.localPosition += transform.right * _moveHor * _speed;
        if (_moveHor > 0) transform.localPosition += transform.forward * _moveVert * _speed;
        if (_moveHor < 0) transform.localPosition += transform.forward * _moveVert * _speed;
        //if (_moveHor != 0 || _moveVert != 0)
        //{
        //    transform.localPosition += transform.forward * _moveHor *_speed;
        //    transform.localPosition += transform.right * _moveVert *_speed;
        //    //_rb.velocity = new Vector3(_moveHor * _speed, 0, _moveVert * _speed);
        //}
        _roteHor = _joy_rotate.Horizontal;
        _roteVert = -_joy_rotate.Vertical;
        if (_roteVert != 0 || _roteHor != 0)
        {
            transform.Rotate(_roteVert*_speedROT, _roteHor*_speedROT, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poison")
        {
            score++;
            other.gameObject.SetActive(false);
            _scoreTEXT.text = score.ToString();
        }
    }
}
