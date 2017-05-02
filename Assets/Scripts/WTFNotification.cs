using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WTFNotification : MonoBehaviour 
{
	public static WTFNotification Instance { get; private set; }

	public CanvasGroup CanvasGroup;
	public float Duration;
	public float FadeDuration;

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

	public void Notify()
	{
		if (Instance == null)
			return;

		m_Timestamp = Time.time;

		CanvasGroup.alpha = 1f;
	}
}
