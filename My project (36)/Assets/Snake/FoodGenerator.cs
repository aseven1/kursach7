using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodGenerator : MonoBehaviour
{
   public Transform levelBounds;
    public Text Text;
    public float spawnInterval = 5f;
    public GameObject foodPrefab;
    public string[] foodPrefabNames;
    public int level;
    
    public Text Textl;
    private float timer;
    private string[] equationParts;

    void Start()
    {
        string equation = generateEquation();
        Debug.Log("Generated equation: " + equation);
        Text.text=equation;
       
    }

void StartSpawn()
    {
        string equation = generateEquation();
        Debug.Log("Generated equation: " + equation);
        Text.text=equation;
        
   
    }
    void Update()
    {
       if(GameObject.FindGameObjectsWithTag("food").Length==0)
       {
           level++;
           Textl.text=level.ToString();
    GameObject[] notFoodObjects = GameObject.FindGameObjectsWithTag("notfood");
    foreach (GameObject obj in notFoodObjects)
    {
        Destroy(obj);
    }
            StartSpawn();
       }

       
    }

    
private string generateEquation()
{
     int num1 = Random.Range(1, 11); // случайное число от 1 до 10
    int num2 = Random.Range(1, 11); // случайное число от 1 до 10
    int operation = Random.Range(1, 4); // случайный знак операции: 1 - сложение, 2 - вычитание, 3 - умножение
    int result = 0;

    // Генерация уравнения
    string equationString = "";
    switch (operation)
    {
        case 1:
            equationString = num1.ToString() + " + " + num2.ToString() + " = ";
            result = num1 + num2;
            break;
        case 2:
            equationString = num1.ToString() + " - " + num2.ToString() + " = ";
            result = num1 - num2;
            break;
        case 3:
            equationString = num1.ToString() + " * " + num2.ToString() + " = ";
            result = num1 * num2;
            break;
    }

    // Создание префаба с именем уравнения разбитого на части
    string[] equationParts = equationString.Split(' ');
    for (int i = 0; i < equationParts.Length; i++)
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(0, 25), transform.position.y + Random.Range(-5f, 5f), 0f);
        GameObject foodObject;
        //if (equationParts[i].Length>1)
        {
            
        
            foodObject = Instantiate(foodPrefab, spawnPos, Quaternion.identity);
            foodObject.tag = "food";
            foodObject.name = equationParts[i];
        }
      
    }

    Debug.Log(equationString);
    // Создание знака операции, если он не был использован в уравнении
    if (!equationString.Contains(" + "))
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(0, 25), transform.position.y + Random.Range(-5f, 5f), 0f);
        GameObject foodObject1 = Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        foodObject1.tag = "notfood";
        foodObject1.name = " + ";
    }
    if (!equationString.Contains("-"))
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(0, 25), transform.position.y + Random.Range(-5f, 5f), 0f);
        GameObject foodObject1 = Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        foodObject1.tag = "notfood";
        foodObject1.name = " - ";
    }
    if (!equationString.Contains("*"))
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(0, 25), transform.position.y + Random.Range(-5f, 5f), 0f);
        GameObject foodObject1 = Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        foodObject1.tag = "notfood";
        foodObject1.name = " * ";
    }

    // Возврат ответа на уравнение
    return result.ToString();
}
}