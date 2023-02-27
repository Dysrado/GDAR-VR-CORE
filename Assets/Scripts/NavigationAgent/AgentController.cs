using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AgentController : MonoBehaviour
{
    [SerializeField] ZombieAgent[] agents;
    public static AgentController instance;

    

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        agents = GetComponentsInChildren<ZombieAgent>();
    }

    public void MoveAgentsToPosition(Vector3 position)
    {
        foreach (var agent in agents)
        {
            agent.MoveToPosition(position);
        }
    }

    public void StopAgents(bool shouldStop)
    {
        foreach (var agent in agents)
        {
            agent.StopAgent(shouldStop);
        }
    }

    public void SetAgentsActive(bool isActive)
    {
        foreach (var agent in agents)
        {
            agent.StopAgent(!isActive);
            agent.gameObject.SetActive(isActive);
        }
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            OnTap(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    public void OnTap(Vector2 touchPos)
    {
       
        Ray r = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit hit;
        Debug.DrawRay(r.origin, r.direction * 10.0f, Color.red, 10);
        int layermask = LayerMask.GetMask("Target");
        if (Physics.Raycast(r, out hit, 100, layermask))
        {
            Vector3 hitpoint = hit.point;
            MoveAgentsToPosition(hitpoint);
            Debug.Log("");
        }
    }
}
