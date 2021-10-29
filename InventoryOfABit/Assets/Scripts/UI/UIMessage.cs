using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/** Works as an initializer for UI messages.
 */
public class UIMessage : MonoBehaviour {

    public TMP_Text messageTextWindow;

    public void SetMessageText(string text) {
        this.messageTextWindow.text = text;
    }

    public void CloseMessage() {
        Destroy(gameObject);
    }
}
