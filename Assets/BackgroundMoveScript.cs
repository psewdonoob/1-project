using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    public float moveSpeed = 1;
    public Renderer backgroundRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(moveSpeed * Time.deltaTime, 0);
    }
}
