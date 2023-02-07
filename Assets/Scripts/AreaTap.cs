using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AreaTap : MonoBehaviour
{
    [SerializeField] RectTransform tapArea;

    bool isAndroid = false;
    bool isClicked = false;
    Vector2 mousePos;


    void OnEnable()
    {
        EventManager.Tick1 += Tick;
    }

    void OnDisable()
    {
        EventManager.Tick1 -= Tick;
    }

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            isAndroid = true;
        }
    }

    private void Update()
    {
        if (isAndroid) ListenTouches();
        else ListenCLicks();
    }

    // execute 1 second
    void Tick(float _tick)
    {
        isClicked = false;
    }

    void OnTap()
    {
        isClicked = true;
        GameManager.instance.MovePlayer();
    }

    void ListenTouches()
    {
        if (isClicked) return;
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                Vector2 touchePos = touch.position;
                if (ScreenPointContains(tapArea, touchePos))
                {
                    OnTap();
                }
            }
        }
    }

    void ListenCLicks()
    {
        if (Input.GetMouseButton(0))
        {
            if (isClicked) return;
            mousePos = Input.mousePosition;
            if (ScreenPointContains(tapArea, mousePos))
            {
                OnTap();
            }

        }
    }

    bool ScreenPointContains(RectTransform r, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(r, pos);
    }
}
