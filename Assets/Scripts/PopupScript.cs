using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;


/// 
/// Основный скрипт, взаимодействующий с Unity. Считывает значения с UI, 
/// запускает подпрограммы WriteJson и ReadJson, 
/// "включает" и "выключает" элементы UI. 
///
public class PopupScript : MonoBehaviour
{



    public GameObject openButton; // кнопка "Открыть статистику"
    
    public GameObject closeButton; // кнопка "Закрыть"

    public Image[] popups; // варианты попапа для разного кол-ва игроков

    public Text[] places; // места игроков

    public Text[] names; // имена игроков

    public Text[] scores; // набранные очки в ходе турнира


    /*
     * Функция, активируемая при нажатии кнопки "Открыть статистику".
     * Запускает генерацию json-файла с игроками, потом считывает информацию из файла.
     * В зависимости от кол-ва игроков (1-4 или больше 4), выводит информацию 
     * о результатах на экран, скрывает кнопку открытия попапа и показывает кнопку закрытия.
     */
    public void StartPopup()
    {

        List<Player> players = new List<Player>();

        WriteJson w = new WriteJson();

        w.Write(10000); // кол-во игроков - 10000 

        ReadJson r = new ReadJson();

        players = r.Read(33); // передаем id нашего игрока в считывающую программу

        if (players.Count == 0)
        {
            Debug.Log("JSON-файл не найден");
        }
        else
        {
            int playersCount = 0;

            switch (players.Count)
            {
                case 1:
                    playersCount = 0;
                    break;
                case 2:
                    playersCount = 1;
                    break;
                case 3:
                    playersCount = 2;
                    break;
                case 4:
                    playersCount = 3;
                    break;
                default:
                    playersCount = 4;
                    break;
            }

            popups[playersCount].enabled = true;

            for (int i = 0; i <= playersCount; i++)
            {

                names[i].text = players[i].nameToString();
                scores[i].text = players[i].score.ToString();

                places[i].enabled = true;
                names[i].enabled = true;
                scores[i].enabled = true;
            }

            closeButton.SetActive(true);

            openButton.SetActive(false);

            /*
             *  Все изменяемые текстовые элементы в UI, отображающие информацию 
             *  об игроке, можно найти в массивах под индексом 5.
             */
            places[5].text = r.ourPlayerPlace.ToString();
            names[5].text = r.ourPlayer.nameToString();
            scores[5].text = r.ourPlayer.score.ToString();

            places[5].enabled = true;
            names[5].enabled = true;
            scores[5].enabled = true;

        }
    }

    /*
     * Функция, активируемая при нажатии кнопки "Закрыть".
     * Скрывает всю информацию попапа, возвращает UI в изначальное
     * положение.
     */
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
