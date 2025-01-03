using UnityEngine;

public class RockSpawnerScript : MonoBehaviour
{
    public GameObject Rock;
    public int RockCount = 0;
    public float spawnRate = 2;
    public float timer = 0;

    public float heightOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawnRock();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else 
        {
            spawnRock();
            timer = 0;
        }
    }

    void spawnRock()
    {
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;

        Instantiate(Rock, 
                    new Vector3(transform.position.x, 
                                Random.Range(minHeight, maxHeight), 
                                transform.position.z), 
                    transform.rotation);

        RockCount += 1;
    }
}
