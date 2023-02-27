using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BlockSpawner : MonoBehaviour
{
    private Camera cam;
    [SerializeField] public GameObject towerBlock;
    [SerializeField] private GameObject imageTarget;
    private BoxCollider coll;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject TowerBlocks;

    [SerializeField] private TowerBlocks tower;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        coll = imageTarget.GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f) && tower.lose <= 1)
            {
                Debug.Log("Collider Hit");
                SpawnBlock(hit.point);
            }
        }
           
    }

    private void SpawnBlock(Vector3 coordinate)
    {
        coordinate += new Vector3(0, 0.5f, 0);
        GameObject block = Instantiate(towerBlock, coordinate, Quaternion.identity);
        block.transform.parent = TowerBlocks.transform;
        int rand = Random.Range(0,3);
        block.GetComponent<Renderer>().material = materials[rand];
        
        Debug.Log("New Block Added");
    }
}
