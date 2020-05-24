using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVolume : MonoBehaviour
{
    [SerializeField] private string key;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    void SetText()
    {
        if(key == "volume")
        {
            gameObject.GetComponent<Text>().text = Setting.Volume.VOLUME_BGM.ToString();
        }
        else if(key == "effect")
        {
            gameObject.GetComponent<Text>().text = Setting.Volume.VOLUME_EFFECT.ToString();
        }
    }
}
