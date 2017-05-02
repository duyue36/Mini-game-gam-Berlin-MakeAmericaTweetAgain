using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetNotification : MonoBehaviour 
{
	public static TweetNotification Instance { get; private set; }

	public CanvasGroup CanvasGroup;
	public float Duration;
	public float FadeDuration;
	public Image Image;

	private float m_Timestamp;

	private void Awake()
	{
		Instance = this;	
		m_Timestamp = -1f;
	}

	private void Update()
	{
		if (m_Timestamp < 0f)
			return;

		float elapsed = Time.time - m_Timestamp;
		if (elapsed > Duration) 
		{
			float lerp = (elapsed - Duration) / FadeDuration;

			CanvasGroup.alpha = 1f - lerp;
		}
	}

	public void Notify(Sprite sprite)
	{
		if (Instance == null)
			return;

		m_Timestamp = Time.time;
		Image.sprite = sprite;

		CanvasGroup.alpha = 1f;
	}
}
