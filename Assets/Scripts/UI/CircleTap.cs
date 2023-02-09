using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleTap : MonoBehaviour
{
    public float range { get; private set; }

    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image m_image;
    [SerializeField] float maxWidth = 300f;
    bool increment = true;
    Vector2 maxSize;
    const float minScale = 0.05f;

    private void Update()
    {
        if(increment)
        {
            range += Time.deltaTime;
            if (range >= 1f) increment = false;
        } 
        else
        {
            range -= Time.deltaTime;
            if (range <= minScale) increment = true;
        }

        rectTransform.sizeDelta = maxSize * range;
        m_image.color = new Color32(255, (byte)(255 - range * 240), 0, 255);
    }

   


    public void Initialize(Vector3 _pos)
    {
        rectTransform.position = _pos;
        increment = true;

        rectTransform.sizeDelta = new Vector2(maxWidth * minScale, maxWidth * minScale);
        maxSize = new Vector2(maxWidth, maxWidth);

        range = 0.2f;

        gameObject.SetActive(true);
    }
}
