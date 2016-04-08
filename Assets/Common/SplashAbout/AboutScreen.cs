/*===============================================================================
Copyright (c) 2015-2016 PTC Inc. All Rights Reserved.
 
Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using System.Collections;

public class AboutScreen : MonoBehaviour
{
    #region PUBLIC_METHODS
    public void OnStartAR()
    {
#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
        Application.LoadLevel("Vuforia-2-Loading");
#else // UNITY_5_3 or above
        UnityEngine.SceneManagement.SceneManager.LoadScene("Vuforia-2-Loading");
#endif
    }
    #endregion // PUBLIC_METHODS


    #region MONOBEHAVIOUR_METHODS
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
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