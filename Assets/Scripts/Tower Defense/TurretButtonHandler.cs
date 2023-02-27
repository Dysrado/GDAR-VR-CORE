using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TurretButtonHandler : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour[] virtualButtons;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject[] Turrets;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var vButton in virtualButtons)
        {
            vButton.RegisterOnButtonPressed(OnButtonPressed);
            vButton.RegisterOnButtonReleased(OnButtonReleased);
        }   
    }


    private void OnDestroy()
    {
        foreach (var vButton in virtualButtons)
        {
            vButton.UnregisterOnButtonPressed(OnButtonPressed);
            vButton.UnregisterOnButtonReleased(OnButtonReleased);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPressed(VirtualButtonBehaviour vButton)
    {
        Debug.Log("Virtual Button pressed: " + vButton.VirtualButtonName);
    }
    void OnButtonReleased(VirtualButtonBehaviour vButton)
    {
        
        Debug.Log("Spawned Bullet on " + vButton.VirtualButtonName);

        string name = vButton.VirtualButtonName;

        if (name == "Tower_A")
        {
            Vector3 loc = new Vector3(Turrets[0].transform.position.x,Turrets[0].transform.position.y, 0.3f);
            Instantiate(bullet, loc, Quaternion.identity);  
        }
        else if (name == "Tower_B")
        {
            Vector3 loc = new Vector3(Turrets[1].transform.position.x,Turrets[1].transform.position.y, 0.3f);
            Instantiate(bullet, loc, Quaternion.identity);
        }
        else if (name == "Tower_C")
        {
            Vector3 loc = new Vector3(Turrets[2].transform.position.x,Turrets[2].transform.position.y, 0.3f);
            Instantiate(bullet, loc, Quaternion.identity);
        }

    }
}
