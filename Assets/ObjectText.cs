using TMPro;
using UnityEngine;

public class ObjectText : MonoBehaviour
{
    public TextMeshPro textMesh; // Assigner dans l'Inspector
    public string objectName = "Nom de l'objet";

    void Start()
    {
        if (textMesh != null)
        {
            textMesh.text = objectName; // Affiche le texte
        }
    }
}
