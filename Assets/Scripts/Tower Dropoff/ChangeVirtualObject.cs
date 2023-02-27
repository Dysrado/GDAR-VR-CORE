using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVirtualObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject VirtualObject1A;
    [SerializeField] private GameObject VirtualObject1B;
    [SerializeField] private GameObject VirtualObject2A;
    [SerializeField] private GameObject VirtualObject2B;
    [SerializeField] private GameObject VirtualObject3A;
    [SerializeField] private GameObject VirtualObject3B;

    void Start()
    {
        VirtualObject1A.SetActive(false);
        VirtualObject1B.SetActive(false);
        VirtualObject2A.SetActive(false);
        VirtualObject2B.SetActive(false);
        VirtualObject3A.SetActive(false);
        VirtualObject3B.SetActive(false);
    }

    public void changeToA()
    {
        VirtualObject1A.SetActive(true);
        VirtualObject1B.SetActive(false);
        VirtualObject2A.SetActive(true);
        VirtualObject2B.SetActive(false);
        VirtualObject3A.SetActive(true);
        VirtualObject3B.SetActive(false);
    }
    public void changeToB()
    {
        VirtualObject1B.SetActive(true);
        VirtualObject1A.SetActive(false);
        VirtualObject2B.SetActive(true);
        VirtualObject2A.SetActive(false);
        VirtualObject3B.SetActive(true);
        VirtualObject3A.SetActive(false);
    }

}
