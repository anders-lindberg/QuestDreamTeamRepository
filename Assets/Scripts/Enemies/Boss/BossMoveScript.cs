using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class BossMoveScript : MonoBehaviour
{
    [SerializeField]List<Transform> movePoints = new ();
    private int currentIndex = 0;
    [SerializeField] private float bossMoveSpeed = 2f;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject rockThrow;
    [SerializeField] GameObject HealthGem;
    int hpspawnNumber;
    Transform spawnPoint;
    int playerHp;
    bool gemSpawned = false;
    float timer = 0f;
    [SerializeField] float attackSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPoint = transform.Find("gemspawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        playerHp = PlayerHealthManager.Instance.currentHp;
        if(playerHp == 1 && HealthGem != null && !gemSpawned)
        {
            Instantiate(HealthGem, spawnPoint.position, Quaternion.identity);

            gemSpawned = true;
        }
        if(playerHp >= 2)
        {
            gemSpawned = false;
        }
        if(timer < attackSpeed)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(rockThrow, transform.position, Quaternion.identity);
            timer = 0f;
        }
        
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
