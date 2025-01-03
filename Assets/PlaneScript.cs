using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody2D PlaneRigidbody;
    public float planeLiftStrength;
    public float planeDashStrength;
    public LogicScript logic;
    public bool isAlive;
    public float moveSpeed;
    public ParticleSystem PlaneSmoke;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        PlaneRigidbody.gravityScale = 0;
        transform.position = new Vector3(-10,0);
        
        isAlive = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0 && isAlive == true) 
        {
            //Debug.Log(isAlive);
            transform.position = transform.position + (Vector3.right * moveSpeed * Mathf.Abs(transform.position.x)) * Time.deltaTime;
        }

        if (transform.position.x > 0 && isAlive == true)
        {
            //Debug.Log(isAlive);
            transform.position = transform.position + (Vector3.left * moveSpeed * Mathf.Abs(transform.position.x)) * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            PlaneRigidbody.gravityScale = 3;
            PlaneRigidbody.linearVelocity = Vector2.up * planeLiftStrength;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && isAlive)
        {
            PlaneRigidbody.gravityScale = 3;
            PlaneRigidbody.linearVelocity = PlaneRigidbody.linearVelocity + (Vector2.right * planeDashStrength);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        PlaneRigidbody.gravityScale = 3;
        PlaneSmoke.Stop();
        Debug.Log("Collision!");
        logic.gameOver();  
    }
}
