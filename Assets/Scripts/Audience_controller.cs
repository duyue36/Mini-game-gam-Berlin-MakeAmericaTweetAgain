using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience_controller : MonoBehaviour {
	public float MediaFeedTime = 2f;
	public float MediaFeedOffset = 1f;
	public float MediaMinPosition = -5f;
	public float MediaMaxPosition = 5f;
	public RadialTimer Timer;
    public string channelName;

	private IEnumerator m_Routine;
	private AudioSource WTF_sound;

	// Use this for initialization

	void Start () {
		WTF_sound = GetComponent<AudioSource> ();
		m_Routine = MoveToMedia ();
		StartCoroutine (m_Routine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MoveToMedia()
	{
		while (true) {
			yield return new WaitForSeconds (MediaFeedTime);
			Move (MediaFeedOffset);
			
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




		if(channel_color.linear == tweet_color.linear)
		{
			Move (-MediaFeedOffset * 2);
           
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trump")
        {
            Debug.Log("audience arrive at trump");
            if(this.tag == "CNN")
            {
                GameManager.Instance.CNNFailed = true;
            }
                
            if (this.tag == "NPR")
            {
                GameManager.Instance.NPRFailed = true;
            }
                
            if (this.tag == "NYT")
            {
                GameManager.Instance.NYTFailed = true;
            }
                

            Destroy(this);
        }
    }
}
