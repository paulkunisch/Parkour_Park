using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ApplicationManager.cs (in empty GO ApplicationManager)
 * Version 3.0
 *
 * author: Alexander Nischelwitzer
 * last changed: 26.04.2019
 *
 * description:
 * Unity DMT Tools for general use, Config at start UP, etc.
 * Features with public var
 *   - cursor
 *   - console
 *   - resolution
 *   - framerate
 *
 * generale Features with IngameDebugConsole (always needed) [call with: !]
 */

namespace DMT
{
    /// <summary>
    /// ApplicationManager with general inits and tools
    /// </summary>
    /// <remarks>
    /// needs the wonderful IngameDebugConsole from yasirkula
    /// </remarks>

    public class ApplicationManager : MonoBehaviour
    {
        public bool hideCursor = true;
        public bool hideConsole = true;  // inGame DebugConsole
        public bool screenLandscape = true;
        public int useFrameRate = 0; // if FrameRate = 0 do not change the system values

        private GameObject myDebugConsole;
        private bool screenFull = true;

        void Start()
        {
            Debug.Log("##### Init ApplicationManager.cs >> c..Cursor, !..inGameDebugger f..full/window");
            #region AppMngr Init Area
            if (Application.systemLanguage == SystemLanguage.German)
                Debug.Log("##### System Langage: " + Application.systemLanguage + " -- Platform: " + Application.platform +
                    " -- Sys: " + SystemInfo.operatingSystem);
            else
                Debug.LogWarning("##### System Language (NOT GERMAN): " + Application.systemLanguage + " -- Platform: " + Application.platform +
                    " -- Sys: " + SystemInfo.operatingSystem);

            DontDestroyOnLoad(this.gameObject);
            if (hideCursor) Cursor.visible = false;
            myDebugConsole = GameObject.Find("IngameDebugConsole");
            if (hideConsole) myDebugConsole.SetActive(false);

            if (useFrameRate > 0)
            {
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = useFrameRate;
            }

            IncStartLog(); // log StartUp in PlayerPrefs

            // set and show screen infos
            if (screenLandscape)
                Screen.SetResolution(1920, 1080, true);
            else
                Screen.SetResolution(1080, 1920, true);

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("##### Screen Info >> " + Screen.width + " x " + Screen.height + " -- Orient: " + Screen.orientation +
            " -- MonitorRes: " + Screen.currentResolution + " -- FullScr: " + Screen.fullScreen);
            Debug.Log("##### ==NIS============================================SOP=StartOPrg==");

            // AppInit END ###################################################################
            #endregion
        }

        void Update()
        {
            #region AppMngr Update Area

            // ###################################################################
            // ## Application Manager - Update
            //
            // Keys for Debugging
            //
            // f full screen to window toggle - default: full screen
            // ! inGame DebugConsole - default: not shown
            // c Cursor
            // r reset playerPrefs (delete)
            // i..infos
            //

            if (Input.GetKey("escape")) Application.Quit();

            // https://docs.unity3d.com/ScriptReference/PlayerPrefs.DeleteAll.html
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown("1"))
            {
                myDebugConsole.SetActive(!myDebugConsole.activeSelf);  // ! .. show Console
                Cursor.visible = myDebugConsole.activeSelf; // also turn cursor on or off
            }

            if (Input.GetKeyDown("f")) // f full toggle
            {
                if (screenFull)
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                else
                    Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                screenFull = !screenFull;
            }

            if (Input.GetKeyDown("c")) Cursor.visible = !Cursor.visible; // add startLog
            if (Input.GetKeyDown("i")) ShowInfos(); // showInfos
            if (Input.GetKeyDown("r")) ResetPlayerPrefs(); // init all PlayerPrefs

            // ## Application Manager: Update code end
            // ###################################################################
            #endregion
        }


        #region AppMngr methods definition

        // ###################################################################
        // ## Application Manager: methods start

        void IncStartLog()
        {
            // https://docs.unity3d.com/ScriptReference/PlayerPrefs.DeleteAll.html
            int startLog = PlayerPrefs.GetInt("startLog", 0);
            PlayerPrefs.SetInt("startLog", ++startLog);

            Debug.Log("##### ApplicationManager: startLog Counter (prefab) " + startLog + " [regedit: " + Application.companyName + "]");
        }

        void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("startLog", 0);

            if (Application.systemLanguage == SystemLanguage.German) // voice for speech output
                PlayerPrefs.SetInt("Voice", 0);
            else
                PlayerPrefs.SetInt("Voice", 1);

            int startLog = PlayerPrefs.GetInt("startLog", 0);
            Debug.Log("##### ApplicationManager [r]: ResetPlayerPrefs (prefab) StartLog>" + startLog);

        }

        void ShowInfos()
        {
            Debug.Log("##### ********************************************************************************");
            Debug.Log("##### ================================================================================");
            Debug.Log("##### INFO AppMngr >> i   ... InfoScreen NOW       f ... FullScreen/Window            ");
            Debug.Log("#####              >> c   ... Cursor ON/OFF        r ... ResetPrefabs                 ");
            Debug.Log("#####              >> esc ... End Program                                             ");
            Debug.Log("#####                                                                                 ");

            if (Application.systemLanguage == SystemLanguage.German)
                Debug.Log("##### System Langage: " + Application.systemLanguage + " -- Platform: "
                    + Application.platform + " -- Sys: " + SystemInfo.operatingSystem);
            else
                Debug.LogWarning("##### System Language (NOT GERMAY): " + Application.systemLanguage
                     + " -- Platform: " + Application.platform + " -- Sys: " + SystemInfo.operatingSystem);

            int startLog = PlayerPrefs.GetInt("startLog", 0);
            Debug.Log("##### ApplicationManager: startLog Counter (prefab) " + startLog + " [regedit: " + Application.companyName + "]");
            Debug.Log("##### Screen Info >> " + Screen.width + " x " + Screen.height + " -- Orient: " + Screen.orientation +

               " -- MonitorRes: " + Screen.currentResolution + " -- FullScr: " + Screen.fullScreen);
            Debug.Log("##### FrameRate: " + (1.0f / Time.deltaTime));
            Debug.Log("##### Info END                                                                        ");
            Debug.Log("##### ################################################################################");
            Debug.Log("##### ================================================================================");

        }

        // ## Application Manager: methods end
        // ###################################################################

        #endregion  
    }
}