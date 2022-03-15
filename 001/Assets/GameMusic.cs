using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private static GameMusic instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
