using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllre : MonoBehaviour
{
    [SerializeField]private GameObject _Bullet;
    [SerializeField]private GameObject _Laser;
    private GameObject _Pre;
    bool isAttack = true;
    private bool isAttackLaser = true;
    uint Mode = 0b_00; //攻撃モード 左からレーザー　速射


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isAttack)
        {
            if((Mode & 1 << 1) >= 1)
            {
                if (Input.GetKey(KeyCode.Z) && isAttackLaser == true) AttackLaser();
            }
            else
            {
                if (Input.GetKey(KeyCode.Z)) StartCoroutine(Attack());
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Mode += 1;
            if ((Mode & 1 << 0)>=1 && (Mode & 1 << 1)>=1) Mode++;
        }
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
        float speed = 1.0f;
        Vector3 PlayerPosition = GetPlayerPosition();
        _Pre = _Bullet;
        Debug.Log("Mode:"+ Mode + " Mode & 1<<0:" + (Mode & 1<<0) + " Mode & 1<<1:" + (Mode & 1<<1));
        if ((Mode & 1<<0) >= 1) {
            speed = 0.5f;
        }
        Instantiate(_Pre, PlayerPosition, Quaternion.identity);
        yield return new WaitForSeconds(0.1f * speed);
        isAttack = true;
    }

    void AttackLaser()
    {
        Vector3 PlayerPosition = GetPlayerPosition();
        _Pre = _Laser;
        for (int i = 0; i < 10; i++)
        {
            Vector3 LaserPos = new Vector3(0.0f, 1.0f + i, 0.0f);
            Instantiate(_Pre, PlayerPosition + LaserPos, Quaternion.identity);
        }
        isAttackLaser = false;
    }

    Vector3 GetPlayerPosition()
    {
        return this.transform.position;
    }

    public void setIsAttackLaser(bool t)
    {
        isAttackLaser = t;
    }
}
