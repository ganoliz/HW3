using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] AllMenu;

    private void Awake()
    {
        SetMenuActive("MainMenu");
    }

    void SetAllMenuInActive()
    {
        foreach (GameObject menu in AllMenu)
            menu.SetActive(false);
    }

    public void SetMenuActive(string name)
    {
        int index = 0;
        foreach (GameObject menu in AllMenu)
        {
            if (menu.name == name)
            {
                break;
            }
            index++;
        }

        if (index >= AllMenu.Length)
        {
            Debug.LogError("menu" + name + "沒有找到");
            SetMenuActive("MainMenu");
        }
        else
        {
            SetAllMenuInActive();
            AllMenu[index].SetActive(true);
        }
    }
}
