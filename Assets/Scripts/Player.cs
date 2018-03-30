using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 3;

    private SpriteRenderer sr;
    public Sprite[] tankSprites;

    public GameObject bulletPrefab;
    private Vector3 rotationChange;

    public float time = 0;

    public GameObject explodeEffectPrefab;
    public GameObject invincibleEffect;

    private float invincibleTime = 3.0f;
    private bool isInvincible = true;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && time > 0.4f)
        {
            Attack();
            time = 0;
        }
        time += Time.deltaTime;
        if (isInvincible)
        {
            invincibleEffect.SetActive(true);
            invincibleTime -= Time.deltaTime;
            if (invincibleTime <= 0)
            {
                isInvincible = false;
                invincibleEffect.SetActive(false);
            }
        }
	}

    void FixedUpdate()
    {
        Move();
    }

    // 坦克移动
    private void Move()
    {
        float v = Input.GetAxis("Vertical");        // 垂直
        if (v > 0)
        {
            sr.sprite = tankSprites[0];             // 上
            rotationChange = new Vector3(0, 0, 0);
        }
        else if (v < 0)                             // 下
        {
            sr.sprite = tankSprites[2];
            rotationChange = new Vector3(0, 0, 180);
            
        }
        transform.Translate(transform.up * v * Time.fixedDeltaTime * speed, Space.World);

        if (v != 0)                                 // 优先处理垂直方向移动
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");      // 水平
        transform.Translate(transform.right * h * Time.fixedDeltaTime * speed, Space.World);
        if (h > 0)
        {
            sr.sprite = tankSprites[1];             // 右
            rotationChange = new Vector3(0, 0, -90);        // 注意角度正好相反
        }
        else if (h < 0)                             // 左
        {
            sr.sprite = tankSprites[3];
            rotationChange = new Vector3(0, 0, 90);
        }
    }

    private void Attack()
    {
        GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + rotationChange));
    }

    // 死亡
    public void Die()
    {
        PlayerManage.Instance.isDead = true;
        GameObject.Instantiate(explodeEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
