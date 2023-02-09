using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Renderer m_renderer;
    [SerializeField] ParticleSystem explosionPS;
    WaitForSeconds dieTime = new WaitForSeconds(0.25f);

    IEnumerator Hide()
    {
        yield return dieTime;
        gameObject.SetActive(false);
    }

    public void ApplyDamage()
    {
        m_renderer.material.color = new Color32(255, 200, 0, 255);
        explosionPS.Play();
        StartCoroutine(Hide());

    }


}
