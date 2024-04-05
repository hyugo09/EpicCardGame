using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lien : MonoBehaviour
{
    [SerializeField] internal Field field1;
    [SerializeField] internal Field field2;

    private TextMeshPro text;

    private int PV;
    private int currentPV = 0;
    internal bool active = false;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        setLienPV();
    }

    public void setLienPV()
    {
        if(field1.carteSurField != null & field2.carteSurField)
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
        if (field1.manager.enemyGameManager.currentPhase == CardGameManager.Phase.battle)
        {
            if (field1.manager.enemyGameManager.selected.GetComponent<Card>())  
            {
                Card temp = field1.manager.enemyGameManager.selected.GetComponent<Card>();
                if (temp != null)
                {
                    if (!GetComponent<Core>())
                    {
                        Dommage(temp.attack);
                        //quand le lien est detruit
                        if(currentPV <= 0)
                        {
                            //désactiver
                            active = false;
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
                        temp.canAttack = false;
                        BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>();
                        b.SwitchCam();
                    }
                    else
                    {
                        Core core = GetComponent<Core>();
                        if (!core.Field.VerificationLien())
                        {
                            Dommage(temp.attack);
                            if (currentPV <= 0)
                            {
                                field1.manager.LoseGame();
                            }
                            //jsp si on en a besoin ou pas mais je le laisse au cas ou
                            BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>();
                            b.SwitchCam();
                        }
                        
                    }
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
