using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeckCreator : MonoBehaviour
{
    public PlayerCardCollected Collected;
    public List<CardMenu> tempDeck;
    public GameObject deckBox;
    public GameObject collectionBox;
    public GameObject button;
    private List<GameObject> menuList = new List<GameObject>();
    private List<GameObject> CollectionList = new List<GameObject>();
    private int nombreCarte = 20;
    public TextMeshProUGUI texteNombreCarte;
    private void Start()
    {
        ChargerMenuCollection();
        ChargerTout();
    }
    public void ChargerDeck()
    {
        PlayerInfo temp = GameObject.FindFirstObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();

        tempDeck = temp.PlayerDeck.ToList();
        nombreCarte = tempDeck.Count;
        UpdateText();
    }
    private void UpdateText()
    {
        texteNombreCarte.text = nombreCarte.ToString();
    }
    public void ChargerMenuDeck()
    {
        foreach (GameObject obj in menuList)
        {
            Destroy(obj);
        }
        menuList.Clear();

        foreach (CardMenu card in tempDeck)
        {
            GameObject temp = Instantiate(button, deckBox.transform);
            temp.GetComponent<CardMenu>().ChangeValue(card.ID, card.Image);
            temp.GetComponent<Button>().onClick.AddListener(delegate { this.EnleverCarte(temp.GetComponent<CardMenu>()); });
            temp.GetComponent<Image>().sprite = card.Image;
            menuList.Add(temp);
        }

    }
    public void ChargerMenuCollection(bool ui)
    {
        if (ui)
        {
            foreach (CardMenu carte in Collected.Collection)
            {
                var gotted = CollectionList.Where((e) => e.GetComponent<CardMenu>().ID == carte.ID);
                if (!CollectionList.Contains(gotted.ElementAt(0)))
                {
                    GameObject temp = Instantiate(button, collectionBox.transform);
                    temp.GetComponent<CardMenu>().ChangeValue(carte.ID, carte.Image);
                    temp.GetComponent<Button>().onClick.AddListener(delegate { this.AjouterCarte(temp.GetComponent<CardMenu>()); });
                    temp.GetComponent<Image>().sprite = carte.Image;
                    CollectionList.Add(temp);
                }
            }
            Collected.changer = false;
        }

    }
    public void ChargerMenuCollection()
    {


        foreach (CardMenu card in Collected.Collection)
        {
            GameObject temp = Instantiate(button, collectionBox.transform);
            temp.GetComponent<CardMenu>().ChangeValue(card.ID, card.Image);
            temp.GetComponent<Button>().onClick.AddListener(delegate { this.AjouterCarte(temp.GetComponent<CardMenu>()); });
            temp.GetComponent<Image>().sprite = card.Image;
            CollectionList.Add(temp);
        }
    }
    public void ChargerTout()
    {
        ChargerDeck();
        ChargerMenuDeck();
        ChargerMenuCollection(Collected.changer);
    }
    public void AjouterCarte(CardMenu carte)
    {
        tempDeck.Add(carte);
        nombreCarte++;
        UpdateText();
        ChargerMenuDeck();
    }
    public void EnleverCarte(CardMenu carte)
    {
        var remove = tempDeck.Where((e) => e.ID == carte.ID);
        tempDeck.Remove(remove.ElementAt(0));
        nombreCarte--;
        texteNombreCarte.text = nombreCarte.ToString();
        ChargerMenuDeck();
    }
    public void Sauvegarder()
    {
        if (nombreCarte == 20)
        {
            PlayerInfo temp = GameObject.FindFirstObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();

            temp.PlayerDeck = tempDeck.ToArray();
        }
    }
}
