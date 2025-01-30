using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody2D PlaneRigidbody;
    public float planeLiftStrength;
    public float planeDashStrength;
    public float planeGravityScale;
    private float planeGlideGravityScale = 0;
    public float planeGlideLinearVelosityY;

    public LogicScript logic;
    public bool isAlive;
    public float moveSpeed;

    public ParticleSystem PlaneSmoke;

    Animator PlaneAnimator;

    InputAction jumpAction;
    InputAction nitroAction;
    InputAction glideAction;

    private bool isGlidePhysicsOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        nitroAction = InputSystem.actions.FindAction("Nitro");
        glideAction = InputSystem.actions.FindAction("Glide");

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        PlaneRigidbody.gravityScale = 0;
        transform.position = new Vector3(-10,0);
        
        isAlive = true;

        PlaneAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (glideAction.phase == InputActionPhase.Performed && isAlive)
        {
            if (PlaneRigidbody.linearVelocityY <= planeGlideLinearVelosityY && isGlidePhysicsOn == false)
            {
                PlaneRigidbody.gravityScale = planeGlideGravityScale;
                PlaneRigidbody.linearVelocityY = planeGlideLinearVelosityY;
                isGlidePhysicsOn = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if (transform.position.x < 0 && isAlive == true)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed * Mathf.Abs(transform.position.x)) * Time.deltaTime;
        }

        if (transform.position.x > 0 && isAlive == true)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed * Mathf.Abs(transform.position.x)) * Time.deltaTime;
        }

        if (jumpAction.WasPressedThisFrame() && isAlive)
        {
            if (logic.isGameRunning == false)
            {
                logic.isGameRunning = true;
            }

            PlaneRigidbody.gravityScale = planeGravityScale;
            PlaneRigidbody.linearVelocity = Vector2.up * planeLiftStrength;
        }

        if (nitroAction.WasPressedThisFrame() && isAlive && logic.isNitroAvailable())
        {
            PlaneRigidbody.gravityScale = planeGravityScale;
            PlaneRigidbody.linearVelocity = PlaneRigidbody.linearVelocity + (Vector2.right * planeDashStrength);
            logic.removeNitro(1);
        }               

        if (glideAction.WasReleasedThisFrame() && isAlive)
        {
            PlaneRigidbody.gravityScale = planeGravityScale;
            isGlidePhysicsOn = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        PlaneRigidbody.gravityScale = 4;
        PlaneSmoke.Stop();
        logic.gameOver();
        PlaneAnimator.enabled = false;
    }
}
