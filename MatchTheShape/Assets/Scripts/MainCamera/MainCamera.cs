using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField] internal GameHandle gameHandle;
    [SerializeField] internal MainCameraResolution MainCameraResolution;

    internal Camera mainCameraObject;


    // Start is called before the first frame update
    void Awake()
    {
        mainCameraObject = GetComponent<Camera>();
    }

}
