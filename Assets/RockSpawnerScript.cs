using UnityEngine;

public class RockSpawnerScript : MonoBehaviour
{
    public GameObject Rock;

    public float spawnRate = 2;
    private float timer = 0;

    public float heightOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
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
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;

        Instantiate(Rock, 
                    new Vector3(transform.position.x, 
                                Random.Range(minHeight, maxHeight), 
                                transform.position.z), 
                    transform.rotation);
    }
}
