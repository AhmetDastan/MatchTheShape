using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlideBar : MonoBehaviour
{
    [SerializeField] internal Slider slider;
    [SerializeField] internal UiManagment uiManagment;

    float sliderValueTemp = 0;

    // Start is called before the first frame update
    void Start()
    {
        sliderValueTemp = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(sliderValueTemp != slider.value)
        {
            uiManagment.gameHandle.soundManager.AdjustVolumeAllClip(slider.value);
            uiManagment.gameHandle.soundValue = slider.value;
        }
    }
}
