using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public double counter { get; private set; }

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform finishTrans;
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

    public void MovePlayer()
    {
        playerMovement.MoveTo(finishTrans.position);
    }
}
