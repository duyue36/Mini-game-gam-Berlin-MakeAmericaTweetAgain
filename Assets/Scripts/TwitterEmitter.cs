using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterEmitter : MonoBehaviour {
	public float force = 2f;
	public string[] Messages;
	public Color[] Colors;

	private Rigidbody rb;
	private bool tweeted;
	public bool IsTweeting
	{
		get { return tweeted; }
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !tweeted) 
		{
			rb.AddForce (Vector3.forward * force);
			tweeted = true;
		}
	}

	public void Reset()
	{
		tweeted = false;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		rb.velocity = Vector3.zero;
	}
}
