using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] Button addButton;
    [SerializeField] Button continueButton;

    [SerializeField] TMP_InputField min;
    [SerializeField] TMP_InputField max;

    [SerializeField] GameObject[] listItemResults;

    [SerializeField] TextMeshProUGUI result;

    [SerializeField] GameObject listFieldParent;

    [SerializeField] Button calButton;

    private List<GameObject> list = new List<GameObject>();
    private List<double> listInt = new List<double>();
    private int amount = 0;

    public string CURRENCY_FORMAT = "#,##0.00";
    public NumberFormatInfo NFI = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };

    private int type = 1;

    [SerializeField] Color[] listColor;

    //Singleton
    public static Controller Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        Clear();
    }

    private void DropdownitemSelected()
    {
        
    }

    private void DropdownitemAgeSelected()
    {
        
    }


    public void OnValueChanged()
    {
        if(CheckValidate())
        {
            calButton.interactable = true;
        }
        else
        {
            calButton.interactable= false;
        }
    }

    private bool CheckValidate()
    {
        if (min.text == "" || max.text == "")
        {
            return false;
        }

        //return text.All(char.IsDigit);
        return true;
    }


    public void Sum()
    {
        CalWithAdult();
        listFieldParent.SetActive(true);
    }

    private void CalWithAdult()
    {
        int min_m = int.Parse(min.text);
        int max_m = int.Parse(max.text);

        result.text = UnityEngine.Random.Range(min_m, max_m + 1).ToString();

    }

    public void Continue()
    {
        if(amount==0) return;
        Clear();
    }

    public void Clear()
    {
        listFieldParent.SetActive(false);

        min.text = "";
        max.text = "";

        calButton.interactable = false;
    }

    public void Quit()
    {
        Clear();
        Application.Quit();
    }
}
