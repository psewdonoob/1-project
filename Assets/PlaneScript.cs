using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody2D PlaneRigidbody;
    public float planeLiftStrength;
    public LogicScript logic;
    public bool isAlive;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            PlaneRigidbody.linearVelocity = Vector2.up * planeLiftStrength;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }
}
