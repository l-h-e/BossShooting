using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllre : MonoBehaviour
{
    [SerializeField] GameObject _Bullet;
    bool isAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(isAttack && Input.GetKey(KeyCode.Z))StartCoroutine(Attack());
    }

    void Move()
    {
        float dx = 0, dy = 0;
        Vector3 PlayerPosition = GetPlayerPosition();
        if (Input.GetKey(KeyCode.LeftArrow)) dx = -0.1f;
        if (Input.GetKey(KeyCode.RightArrow)) dx = 0.1f;
        if (Input.GetKey(KeyCode.UpArrow)) dy = 0.1f;
        if (Input.GetKey(KeyCode.DownArrow)) dy = -0.1f;

        float PlayerPositionX = PlayerPosition.x + dx;
        float PlayerPositionY = PlayerPosition.y + dy;

        if (PlayerPositionX > 5.0f || PlayerPositionX < -5.0f || PlayerPositionY > 5.0f || PlayerPositionY < -5.0f) return;

        this.transform.Translate(dx, dy, 0, Space.World);
    }

    IEnumerator Attack()
    {
        isAttack = false;
        Vector3 PlayerPosition = GetPlayerPosition();
        Instantiate(_Bullet,PlayerPosition,Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        isAttack = true;
    }

    Vector3 GetPlayerPosition()
    {
        return this.transform.position;
    }
}
