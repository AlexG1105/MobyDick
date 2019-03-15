using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollision : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public bool alreadyPressed;

    // Start is called before the first frame update
    void Start()
    {
        alreadyPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag == "bridge1" && GameInfo.bossesDefeated == 0 && !alreadyPressed)
        {
            TriggerDialogue();
            alreadyPressed = true;
        }
        else if (gameObject.tag == "bridge2" && GameInfo.bossesDefeated == 1 && !alreadyPressed)
        {
            TriggerDialogue();
            alreadyPressed = true;
        }
        else if (gameObject.tag == "bridge3" && GameInfo.bossesDefeated == 2 && !alreadyPressed)
        {
            TriggerDialogue();
            alreadyPressed = true;
        }
        else if (gameObject.tag == "bridge4" && GameInfo.bossesDefeated == 3 && !alreadyPressed)
        {
            TriggerDialogue();
            alreadyPressed = true;
        }
        else if (gameObject.tag == "bridge5" && GameInfo.bossesDefeated == 4 && !alreadyPressed)
        {
            TriggerDialogue();
            alreadyPressed = true;
        }
    }

    public void TriggerDialogue()
    {
        GameInfo.lastPosition = GameObject.Find("MainShip(Clone)").transform.position;
        Debug.Log(GameInfo.lastPosition);
        dialogueBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
