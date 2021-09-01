using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] internal UiManagment uiManagment;

    public Button returnGame;
    public GameObject panel;
    public TextMeshProUGUI countDownText;

    internal float waitForResumGame = 2;
    bool isStartedCountDown = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PauseButtonClick);
        returnGame.GetComponent<Button>().onClick.AddListener(ReturnGame);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartedCountDown)
        {
            isStartedCountDown = false;

            StartCoroutine(WaitforPlay(waitForResumGame));
            uiManagment.gameHandle.soundManager.Play("CountDown");
        }
    }

    void PauseButtonClick()
    {
        uiManagment.gameHandle.soundManager.Play("ButtonSound");
        if (panel.activeSelf == true)
        {
            ClosedPanel();
        }
        else
        {
            openPanel();
        }
    }

    public void openPanel()
    {
        panel.SetActive(true);
        uiManagment.gameHandle.PauseGame();

    }
    public void ClosedPanel()
    {
        panel.SetActive(false);
        isStartedCountDown = true;
    }

    void ReturnGame()
    {
        ClosedPanel();
    }


    void CountDownSign(float time)
    {
        countDownText.text = time.ToString();
    }
    private IEnumerator WaitforPlay(float currentDownValue)
    {
        gameObject.GetComponent<Button>().enabled = false;
        countDownText.enabled = true;
        float temp = currentDownValue;
        
        while (temp > 0)
        {
            CountDownSign(temp);
            yield return new WaitForSeconds(1.0f);
            temp--;
        }
        gameObject.GetComponent<Button>().enabled = true;
        countDownText.enabled = false;
        uiManagment.gameHandle.ResumeGame();

    }

}
