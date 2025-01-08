using UnityEngine;

public class NitroSpawnerScript : MonoBehaviour
{
    public GameObject Nitro;    
    private float spawnRate;

    private float minHeight;
    private float maxHeight;
    private float positionY;
    public float heightOffset = 9;

    private SpawnerScript Spawner;
    private int nextRock = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerScript>();

        minHeight = transform.position.y - heightOffset;
        maxHeight = transform.position.y + heightOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.timer > spawnRate && Spawner.RockCount == nextRock)
        {            
            spawnRate = Random.Range(0.6f, 1.4f);
            spawnNitro();
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
