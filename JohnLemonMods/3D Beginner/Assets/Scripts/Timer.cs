using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 80;
    public bool timerIsRunning = false;
    public Text timeText;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;


    float m_Timer;


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out! Try Again!");
                timeRemaining = 0;
                timerIsRunning = false;
                EndLevel ();
            }
        }
    }
    void EndLevel ()
    {
        SceneManager.LoadScene (0);
    }

    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}