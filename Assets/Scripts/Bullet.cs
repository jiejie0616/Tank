using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 10;

    public bool isPlayerBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Heart":
                other.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Tank":
                if (!isPlayerBullet)
                {
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }              
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Wall":
                Destroy(gameObject);
                Destroy(other.gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
