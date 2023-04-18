using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float baseMoveSpeed=1;
    public float speedIncreasePerSegment;
    public float rotationSpeed = 180f;
    public GameObject snakeSegmentPrefab;
    private Vector3 moveDirection;
    private Queue<Transform> snakeSegments = new Queue<Transform>();

    private void Start()
    {
        // Заполняем очередь сегментов змейки начальными сегментами
        foreach (Transform child in transform)
        {
            snakeSegments.Enqueue(child);
        }
    }

    private void Update()
    {
       CheckCollision();
    if (Input.GetKey(KeyCode.RightArrow))
    {
        moveDirection = Vector3.right;
        Moved();
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        moveDirection = Vector3.left;
        Moved();
    }
    else if (Input.GetKey(KeyCode.UpArrow))
    {
        moveDirection = Vector3.up;
        Moved();
    }
    else if (Input.GetKey(KeyCode.DownArrow))
    {
        moveDirection = Vector3.down;
        Moved();
    }
        // Обработка ввода пользователя
       
    }

 void Moved()
{
    // Движение змейки
    Vector3 position = transform.position;
    position += moveDirection * moveSpeed * Time.fixedDeltaTime;
    position.z = 0f;
    transform.position = position;
    
    // Обновление очереди сегментов змейки
    snakeSegments.Enqueue(transform.GetChild(0));
    Transform removedSegment = snakeSegments.Dequeue();
    removedSegment.position = snakeSegments.Peek().position + snakeSegments.Peek().forward * -1f;

    // Проверка на столкновения сегментов змейки
  
    
       
    
}

private  void CheckCollision()
{
    // Проверка на столкновения сегментов змейки
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
    foreach (Collider2D collider in colliders)
    {
        if (collider.gameObject.CompareTag("SnakeSegment"))
        {
            // Обработка столкновения с сегментом змейки
            
        }
        else if (collider.gameObject.CompareTag("Food"))
        {
            // Обработка столкновения с едой
            AddSnakeSegment();
            Destroy(collider.gameObject);
            
        }
    }

   
}
 void OnTriggerEnter2D(Collider2D collider)
    {
        // Проверяем, столкнулся ли данный объект с объектом, у которого есть 2D триггер
        if (collider.gameObject.CompareTag("Food"))
        {
           AddSnakeSegment();
            Destroy(collider.gameObject);
        }
    }
private void AddSnakeSegment()
{
    // Get the position and rotation of the oldest snake segment
    Transform lastSegment = snakeSegments.Peek();
    Vector3 position = lastSegment.position;
    Quaternion rotation = lastSegment.rotation;

    // Instantiate a new segment at the end of the snake
    GameObject  newSegment = Instantiate(snakeSegmentPrefab, position, rotation);
    newSegment.transform.SetParent(transform);
    snakeSegments.Enqueue(newSegment.transform);

    // Update the snake speed based on the number of segments
    moveSpeed = baseMoveSpeed + snakeSegments.Count * speedIncreasePerSegment;
}
}