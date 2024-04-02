using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractionSlot : MonoBehaviour
{
    //check to see if player clicks onto this slot with interfaces or buttons
    [SerializeField]
    TextMeshProUGUI yeartext;
    public int yearValue { get; private set; }

    public bool correctChoice = false;
    public void initialize(int year, bool cc)
    {
        //takes in a year, and the player has to place the card into the right year
        yeartext.text = year.ToString();
        yearValue = year;
        correctChoice = cc;
    }

    public void useButton()
    {
        //whatever is the current selected card in game manager, the player moves it to this position
        //GameManager.instance.
        GameManager.instance.playerMadeMove(correctChoice);
    }
}
