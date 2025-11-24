using UnityEngine;
using System.Collections.Generic;

public class BossMoveScript : MonoBehaviour
{
    [SerializeField]List<Transform> movePoints = new ();
    private int currentIndex = 0;
    [SerializeField] private float bossMoveSpeed = 2f;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movepointPosition = movePoints[currentIndex].transform.position - transform.position;

        if ( movePoints != null)
        {
            transform.Translate(movepointPosition.normalized * bossMoveSpeed * Time.deltaTime);
            if(movepointPosition.magnitude <= 0.1f)
            {
                currentIndex++;
            }
            if(currentIndex == movePoints.Count)
            {
                currentIndex = 0;
            }
        }
        if(movepointPosition.x < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if(movepointPosition.x > 0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
