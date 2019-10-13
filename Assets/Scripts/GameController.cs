using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]private GameObject _Player;
    [SerializeField] private GameObject _Boss;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 PlayerInitPos = new Vector3(0.0f,-2.0f,0.0f);
        Instantiate(_Player , PlayerInitPos,Quaternion.identity);
        Vector3 BossInitPos = new Vector3(0.0f, 3.0f, 0.0f);
        Instantiate(_Boss, BossInitPos, Quaternion.identity);
        _Boss.transform.Rotate(0, 0, 180.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
