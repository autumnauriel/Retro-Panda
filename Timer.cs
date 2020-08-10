using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	float currentTime = 0f;
	public float startTime = 10f;

	public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
        	currentTime-=1 * Time.deltaTime;
        	print(currentTime);
        	TimerText.text = currentTime.ToString ("0");

        }

        if(currentTime>=3.5f)
        {
        	TimerText.color = Color.black;
        }

        if(currentTime<3.5f)
        {
        	TimerText.color = Color.red;
        }

        if (currentTime<=0f)
        {
        	FindObjectOfType<GameManager>().NextLevel();
        }
    }
}
