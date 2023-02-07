using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class AreaTap : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform tapArea;
    [SerializeField] CircleTap circleTap;

    public void OnPointerDown(PointerEventData eventData)
    {
        circleTap.Initialize(eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        circleTap.gameObject.SetActive(false);
    }


}
