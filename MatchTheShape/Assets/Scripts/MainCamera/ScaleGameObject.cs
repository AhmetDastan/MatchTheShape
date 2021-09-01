using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGameObject : MonoBehaviour
{

    [SerializeField] internal MainCamera mainCamera;

    [SerializeField] private GameObject backgroundImage;

    private SpriteRenderer bgImage;



    private void Awake()
    {
        bgImage = backgroundImage.GetComponent<SpriteRenderer>();
        ScaleObject();
    }

    
    void ScaleObject()
    {
        float bgImageScaleRatioHeight = mainCamera.MainCameraResolution.camHeight / bgImage.sprite.rect.height;
        float bgImageScaleRatioWifth = mainCamera.MainCameraResolution.camWidth / bgImage.sprite.rect.width;

        bgImage.transform.localScale = new Vector3(bgImageScaleRatioWifth, bgImageScaleRatioHeight, 1);
    }
}
