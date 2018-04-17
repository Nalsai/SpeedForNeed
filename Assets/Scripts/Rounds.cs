using System;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{

    int Rot;
    int Blau;
    int Gruen;
    public GameObject WinnerCanvas;
    public Text WinnerText;
    public Text LapText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rot")
        {
            if (GameController.RedCheat == false)
            {
                Rot++;
                GameController.RedCheat = true;
            }
        }
        if (collision.tag == "Blau")
        {
            if (GameController.BlueCheat == false)
            {
                Blau++;
                GameController.BlueCheat = true;
            }
        }
        if (collision.tag == "Gruen")
        {
            if (GameController.GreenCheat == false)
            {
                Gruen++;
                GameController.GreenCheat = true;
            }
        }
        LapText.text = "Laps:" + Environment.NewLine + "Red Car: " + Rot + Environment.NewLine + "Blue Car: " + Blau + Environment.NewLine + "Green Car: " + Gruen;

        if (Rot > 3)
        {
            WinnerCanvas.SetActive(true);
            WinnerText.text = "The red car won the race!";
        }

        if (Blau > 3)
        {
            WinnerCanvas.SetActive(true);
            WinnerText.text = "The blue car won the race!";
        }

        if (Gruen > 3)
        {
            WinnerCanvas.SetActive(true);
            WinnerText.text = "The green car won the race!";
        }
    }
}