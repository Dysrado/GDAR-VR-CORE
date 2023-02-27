using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemy;
    private float ticks = 0;
    private float SPAWN_INTERVAL = 3.0f;
    private bool isCurrentlyActive = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentlyActive)
        {
            ticks += Time.deltaTime;
            if (ticks > SPAWN_INTERVAL)
            {
                ticks = 0;
                Instantiate(enemy, this.transform.position, Quaternion.identity);
            }
        }
        
    }

    public void startSpawning()
    {
        isCurrentlyActive = true;
    }

    public void stopSpawning()
    {
        isCurrentlyActive = false;
    }
}
