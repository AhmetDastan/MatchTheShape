using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSliding : MonoBehaviour
{
    internal GameHandle gameHandle;

    private void Start()
    {
        gameHandle = GameObject.Find("GameHandle").GetComponent<GameHandle>();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * gameHandle.platformSpeed);
        if(gameObject.transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
