using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    public void OpenSettings()
    {
        UIPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        UIPanel.SetActive((false));
    }

    public void ResetFocus()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode((FocusMode.FOCUS_MODE_NORMAL));
        StartCoroutine(FocusResetCoroutine());
        Debug.Log("Focus Reset");
    }

    IEnumerator FocusResetCoroutine()
    {
        yield return new WaitForSeconds(2);
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode((FocusMode.FOCUS_MODE_CONTINUOUSAUTO));
    }
}
