using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class AreaTap : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform tapArea;
    [SerializeField] CircleTap circleTap;
    [SerializeField] Shoot shoot;

    public void OnPointerDown(PointerEventData eventData)
    {
        circleTap.Initialize(eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        shoot.Initialize(circleTap.range);
        circleTap.gameObject.SetActive(false);
    }


}
