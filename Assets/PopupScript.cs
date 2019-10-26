using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour
{



    public GameObject openButton;
    
    public GameObject closeButton;

    public Image[] popups;

    public Text[] texts;

    
    public void ButtonClicked()
    {
        
        closeButton.SetActive(true);

        openButton.SetActive(false);

        image.enabled = true;

        text.text = "a";

        text.enabled = true;


    }


    public void StartPopup()
    {
        //openButton = transform.Find("OpenButton").GetComponent<Button>();
        //openButton.interactable = false;

        //GameObject closeButton = GameObject.Find("CloseButton");
        //closeButton.SetActive(true);


    }


}
