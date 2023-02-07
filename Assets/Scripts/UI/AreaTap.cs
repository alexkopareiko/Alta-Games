using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AreaTap : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform tapArea;
    [SerializeField] CircleTap circleTap;
    [SerializeField] Shoot shoot;
    [SerializeField] Player player;

    public void OnPointerDown(PointerEventData eventData)
    {
        circleTap.Initialize(eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        player.SetScale(circleTap.range);
        circleTap.gameObject.SetActive(false);
    }


}
