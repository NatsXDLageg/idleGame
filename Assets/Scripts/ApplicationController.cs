using UnityEngine;
using System.Collections;

public class ApplicationController : MonoBehaviour {

    public void Close()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
    }
}
