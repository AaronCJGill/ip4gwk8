using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PersonInformationCard : MonoBehaviour
{
    //has information on what year the nobel prize was won, what it was for, and 
    [SerializeField]
    private TextMeshProUGUI NameText;
    [SerializeField]
    private TextMeshProUGUI DescriptionText;
    [SerializeField]
    private TextMeshProUGUI YearText;
    [SerializeField]
    private string namestr, descriptionstr, yearstr;
    [SerializeField]
    private int yearNum;
    public string NameStr
    {
        get { return namestr; }
    }
    public string DescriptionStr
    {
        get { return descriptionstr; }
    }
    public string YearStr
    {
        get { return yearstr; }
    }
    public int YearNum
    {
        get { return yearNum; }
    }
    public void initialize(string n, string d, string y)
    {
        namestr = n;
        descriptionstr= d;
        yearstr = y;
        yearNum = int.Parse(y);
        transform.name = n;
        

        NameText.text = n;
        DescriptionText.text = d;
        YearText.text = y;
        //Debug.Log("initialized");
    }
}
