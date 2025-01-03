using UnityEngine;

public class NitroSpawnerScript : MonoBehaviour
{
    public GameObject Nitro;    
    private float spawnRate;

    private float minHeight;
    private float maxHeight;
    private float positionY;
    public float heightOffset = 9;

    public RockSpawnerScript rockSpawner;
    private int nextRock = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRate = Random.Range(0.5f, 1.5f);
        rockSpawner = GameObject.FindGameObjectWithTag("RockSpawner").GetComponent<RockSpawnerScript>();

        minHeight = transform.position.y - heightOffset;
        maxHeight = transform.position.y + heightOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (rockSpawner.timer > spawnRate && rockSpawner.RockCount == nextRock)
        {
            spawnNitro();
            spawnRate = Random.Range(0.5f, 1.5f);
            nextRock += Random.Range(1, 3);
        }
    }

    void spawnNitro()
    {        
        positionY = Random.Range(minHeight, maxHeight);

        Instantiate(Nitro,
                    new Vector3(transform.position.x,
                                positionY,
                                transform.position.z),
                    transform.rotation);
    }
}
