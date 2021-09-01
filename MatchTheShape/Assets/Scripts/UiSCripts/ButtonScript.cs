using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] internal UiManagment uiManagment;
    [SerializeField] internal GameHandle gameHandle;
    public static bool isRestartButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(clickButton);
    }

    void clickButton()
    {
        gameHandle.soundManager.Play("ButtonSound");
        if (gameObject.name == "RestartGame")
        {
            isRestartButtonPressed = true;
        }
        else if(gameObject.name == "PlayButton")
        {
            gameHandle.StartGame();
        }
    }

}
