using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    // Currency txt UI
    public Text txt_Currency;

    // Default currency value
    public int defaultCurrency;

    // Current currency value
    public int currency;

    // Initiate (set the default values)
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    // Gain currency (input of value)
    public void Gain(int val)
    {
        currency += val;
        UpdateUI();
    }

    // Lose currency (input of value)
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    // Check availability of currency
    bool EnoughCurrency(int val)
    {
        // Check if the value is equal or more than currency
        if (val <= currency)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update txt UI
    void UpdateUI()
    {
        txt_Currency.text = currency.ToString();
    }

    public void USE_TEST()
    {
        Debug.Log(Use(150));
    }
}
