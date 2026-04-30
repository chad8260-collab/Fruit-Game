using UnityEngine;

public class FruitGame : MonoBehaviour
{
    public GameObject[] fruitPerfabs;
    public float[] fruitSize = { 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.5f, 1.7f, 1.9f };

    public GameObject currentFruit;
    public int currentFruitType;

    public float fruitStartHeigt = 6.0f;
    public float gameWidth = 6.0f;
    public bool isGameOver = false;
    public Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
        SpawnnewFruit();
    }
    void SpawnnewFruit()
    {

        if (!isGameOver)
        {
            currentFruitType = Random.Range(0, 3);

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 spawnPosition = new Vector3(worldPosition.x, fruitStartHeigt, 0);

            float halfFruitSize = fruitSize[currentFruitType] / 2f;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halfFruitSize, gameWidth / 2 - halfFruitSize);

            currentFruit = Instantiate(fruitPerfabs[currentFruitType], spawnPosition, Quaternion.identity);
            currentFruit.transform.localScale = new Vector3(fruitSize[currentFruitType], fruitSize[currentFruitType], 1);

            Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = 0.0f;
            }
        }
    }
    void Update()
    { 
    if (isGameOver) return;

        if (currentFruit != null)
        {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenTowordl(mousePosition);

            Vector3 newPosition = currentFruit.transform.position;

            newPosition.x = worldPosition.x;

            float halfFruitSize = fruitSize[currentFruitType] / 2f;

            if (newPosition.x < -gameWidth / 2 - halfFruitSize)

                newPosition.x = -gameWidth / 2 - halfFruitSize;



            if (newPosition.x > gameWidth / 2 + halfFruitSize)

                newPosition.x = gameWidth / 2 + halfFruitSize;

            currentFruit.transform.position = newPosition;
        }
}



 

  


