using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public double counter { get; private set; }
    public bool gameIsPaused { get; private set; }
    public bool gameIsOver { get; private set; }

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform finishTrans;

    [Header("Menu")]
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject pauseMenu;

    WaitForSeconds Interval = new WaitForSeconds(0.1f);
    // where player should go
    Vector3 moveToPoint;

    private void Awake()
    {
        instance = this;
        counter = 0f;

    }

    private void Start()
    {
        TimeCountDown();
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }


    void TimeCountDown()
    {
        StartCoroutine(TimeDelay());
    }

    IEnumerator TimeDelay()
    {
        yield return Interval;
        counter += 0.1f;
        // run every 0.1 second
        EventManager.StartTick01();
        // run every second
        if (Mathf.Floor((float)counter) == (float)counter)
            EventManager.StartTick1();
        TimeCountDown();
    }

    public GameObject GetPlayer()
    {
        return playerMovement.gameObject;
    }

    public GameObject GetFinishObj()
    {
        return finishTrans.gameObject;
    }

    public void PauseGame(bool needTriggerPauseMenu = true)
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            if (needTriggerPauseMenu) pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            if (needTriggerPauseMenu) pauseMenu.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameIsOver = true;
    }

    public void MovePlayer()
    {
        playerMovement.MoveTo(finishTrans.position);
    }
}
