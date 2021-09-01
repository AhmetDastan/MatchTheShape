using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraResolution : MonoBehaviour
{

    [SerializeField] internal MainCamera mainCamera;

    private Vector2 deviceScreenResolution;
    internal Vector2 mainCamScreenBounds;


    private float screenHeigh = 0;
    private float screenWidth = 0;
    internal float camHeight = 0;
    internal float camWidth = 0;

    private float deviceScreenAspect = 0;

    // Start is called before the first frame update
    void Awake()
    {
        DefineDeviceAndScreenRes();
    }

    void DefineDeviceAndScreenRes()
    {

        screenHeigh = Screen.height;
        screenWidth = Screen.width;
        deviceScreenAspect = screenWidth / screenHeigh;
        deviceScreenResolution = new Vector2(Screen.width, Screen.height);


        camHeight = 100f * mainCamera.mainCameraObject.orthographicSize * 2;
        camWidth = camHeight * deviceScreenAspect;

        mainCamera.mainCameraObject.aspect = deviceScreenAspect;

        mainCamScreenBounds = mainCamera.mainCameraObject.ScreenToWorldPoint(new Vector3(screenWidth, screenHeigh, mainCamera.transform.position.z));
    }
}
