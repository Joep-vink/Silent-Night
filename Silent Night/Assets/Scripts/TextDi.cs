using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDi : MonoBehaviour
{
    [SerializeField] int LetterPerSecond;
    [SerializeField] TextMeshProUGUI dialogText;

    private void Awake()
    {
        StartCoroutine(TypeDialog("Bring the collectables inside the house and place them on the table."));
    }

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / LetterPerSecond);
        }
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);


    }
}
