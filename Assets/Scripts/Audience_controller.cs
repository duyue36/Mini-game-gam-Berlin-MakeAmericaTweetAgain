using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_controller : MonoBehaviour {
	public float MediaFeedTime = 2f;
	public float MediaFeedOffset = 1f;
	public float MediaMinPosition = -5f;
	public float MediaMaxPosition = 5f;
	public RadialTimer Timer;

	private IEnumerator m_Routine;
	private AudioSource WTF_sound;

	// Use this for initialization

	void Start () {
		WTF_sound = GetComponent<AudioSource> ();
		m_Routine = MoveToCNN ();
		StartCoroutine (m_Routine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MoveToCNN()
	{
		while (true) {
			yield return new WaitForSeconds (MediaFeedTime);
			Move (MediaFeedOffset);
			yield return null;
		}

	}

	void Move(float offset)
	{
		Vector3 position = transform.position;
		position.z += offset;
		position.z = Mathf.Clamp (position.z, MediaMinPosition * transform.localScale.x, 
			MediaMaxPosition * transform.localScale.x);

		transform.position = position;
	}

	void OnCollisionEnter(Collision collision)
	{
		Color channel_color;
		channel_color = transform.parent.GetComponent<Renderer> ().material.color;

		Color tweet_color;
		tweet_color = collision.gameObject.GetComponent<Renderer> ().material.color;




		if(channel_color == tweet_color)
		{
			Move (-MediaFeedOffset);
			Timer.Reset ();
			StopCoroutine (m_Routine);
			StartCoroutine (m_Routine);
		} 
		else 
		{
			Punish();
		}

		Destroy (collision.gameObject);

	}

	void Punish()
	{
		WTFNotification.Instance.Notify ();
		WTF_sound.Play ();
	}
}
