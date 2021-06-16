using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
   // private static DontDestroyOnLoad isnt = null;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
