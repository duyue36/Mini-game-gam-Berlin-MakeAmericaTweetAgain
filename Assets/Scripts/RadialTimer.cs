using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTimer : MonoBehaviour 
{
	public float Duration;
	public Text Label;
	public Image Image_timer;
    public Image Image_title;

    private void Start()
	{

        Image_timer.fillAmount = 1f;
	}

	private void Update()
	{
		float timer = Image_timer.fillAmount;
		timer -= Time.deltaTime / Duration;
		if (timer <= 0f) 
		{
			timer += 1f;
		}

		Image_timer.fillAmount = timer;
		Label.text = (Image_timer.fillAmount * Duration).ToString("0.0");
	}

	public void Reset()
	{
		Image_timer.fillAmount = 1f;
	}
}
