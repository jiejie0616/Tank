using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public Sprite brokenHeart;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        sr.sprite = brokenHeart;
    }
}
