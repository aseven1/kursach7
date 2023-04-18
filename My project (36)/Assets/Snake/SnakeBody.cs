using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
   private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Двигаем звено тела к цели
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 0.5f);
        }
        else
        {
            // Если цели нет, уничтожаем звено тела
            Destroy(gameObject);
        }
    }
}