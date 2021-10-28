using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMessage : MonoBehaviour {

    public TMP_Text messageTextWindow;

    public void SetMessageText(string text) {
        this.messageTextWindow.text = text;
    }

    public void CloseMessage() {
        Destroy(gameObject);
    }
}
