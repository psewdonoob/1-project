using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Rocks;
    public GameObject HardRocks;

    private LogicScript logic;

    public int RockCount = 0;
    public float RockSpawnRate = 2;
    public float timer = 0;

    public float heightOffset = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isGameRunning)
        {
            if (timer < RockSpawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnRock();
                timer = 0;
            }
        }        
    }

    void spawnRock()
    {
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;

        if (RockCount < 10)
        {
            Instantiate(Rock,
                        new Vector3(transform.position.x,
                                    Random.Range(minHeight, maxHeight),
                                    transform.position.z),
                        transform.rotation);
        }
        else if (RockCount < 25)
        {
            Instantiate(Rocks,
                        new Vector3(transform.position.x,
                                    Random.Range(minHeight, maxHeight),
                                    transform.position.z),
                        transform.rotation);
        }
        else
        {
            Instantiate(HardRocks,
                        new Vector3(transform.position.x,
                                    Random.Range(minHeight, maxHeight),
                                    transform.position.z),
                        transform.rotation);
        }
                
        RockCount += 1;
    }  
}
