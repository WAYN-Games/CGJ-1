using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Text CharacterDialog;
    [TextArea(2,5)]
    public string Text;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterDialog.text = Text;
    }


}
