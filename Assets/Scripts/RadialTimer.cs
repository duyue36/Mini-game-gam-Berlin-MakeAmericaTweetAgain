using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTimer : MonoBehaviour 
{
	public float Duration;
	public Text Label;
	public Image Image;

	private void Start()
	{
		Image.fillAmount = 1f;
	}

	private void Update()
	{
		float timer = Image.fillAmount;
		timer -= Time.deltaTime / Duration;
		if (timer <= 0f) 
		{
			timer += 1f;
		}

		Image.fillAmount = timer;
		Label.text = (Image.fillAmount * Duration).ToString("0.0");
	}

	public void Reset()
	{
		Image.fillAmount = 1f;
	}
}
