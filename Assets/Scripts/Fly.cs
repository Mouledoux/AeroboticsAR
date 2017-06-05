using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField]
    private float m_maxHeight;

    [SerializeField]
    private AudioSource m_audioSource;

    [SerializeField]
    private UnityEngine.UI.Slider m_slider;

    private Vector3 m_swayPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        UnityEngine.UI.Slider.SliderEvent onSlide = new UnityEngine.UI.Slider.SliderEvent();
        onSlide.AddListener(delegate { AdjustAllValuesToSlider(); });
        m_slider.onValueChanged = onSlide;

        AdjustAllValuesToSlider();
    }

    void Update()
    {

    }

    private void AdjustAllValuesToSlider()
    {
        float height = (m_maxHeight * ((m_slider.value - m_slider.minValue) / m_slider.maxValue));
        transform.localPosition = new Vector3(0, height, 0);
        GetComponent<Animator>().speed = m_slider.value * 5;
        m_audioSource.pitch = 1 + (height / m_maxHeight);
    }

    public void ResetAllValues()
    {
        transform.localPosition = Vector3.zero;
        GetComponent<Animator>().speed = 1;
        m_audioSource.pitch = 1;
    }

    private void SetAnimationToSlider()
    {
        GetComponent<Animator>().speed = m_slider.value;
    }    
}
