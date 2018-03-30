using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManage : MonoBehaviour {
    public int lifeValue = 3;
    public int playerScore = 0;

    public bool isDead;

    private static PlayerManage instance;

    public GameObject bornEffectPrefab;

    public Text playerSocreText;
    public Text playerLifeText;

    public static PlayerManage Instance
    {
        get { return PlayerManage.instance; }
        set { PlayerManage.instance = value; }
    }

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            Recover();
        }
        playerSocreText.text = playerScore.ToString();
        playerLifeText.text = lifeValue.ToString();
	}

    public void Recover()
    {
        if (lifeValue <= 0)
        {

        }
        else
        {
            lifeValue--;
            GameObject go = GameObject.Instantiate(bornEffectPrefab, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().isCreatePlayer = true;
            isDead = false;
        }
    }
}
