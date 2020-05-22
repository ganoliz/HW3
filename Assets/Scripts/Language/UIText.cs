using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
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

    public void SetText() {
        if (!string.IsNullOrEmpty(key)) {
            string value = LanguageMgr.Instance.GetText(key);
            if (!string.IsNullOrEmpty(value)) {
                gameObject.GetComponent<Text>().text = value;
            }
        }
    }
}
