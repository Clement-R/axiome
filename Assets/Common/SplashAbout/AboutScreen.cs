/*===============================================================================
Copyright (c) 2015-2016 PTC Inc. All Rights Reserved.
 
Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
#if ENABLE_HOLOLENS_MODULE_API || UNITY_5_5_OR_NEWER
#if UNITY_WSA_10_0
#define HOLOLENS_API_AVAILABLE
#endif
#endif

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutScreen : MonoBehaviour
{
    #region PUBLIC_ATTRIBUTES
    public InputField serverAddress;
    #endregion // PUBLIC_ATTRIBUTES

    #region PUBLIC_METHODS
    public void OnStartAR()
    {
        PlayerPrefs.SetString("ip", serverAddress.text);
        PlayerPrefs.Save();
        Debug.Log("Starttt");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Vuforia-2-Loading");
    }
    #endregion // PUBLIC_METHODS

    #region MONOBEHAVIOUR_METHODS
    private void Start() {
        #if HOLOLENS_API_AVAILABLE
            OnStartAR();
        #endif
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // Treat 'Return' key as pressing the Close button and dismiss the About Screen
            OnStartAR();
        }
        else if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            // Similar to above except detecting the first Joystick button
            // Allows external controllers to dismiss the About Screen
            // On an ODG R7 this is the select button
            OnStartAR();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
            // On Android, the Back button is mapped to the Esc key
            Application.Quit();
#endif
        }
    }
    #endregion // MONOBEHAVIOUR_METHODS
}