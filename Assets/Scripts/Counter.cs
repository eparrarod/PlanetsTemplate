using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour {

    public bool isStatic;

    private TMP_Text m_text;

    //private TMP_InputField m_inputfield;

    private const string k_label = "Counter: <#0080ff>{0}</color>";
    private int count;

    void Awake() {
        // Get a reference to the TMP text component if one already exists otherwise add one.
        // This example show the convenience of having both TMP components derive from TMP_Text.

        m_text = GetComponent<TextMeshProUGUI>();
        Debug.Log(m_text);

        // Load a new font asset and assign it to the text object.
        m_text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Anton SDF");

        // Load a new material preset which was created with the context menu duplicate.
        //m_text.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Anton SDF - Drop Shadow");

        // Set the size of the font.
        m_text.fontSize = 60;

        // Set the text
        m_text.text = "A <#0280df>simple</color> line of text.";

        // Get the preferred width and height based on the supplied width and height as opposed to the actual size of the current text container.
        Vector2 size = m_text.GetPreferredValues(Mathf.Infinity, Mathf.Infinity);

        // Set the size of the RectTransform based on the new calculated values.
        m_text.rectTransform.sizeDelta = new Vector2(size.x, size.y);
    }


    void Update() {
        if (Input.anyKeyDown) {
            count += 1;
        }
        if (count > 0){
            m_text.SetText(k_label, count);
        }
    }


}
