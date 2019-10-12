using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FrontMove();
        DeleteThis();
    }

    void FrontMove()
    {
        this.transform.Translate(0.0f,0.2f,0.0f,Space.World);
    }

    void DeleteThis()
    {
        Vector3 thisPos = this.transform.position;
        if (thisPos.y > 5.5f) Destroy(this.gameObject);
    }
}
