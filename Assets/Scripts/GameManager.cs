using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject Channel_CNN;
	public GameObject Channel_Fox;
	public GameObject Channel_Whatever;

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
		
	}
}
