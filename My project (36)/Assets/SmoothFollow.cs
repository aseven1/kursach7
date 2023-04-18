using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    

    public void Load()
    {
        Application.LoadLevel("2");
    }
    public void Load3()
    {
        Application.LoadLevel("3");
    }
     public void Load2()
    {
        Application.LoadLevel("level1");
    }
    void LateUpdate()
    {
        // Новая позиция камеры
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));

        // Плавный переход к новой позиции
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}