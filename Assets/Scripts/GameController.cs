﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 PlayerInitPos = new Vector3(0.0f,-2.0f,0.0f);
        Instantiate(_Player , PlayerInitPos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
