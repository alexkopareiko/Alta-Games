using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTap : MonoBehaviour
{
    [SerializeField] RectTransform tapArea;

    bool isAndroid = false;
    Vector2 mousePos;

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

    void ListenTouches()
    {
        Debug.Log("Clicked");
    }

    void ListenCLicks()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            if (ScreenPointContains(tapArea, mousePos))
            {
                Debug.Log("Clicked");
            }

        }
    }

    bool ScreenPointContains(RectTransform r, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(r, pos);
    }
}
