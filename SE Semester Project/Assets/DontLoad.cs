using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
