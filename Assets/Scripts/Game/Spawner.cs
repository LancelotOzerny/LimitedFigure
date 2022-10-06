using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn object")]
    [SerializeField] private GameObject obj;


    [Header("Spawn points")]
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private Vector2 topLeft, botRight;

    [Header("Time Settings")]
    [SerializeField] private float minTime = 0.0f;
    [SerializeField] private float maxTime = 10.0f;
    [SerializeField] private float timer;
    static System.Random rand = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        topLeft = point1.position;
        botRight = point2.position;

        // Проверка длинны
        if (botRight.x < topLeft.x)
        {
            float tmp = topLeft.x;
            topLeft.x = botRight.x;
            botRight.x = tmp;
        }

        // Проверка высоты
        if (botRight.y < topLeft.y)
        {
            float tmp = topLeft.y;
            topLeft.y = botRight.y;
            botRight.y = tmp;
        }

        timer = GetRandomNum(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = GetRandomNum(minTime, maxTime);

            GameObject obj = Instantiate(this.obj, transform);

            Vector3 pos = GeneratePosition();
            obj.transform.position = pos;
            Destroy(obj, 8);
        }
    }

    
    Vector3 GeneratePosition()
    {
        Vector3 result = transform.position;

        result.x = GetRandomNum(topLeft.x, botRight.x);
        result.y = GetRandomNum(botRight.y, topLeft.y);

        return result;
    }

    float GetRandomNum(float minNumber, float maxNumber)
    {
        float result;
        int epsilon = 10_000;

        if (minNumber > maxNumber)
        {
            float tmp = minNumber;
            minNumber = maxNumber;
            maxNumber = tmp;
        }

        int min = System.Convert.ToInt32(minNumber * epsilon);
        int max = System.Convert.ToInt32(maxNumber * epsilon);

        result = (float)rand.Next(min, max) / epsilon;

        return result;
    }
}
