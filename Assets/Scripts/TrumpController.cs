using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpriteArray
{
	public Sprite[] Sprites;
}

public class TrumpController : MonoBehaviour {
	public static TrumpController Instance { get; private set; }

	public float force = 2f;
	public float[] ChannelPositions;
	public string[] Messages;
	public Color[] ChannelColors;
	public SpriteArray[] TweetImages;
	public int CurrentChannel;
	public Sprite CurrentTweet;
	public GameObject tweet;

	private AudioSource pushTweet_sound;

	private float offset = 1;
	//private gameObject twitterInstance;
	private Rigidbody rb_tweet;
	public Renderer renderer;

	void Awake()
	{
		Instance = this;
		pushTweet_sound = GetComponent<AudioSource> ();
	}

	void Start () {
		CurrentChannel = 1;
		renderer = GetComponent<Renderer> ();
		RandomizeTweet ();
		//InitiateTwitter ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Emitter.IsTweeting)
			return;
        */

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move (-1);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move (1);
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			InitiateTwitter ();
			rb_tweet.AddForce (Vector3.forward * force);

			pushTweet_sound.Play ();


		}


	}

	void move(int offset)
	{
		CurrentChannel += offset;
		CurrentChannel = Mathf.Clamp(CurrentChannel, 0, ChannelPositions.Length - 1);

		Vector3 position = transform.position;
		position.x = ChannelPositions [CurrentChannel];
		transform.position = position;
	}

	void InitiateTwitter()
	{
		GameObject tweetInstance = Instantiate (tweet, transform.position, transform.rotation);
		rb_tweet = tweetInstance.GetComponent<Rigidbody>();
		rb_tweet.GetComponent<Renderer> ().material.color = renderer.material.color;

		TweetNotification.Instance.Notify (CurrentTweet);

		RandomizeTweet ();
	}

	void RandomizeTweet()
	{
		int randomChannel = Random.Range (0, ChannelPositions.Length);
		renderer.material.color = ChannelColors [randomChannel];

		SpriteArray tweets = TweetImages [randomChannel];
		int randomTweet = Random.Range (0, tweets.Sprites.Length);
		CurrentTweet = tweets.Sprites [randomTweet];
	}
}
