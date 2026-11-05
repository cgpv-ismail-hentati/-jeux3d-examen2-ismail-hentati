using UnityEngine;

/// <summary>
/// Classe du piece que le joueur peut le ramasser
/// </summary>
public class Piece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Boule boule))
        {
            boule.AjouterPiece();
            Destroy(gameObject);
        }
    }
}
