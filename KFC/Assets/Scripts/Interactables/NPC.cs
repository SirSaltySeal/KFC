using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Interactable
{
    public Quests quest;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public GameObject questWindow; 
    public GameObject questStatus;
    Target script;
    public TextMeshProUGUI killCounter;

    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        questStatus.SetActive(true);
        quest.isActive = true;
        killCounter.text = "Enemies Exorcised: " + script.score;
    }
}
