using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameHandle gameHandle;

    private Touch touch;
    Vector3 touchPos;
    Vector3 newTouchPos;

    internal bool isLeftSliding = false;
    internal bool isRightSliding = false;
    internal bool isAvailableTouch = true;



    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        DeviceVisualButtonController();
    }

    void PlayerMovement()
    {
        if (Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Ended) isAvailableTouch = true;
            touch = Input.GetTouch(0);
            newTouchPos = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                touchPos = touch.position;
            }
            if((Mathf.Abs(newTouchPos.x - touchPos.x) > 10) && isAvailableTouch)
            {
                isAvailableTouch = false;
                if (touchPos.x < newTouchPos.x)
                {
                    isRightSliding = true;
                }
                else
                {
                    isLeftSliding = true;
                }
            }
        }
        
    }

    void DeviceVisualButtonController()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            Debug.Log("home");
            gameHandle.PauseGame();
            //Home button pressed! write every thing you want to do

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
            gameHandle.PauseGame();
            //Escape button codes
        }
        if (Input.GetKeyDown(KeyCode.Menu))
        {
            Debug.Log("menu");
            Application.Quit();
        }
    }
}
