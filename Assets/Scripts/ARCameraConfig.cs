using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARCameraConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetFocus();
            //Tap has happened
        }
    }

    void ResetFocus()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode((FocusMode.FOCUS_MODE_TRIGGERAUTO));

        //VuforiaBehaviour.Instance.CameraDevice.SetFocusMode((FocusMode.FOCUS_MODE_NORMAL));
        // StartCoroutine(FocusResetCoroutine());
    }

    //IEnumerator FocusResetCoroutine()
    //{
    //    yield return new WaitForSeconds(2);
    //    VuforiaBehaviour.Instance.CameraDevice.SetFocusMode((FocusMode.FOCUS_MODE_CONTINUOUSAUTO));
    //}

    private void OnVuforiaStarted()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
