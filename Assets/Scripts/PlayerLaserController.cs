using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    GameObject _Player;
    PlayerControllre _PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.Find("Player(Clone)");
        _PlayerScript = _Player.GetComponent<PlayerControllre>();
    }

    // Update is called once per frame
    void Update()
    {
        DeleteThis();
        Move();
    }

    void Move()
    {
        this.transform.parent = _Player.transform;
    }
    

    void DeleteThis()
    {
        if (!Input.GetKey(KeyCode.Z))
        {
            _PlayerScript.setIsAttackLaser(true);
            Destroy(this.gameObject);
        }
    }
}
