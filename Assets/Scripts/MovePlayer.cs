using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MovePlayer : MonoBehaviour
{
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

    private int random;
    public List<Transform> _points = new List<Transform>();
    public GameObject _coin;
    private bool _spawnCoin = false;


    void FixedUpdate()
    {
        if (!_spawnCoin) 
        {
            
            random = Random.Range(0,_points.Count);
            Instantiate(_coin, new Vector3(_points[random].position.x, _points[random].position.y+1.5f, _points[random].position.z), Quaternion.Euler(-90,0,0));
            _points.RemoveAt(random);
            _spawnCoin = true;
        }
        _moveHor = _joy_speed.Horizontal;
        _moveVert = _joy_speed.Vertical;
        if (_moveHor !=0 || _moveVert !=0)
        {
            transform.localPosition += transform.right * _moveHor * _speed;
            transform.localPosition += transform.forward * _moveVert * _speed;
        }
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
        if (other.gameObject.tag == "Coin")
        {
            score++;
            Destroy(other.gameObject);
            _scoreTEXT.text = score.ToString();
            _spawnCoin = false;
        }
    }
}
