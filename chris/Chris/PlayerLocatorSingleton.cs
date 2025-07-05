using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour that only exists while the ame isin play mode
/// </summary>
public class PlayerLocatorSingleton : MonoBehaviour
{
    /// <summary>
    /// Static field that exists for the entire project's duration
    /// IMPORTANT! Can be null if the game is not playing
    /// </summary>
    public static PlayerLocatorSingleton Instance;

    public void Awake()
    {
        // Instance will be null only if no PlayerLocator Game Object exist
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerLocatorSingleton");
            Destroy(gameObject);

        }
    }
}
