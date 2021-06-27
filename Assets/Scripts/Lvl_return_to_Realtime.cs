using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Hasenhüttl
public class Lvl_return_to_Realtime : MonoBehaviour
{
    public void ReturnToRealtime()
    {
        Time.timeScale = 1f; // since our pause menu stops the time, this function in all necessary places to prevent errors
    }
}
