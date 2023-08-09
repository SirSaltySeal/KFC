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

    // Start is called before the first frame update
    void Start()
    {

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
}
