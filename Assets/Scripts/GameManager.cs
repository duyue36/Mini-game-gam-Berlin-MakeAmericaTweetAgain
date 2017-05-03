using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject Channel_CNN;
	public GameObject Channel_NPR;
	public GameObject Channel_NYT;
    public Text winText;

    public bool CNNFailed = false;
    public bool NPRFailed = false;
    public bool NYTFailed = false;

	static public GameManager Instance
	{ get; private set;
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
        CheckWin();
    }

    void CheckWin()
    {
        if(CNNFailed == true && NPRFailed == true && NYTFailed == true)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
