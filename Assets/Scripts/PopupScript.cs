using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Assets.Scripts;

public class PopupScript : MonoBehaviour
{



    public GameObject openButton;
    
    public GameObject closeButton;

    public Image[] popups;

    public Text[] places;

    public Text[] names;

    public Text[] scores;




    public void StartPopup()
    {

        List<Player> players = new List<Player>();

        WriteJson w = new WriteJson();

        w.write(10000);

        ReadJson r = new ReadJson();

        players = r.read(33);

        closeButton.SetActive(true);

        openButton.SetActive(false);

        int a = 0;

        switch (players.Count)
        {
            case 1:
                popups[0].enabled = true;
                a = 0;
                break;
            case 2:
                popups[1].enabled = true;
                a = 1;
                break;
            case 3:
                popups[2].enabled = true;
                a = 2;
                break;
            case 4:
                popups[3].enabled = true;
                a = 3;
                break;
            default:
                popups[4].enabled = true;
                a = 4;
                break;
        }

        for(int i = 0; i <= a; i++)
        {
            
            names[i].text = players[i].nameToString();
            scores[i].text = players[i].score.ToString();

            places[i].enabled = true;
            names[i].enabled = true;
            scores[i].enabled = true;
        }

        closeButton.SetActive(true);

        openButton.SetActive(false);

        places[5].text = r.ourPlayerPlace.ToString();
        names[5].text = r.ourPlayer.nameToString();
        scores[5].text = r.ourPlayer.score.ToString();

        places[5].enabled = true;
        names[5].enabled = true;
        scores[5].enabled = true;



        /*
        for (int i = 0; i < 5 && i < players.Count; i++)
        {
            Debug.Log(players[i].toString());
        }

        Debug.Log("----");

        foreach (Player pl in players)
        {
            if (pl.id == 33)
            {
                Debug.Log(pl.toString());
                break;
            }
        }
        */


    }

    public void EndPopup()
    {
        
        foreach (Text text in places)
        {
            text.enabled = false;
        }
        foreach (Text text in names)
        {
            text.enabled = false;
        }
        foreach (Text text in scores)
        {
            text.enabled = false;
        }
        foreach (Image pop in popups)
        {
            pop.enabled = false;
        }

        closeButton.SetActive(false);

        openButton.SetActive(true);
        
    }

    


}
