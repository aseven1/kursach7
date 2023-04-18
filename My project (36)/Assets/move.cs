using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move : MonoBehaviour
{
    public float speed = 50.0f;
    public Transform objectTransform;
    public GameObject prefabToSpawn;
    public float ySpawnOffset = 400f;
    public float xSpawnRange = 10f;
    bool left,right,up;
    public float minImpulseForce = 1f;
    public float maxImpulseForce = 5f;
     
    public float startingHP = 100f;
    public Slider healthSlider;

    private float currentHP;
     
    void Start()
    {
        Invoke("Relod",1f);
         currentHP = startingHP;
        healthSlider.maxValue = startingHP;
        healthSlider.value = currentHP;
    }

 void OnTriggerEnter(Collider collider)
    {
        
        // Проверяем, столкнулся ли данный объект с объектом, у которого есть 2D триггер
        if (collider.gameObject.CompareTag("meteor"))
        {

            currentHP -= 10f;
            healthSlider.value = currentHP;
          
        }
    }
 void OnCollisionEnter(Collision collision)
    {
        Debug.Log('+');
        if (collision.gameObject.tag == "meteor")
        {
            currentHP -= 10f;
            healthSlider.value = currentHP;
        }
    }
    void Relod()
    {
        // Определяем позицию спавна
        Vector3 spawnPos = new Vector3(transform.position.x+Random.Range(-xSpawnRange, xSpawnRange), transform.position.y + ySpawnOffset, transform.position.z);

        // Создаем префаб
        GameObject newObject = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        // Добавляем импульс вниз
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float impulseForce = Random.Range(minImpulseForce, maxImpulseForce);
            rb.AddForce(Vector2.down * impulseForce, ForceMode2D.Impulse);
        }
        Invoke("Relod",1f);
    }

    public void Left()
    {
        left=true;
        right=false;
        up=false;
    }
    public void Right()
    {
        left=false;
        right=true;
        up=false;
    }
    public void UP()
    {
        left=false;
        right=false;
        up=true;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            objectTransform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
             objectTransform.position +=Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
              objectTransform.position+= Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
             objectTransform.position+= Vector3.right * speed * Time.deltaTime;
        }
        ///////////
         if (up)
        {
            objectTransform.position += Vector3.up * speed * Time.deltaTime;
        }

        

        if (left)
        {
              objectTransform.position+= Vector3.left * speed * Time.deltaTime;
        }

        if (right)
        {
             objectTransform.position+= Vector3.right * speed * Time.deltaTime;
        }
    }
}