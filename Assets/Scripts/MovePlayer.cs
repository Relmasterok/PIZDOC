using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public Joystick _joy_speed;

    public float _speed;
    private float _moveHor;
    private float _moveVert;


    public Text _scoreTEXT;
    private int score;
    private int scoreFACT = 0;

    private int random;
    public List<Transform> _points = new List<Transform>();
    public GameObject _coin;
    private bool _spawnCoin = false;
    public int died;

    private void Awake()
    {
        score = Random.Range(5, 12);
    }
    private void Start()
    {
        _scoreTEXT.text = scoreFACT.ToString() + "/" + score.ToString();
        if (PlayerPrefs.GetInt("Died") != 0) died = PlayerPrefs.GetInt("Died");
        else PlayerPrefs.SetInt("Died", died);
        if (died == 2)
        {
            ADSPokas.S.ShowAd();
            died = 0;
            PlayerPrefs.SetInt("Died", died);
        }
    }
    void FixedUpdate()
    {
        if (!_spawnCoin)
        {
            random = Random.Range(0, _points.Count);
            Instantiate(_coin, new Vector3(_points[random].position.x, _points[random].position.y + 1.5f, _points[random].position.z), Quaternion.Euler(-90, 0, 0));
            _points.RemoveAt(random);
            _spawnCoin = true;
        }
    }
    private void LateUpdate()
    {
        _moveHor = _joy_speed.Horizontal * Time.deltaTime;
        _moveVert = _joy_speed.Vertical * Time.deltaTime;
        if (_moveHor != 0 || _moveVert != 0)
        {
            transform.localPosition += transform.right * _moveHor * _speed;
            transform.localPosition += transform.forward * _moveVert * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            scoreFACT++;
            if(scoreFACT == score) Application.LoadLevel(0);
            Destroy(other.gameObject);
            _scoreTEXT.text = scoreFACT.ToString() + "/" + score.ToString();
            _spawnCoin = false;
        }
        if (other.gameObject.tag == "Finish")
        {
            Application.LoadLevel(1);
        }
    }
}
