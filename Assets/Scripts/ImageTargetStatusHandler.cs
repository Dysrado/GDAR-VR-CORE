using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class ImageTargetStatusHandler : MonoBehaviour
{
    /*PREVIOUS CA*/
    //private ObserverBehaviour observerBehaviour;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    observerBehaviour = GetComponent<ObserverBehaviour>();
    //    observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void OnTargetStatusChanged(ObserverBehaviour target, TargetStatus targetStatus)
    //{
    //    Debug.Log("OnTargetStatusChanged: " + target.name + " - " + targetStatus.StatusInfo);
    //}
    private ObserverBehaviour locationTarget, platformTarget;
    [SerializeField] private TextMeshProUGUI _UIText;
    private bool hasPlatform = false;
    private bool isTracked = false;

    void Start()
    {
        var obj = GameObject.FindGameObjectWithTag("LocationTarget");
        var obj2 = GameObject.FindGameObjectWithTag("PlatformTarget");
        locationTarget = obj.GetComponent<ObserverBehaviour>();
        platformTarget = obj2.GetComponent<ObserverBehaviour>();
        if (locationTarget != null)
        {
            locationTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.Log("Location Target not Found");
        }
        if (platformTarget != null)
        {
            platformTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.Log("Location Target not Found");
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour target, TargetStatus targetStatus)
    {
        
        if (targetStatus.Status == Status.NO_POSE || targetStatus.Status == Status.LIMITED )
            OnTargetLost(target);
        else
            OnTargetFound(target);
    }

    void OnTargetLost(ObserverBehaviour target)
    {
        if (target.gameObject.CompareTag("PlatformTarget"))
        {
            hasPlatform = false;
            Debug.Log("No Platform");
           
        }
        else if (target.gameObject.CompareTag("LocationTarget") && hasPlatform)
        {
            Debug.Log("No beacon");
            
        }
    }

    public Vector2 TranslateBeaconPosition()
    {
        return Camera.main.WorldToScreenPoint(locationTarget.transform.position);
    }
    void OnTargetFound(ObserverBehaviour target)
    {
        if (target.gameObject.CompareTag("PlatformTarget"))
        {
            hasPlatform = true;
        }
        else if (target.gameObject.CompareTag("LocationTarget") && hasPlatform)
        {
            isTracked = true;
        }
    }

    void Update()
    {
        if (!hasPlatform)
        {
            isTracked = false;
            _UIText.SetText("PLEASE POINT CAMERA TOWARDS PLATFORM TARGET");
        }
        else if (hasPlatform && !isTracked)
        {
            _UIText.SetText("PLEASE SCAN THE BEACON TARGET");
        }
        if (isTracked)
        {
            _UIText.SetText("");
            AgentController.instance.MoveAgentsToPosition(locationTarget.transform.position);
        }
    }
}
