using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationGenerator : MonoBehaviour
{
    public Text equationText;
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    private int answer;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEquation();
    }

    void GenerateEquation()
    {
        // Generate a simple equation with two random numbers and an operator (+, -, *, /)
        int num1 = Random.Range(1, 11);
        int num2 = Random.Range(1, 11);
        int operatorIndex = Random.Range(0, 4);
        string op = "";

        switch (operatorIndex)
        {
            case 0:
                answer = num1 + num2;
                op = "+";
                break;
            case 1:
                answer = num1 - num2;
                op = "-";
                break;
            case 2:
                answer = num1 * num2;
                op = "*";
                break;
            case 3:
                answer = num1 / num2;
                op = "/";
                break;
        }

        // Set the equation text
        equationText.text = num1.ToString() + " " + op + " " + num2.ToString() + " = ?";

        // Set the text of the buttons with the answer and two random incorrect answers
        button1Text.text = answer.ToString();
        button2Text.text = (answer + Random.Range(1, 6)).ToString();
        button3Text.text = (answer - Random.Range(1, 6)).ToString();

        // Shuffle the order of the buttons
        List<Text> buttonList = new List<Text>();
        buttonList.Add(button1Text);
        buttonList.Add(button2Text);
        buttonList.Add(button3Text);
        buttonList.Shuffle();

        // Set the text of the buttons in the shuffled order
        button1Text = buttonList[0];
        button2Text = buttonList[1];
        button3Text = buttonList[2];
    }

    // Called when the user clicks a button
    public void ButtonClicked(Text buttonText)
    {
        int guess = int.Parse(buttonText.text);

        if (guess == answer)
        {
            Debug.Log("Correct!");
            // Do something when the user selects the correct answer
        }
        else
        {
            Debug.Log("Incorrect!");
            // Do something when the user selects the incorrect answer
        }

        // Generate a new equation
        GenerateEquation();
    }
}

// Extension method to shuffle a list
public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}