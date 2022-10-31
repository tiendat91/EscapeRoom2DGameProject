using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (isPaused)
        //{
        //    ResumeGame();
        //}
        //else
        //{
        //    PauseGame();
        //}
    }
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
