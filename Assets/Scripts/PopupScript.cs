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

    public Text[] texts;

    List<Player> players2 = new List<Player>();

    System.Random rand = new System.Random(DateTime.Now.Second);


    public void StartPopup()
    {
        closeButton.SetActive(true);

        openButton.SetActive(false);

        popups[4].enabled = true;

        foreach (Text text in texts)
        {
            text.enabled = true;
        }

        WriteJson w = new WriteJson();

        w.write();

        ReadJson r = new ReadJson();

        players2 = r.read(33);

        for (int i = 0; i < 5 && i < players2.Count; i++)
        {
            Debug.Log(players2[i].toString());
        }

        Debug.Log("----");

        foreach (Player pl in players2)
        {
            if (pl.id == 33)
            {
                Debug.Log(pl.toString());
                break;
            }
        }


    }

    public void EndPopup()
    {
        foreach (Text text in texts)
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

    public void LoadJson()
    {

        using (StreamReader r = new StreamReader("players.json"))
        {

            string json = r.ReadLine();
            players2 = JsonConvert.DeserializeObject<List<Player>>(json);

            players2.Sort(SortByScore);
            
        }

        foreach (var player in players2)
        {
            Debug.Log(player.toString());
        }
        

    }

    private int SortByScore(Player x, Player y)
    {
        if (x.score == 0 || y.score == 0)
        {
            return 0;
        }

        // CompareTo() method 
        return -1 * x.score.CompareTo(y.score);
    }


}
