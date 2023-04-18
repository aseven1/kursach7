using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class carSpawner : MonoBehaviour {


    public string[] wrongAnswers; // Массив объектов с неправильными ответами
    public Text equationText; // Текстовый объект, где будет отображаться уравнение
    public int minOperand = 1; // Минимальное значение операнда
    public int maxOperand = 10; // Максимальное значение операнда

    private int operand1;
    private int operand2;
    private int answer;
    private List<int> usedAnswers = new List<int>(); // Список использованных ответов
	public GameObject[] cars;
	public GameObject buf;
	int carNo;
	public float maxPos = 2.4f;
	public float minPos = -2.4f;
	public float delayTimer = 1f;
	float timer;
	int i;

	// Use this for initialization
	void Start () {
		
		GenerateEquation(); // Генерируем уравнение при старте

	}
	 public void GenerateEquation()
    {
        // Генерируем случайные операнды и операцию
        operand1 = Random.Range(minOperand, maxOperand + 1);
        operand2 = Random.Range(minOperand, maxOperand + 1);
        int operation = Random.Range(0, 2); // 0 - сложение, 1 - вычитание

        // Вычисляем правильный ответ
        if (operation == 0)
        {
            answer = operand1 + operand2;
            equationText.text = operand1.ToString() + " + " + operand2.ToString() + " = ";
        }
        else
        {
            answer = operand1 - operand2;
            equationText.text = operand1.ToString() + " - " + operand2.ToString() + " = ";
        }

        // Задаем правильный ответ как имя объекта


        // Генерируем 4 неправильных ответа
        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            int wrongAnswer;
            do
            {
                wrongAnswer = Random.Range(answer - 5, answer + 6); // Генерируем случайное число в диапазоне от (answer-5) до (answer+5)
            } while (wrongAnswer == answer || usedAnswers.Contains(wrongAnswer)); // Повторяем генерацию, пока не получим уникальный неправильный ответ

            usedAnswers.Add(wrongAnswer); // Добавляем неправильный ответ в список использованных
            wrongAnswers[i] = wrongAnswer.ToString(); // Задаем неправильный ответ как имя объекта
        }
    }






	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Vector3 carPos = new Vector3 (Random.Range (minPos, maxPos), transform.position.y, transform.position.z);
			carNo = Random.Range (0, 5);
			

			buf=Instantiate (cars[carNo], carPos, transform.rotation);
			if(i==0)
			{
				buf.name=answer.ToString();
				buf.tag="TryeCar";
			}
			else
			{
              buf.name=wrongAnswers[i];
			  	buf.tag="Enemy Car";
			}
			i=i+1;
			Debug.Log(i);
            if(i>3)
			{
				i=0;
			}
			timer = delayTimer;
		}
			
	}
}
