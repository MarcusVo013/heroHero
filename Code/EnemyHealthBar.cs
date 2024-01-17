using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Camera camera;
    [SerializeField] private Transform tg;
    [SerializeField] private Vector3 offset;
    public void UpdateHealthBar(float currentVal, float maxVal)
    {
        slider.value = currentVal/ maxVal;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.rotation = camera.transform.rotation;
        transform.position = tg.position + offset;
    }
}
