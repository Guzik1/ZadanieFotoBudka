using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public ObjectController ObjectController;

    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void OnBackButtonClick()
    {
        ObjectController.ChangeObject(-1);
    }

    public void OnForwardButtonClick()
    {
        ObjectController.ChangeObject(1);
    }

    public void OnPhotoButtonClick()
    {
        StartCoroutine(CaptureScreen());
    }

    IEnumerator CaptureScreen()
    {
        canvas.enabled = false;

        yield return new WaitForEndOfFrame();

        TakeScreenshot();

        canvas.enabled = true;
    }

    void TakeScreenshot()
    {
        try
        {
            string savePath = Application.dataPath + "/Output/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png";

            string dictionaryPath = Path.GetDirectoryName(savePath);

            if (!Directory.Exists(dictionaryPath))
                Directory.CreateDirectory(dictionaryPath);

            ScreenCapture.CaptureScreenshot(savePath);
        }
        catch (Exception e) {
            Debug.LogError("Fail to save screenshot, message: " + e.Message);
        }
    }
}
