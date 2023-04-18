using UnityEngine;
using UnityEngine.UI;

public class RectTransformTracker : MonoBehaviour
{
    public RectTransform rectTransform; // прямоугольник, за изменениями которого мы следим
    public float checkInterval = 0.1f; // интервал проверки изменений прямоугольника
    public float threshold = 10f; // порог изменения позиции по оси x
    public float arrowDuration = 1f; // продолжительность показа стрелок
    public InputField timeInputField; // поле ввода времени
    public Image leftArrow; // стрелка влево
    public Image rightArrow; // стрелка вправо

    private float lastX; // последняя известная позиция по оси x
    private float timer; // таймер для отображения стрелок

    void Start()
    {
        lastX = rectTransform.anchoredPosition.x;
        //time=1f;
    }

    void Update()
    {
        // проверяем изменения каждые checkInterval секунд
        if (Time.time - timer > checkInterval)
        {
         
            float newX = rectTransform.anchoredPosition.x;    
            Debug.Log(Mathf.Abs(newX));
            Debug.Log(Mathf.Abs(lastX));
            if (Mathf.Abs(newX - lastX) > threshold)
            {
            
                // превышен порог изменения позиции, показываем стрелки
                float time = 1f;
                if (newX > lastX)
                {
                    // движение вправо
                    leftArrow.gameObject.SetActive(false);
                    rightArrow.gameObject.SetActive(true);
                }
                else
                {
                    // движение влево
                    leftArrow.gameObject.SetActive(true);
                    rightArrow.gameObject.SetActive(false);
                }

                // запускаем таймер для скрытия стрелок через arrowDuration секунд
                timer = Time.time;
            }
            else
            {
                // позиция не изменилась достаточно, скрываем стрелки
                leftArrow.gameObject.SetActive(false);
                rightArrow.gameObject.SetActive(false);
            }


        }

        // проверяем таймер для скрытия стрелок
        if (Time.time - timer > arrowDuration)
        {
            leftArrow.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
        }
    }
}