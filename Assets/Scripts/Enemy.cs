﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3;

    private SpriteRenderer sr;
    public Sprite[] tankSprites;

    public GameObject bulletPrefab;
    private Vector3 rotationChange = new Vector3(0, 0, 0);

    public float time = 0;

    public GameObject explodeEffectPrefab;

    //计时器
    private float timeVal;
    private float timeValChangeDirection;

    private float v;
    private float h;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //攻击的时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {

        //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + rotationChange));
        timeVal = 0;

    }


    //坦克的移动方法
    private void Move()
    {

        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }




        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprites[2];
            rotationChange = new Vector3(0, 0, -180);
        }

        else if (v > 0)
        {
            sr.sprite = tankSprites[0];
            rotationChange = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }


        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprites[3];
            rotationChange = new Vector3(0, 0, 90);
        }

        else if (h > 0)
        {
            sr.sprite = tankSprites[1];
            rotationChange = new Vector3(0, 0, -90);
        }
    }

    //坦克的死亡方法
    private void Die()
    {
        //产生爆炸特效
        Instantiate(explodeEffectPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 4;
        }
    }
}
