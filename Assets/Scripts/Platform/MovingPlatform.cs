using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
public float speed = 2.0f;
    public float moveleftTime = 3.0f;
    public float moverightTime = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveleftTime -= Time.deltaTime;
        if (moveleftTime > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
        moverightTime -= Time.deltaTime;
            if (moverightTime > 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                moveleftTime = 3.0f;
                moverightTime = 3.0f;
            }
        }
        
    }
}