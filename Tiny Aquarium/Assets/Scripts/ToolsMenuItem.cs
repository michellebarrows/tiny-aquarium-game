using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsMenuItem : MonoBehaviour
{
    public Transform transformComponent;

    void Awake()
    {
        transformComponent = transform;
    }

}
