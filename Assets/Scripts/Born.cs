using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {
    public GameObject playerPrefab;

    public GameObject[] enemyPrefab;
    public bool isCreatePlayer;

	// Use this for initialization
	void Start () {
        Invoke("InitPlayer", 1f);
        Destroy(gameObject, 1f);
	}

    private void InitPlayer()
    {
        if (isCreatePlayer)
        {
            GameObject.Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, enemyPrefab.Length);
            GameObject.Instantiate(enemyPrefab[num], transform.position, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
