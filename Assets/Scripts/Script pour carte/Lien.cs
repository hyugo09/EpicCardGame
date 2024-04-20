using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Lien : MonoBehaviour
{
    [SerializeField] internal Field field1;
    [SerializeField] internal Field field2;

    private TextMeshPro text;

    private int PV;
    public int currentPV = 0;
    private int coreDef = 5;
    [SerializeField] internal bool active = false;
    private void Start()
    {
        if (GetComponent<Core>())
        {
            text = GetComponentInChildren<TextMeshPro>();
        }
        else
        {
            text = GetComponent<TextMeshPro>();
            setLienPV();
        }
    }

    public void setLienPV()
    {
        if (GetComponent<Core>())
        {
            PV = GetComponent<Core>().Carte.defense;
            currentPV = PV;
            text.text = currentPV.ToString();
        }
        else if (field1.carteSurField != null && field1.carteSurField.GetComponent<Core>())
        {
            if (currentPV != 0 || currentPV != PV)
            {
                int temp = PV;
                PV = coreDef + field2.carteSurField.defense;
                currentPV += PV - temp;
            }

            else
            {
                PV = coreDef + field2.carteSurField.defense;
                currentPV = PV;
                active = true;
            }
        }
        else if (field2.carteSurField != null && field2.carteSurField.GetComponent<Core>())
        {
            if (currentPV != 0 || currentPV != PV)
            {
                int temp = PV;
                PV = field1.carteSurField.defense + coreDef;
                currentPV += PV - temp;
            }

            else
            {
                PV = field1.carteSurField.defense + coreDef;
                currentPV = PV;
                active = true;
            }
        }
        else if (field1.carteSurField != null && field2.carteSurField != null)
        {
            if (currentPV != 0 || currentPV != PV)
            {
                int temp = PV;
                PV = field1.carteSurField.defense + field2.carteSurField.defense;
                currentPV += PV - temp;
            }

            else
            {
                PV = field1.carteSurField.defense + field2.carteSurField.defense;
                currentPV = PV;
                active = true;
            }

        }
        SetLienText();
    }

    public void SetLienText()
    {
        text.text = currentPV.ToString();
    }

    private void OnMouseDown()
    {
        BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>();
        if (this.gameObject.GetComponent<Core>())
        {
            Core core = GetComponent<Core>();
            if (core.GetComponent<Card>().manager.enemyGameManager.currentPhase == CardGameManager.Phase.battle)
                if (!core.Field.VerificationLien())
                {
                    Card temp = core.GetComponent<Card>().manager.enemyGameManager.selected.GetComponent<Card>();
                    Dommage(temp.attack);
                    if (currentPV <= 0)
                    {
                        core.GetComponent<Card>().manager.LoseGame();
                    }
                    b.SwitchCam();
                    temp.canAttack = false;
                    return;
                }
        }

        if (field1.manager.enemyGameManager.currentPhase == CardGameManager.Phase.battle)
        {
           /* if (field1.manager.enemyGameManager.selected == null && !GetComponent<Core>())
            {
                b.SwitchCam();
                return;
            } */
            if (field1.manager.enemyGameManager.selected.GetComponent<Card>())
            {
                Card temp = field1.manager.enemyGameManager.selected.GetComponent<Card>();
                if (temp != null)
                {
                    if (!GetComponent<Core>() )
                    {
                        if (temp.canAttack)
                        Dommage(temp.attack);
                        //quand le lien est detruit
                        if (currentPV <= 0)
                        {
                            //désactiver
                            active = false;
                            currentPV = 0;
                            SetLienText();
                            //envoyer au cimetiere la carte s'il n'a plus d'autre lien 
                            if (!field1.VerificationLien())
                            {
                                field1.carteSurField.EnvoyerAuCimetiere();
                                field1.carteSurField = null;
                            }
                            if (!field2.VerificationLien())
                            {
                                field2.carteSurField.EnvoyerAuCimetiere();
                                field2.carteSurField = null;
                            }
                        }
                    }

                    temp.canAttack = false;

                    b.SwitchCam();
                }
            }
        }
    }

    public void Dommage(int degats)
    {
        currentPV -= degats;
        SetLienText();

    }

}
