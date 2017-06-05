using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRender : MonoBehaviour
{
    Renderer m_renderer;
    bool m_wasRendering = false;

    public UnityEngine.Events.UnityEvent OnVisible;
    public UnityEngine.Events.UnityEvent OnHide;

    private void Start()
    {
        m_renderer = GetComponent<Renderer>();
        StartCoroutine(_DelayedUpdate(1f));
    }

    public IEnumerator _DelayedUpdate(float delayTime)
    {
        while (Application.isPlaying)
        {

            if (m_renderer.isVisible == true && m_wasRendering == false)
            {
                OnVisible.Invoke();
            }


            else if (m_renderer.isVisible == false && m_wasRendering == true)
            {
                OnHide.Invoke();
            }

            m_wasRendering = m_renderer.isVisible;

            yield return new WaitForSeconds(1.0f);
        }
    }

}