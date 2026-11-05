using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Contrôleur de jeu qui gère l'état global du jeu et fournit un accès centralisé aux contrôles et aux autres systèmes.
/// </summary>
public class ControleurJeu : MonoBehaviour
{
    /// <summary>
    /// Instance singleton du contrôleur de jeu.
    /// </summary>
    public static ControleurJeu Instance { get; private set; }

    [field:SerializeField, Tooltip("Référence aux contrôles du joueur.")]
    public PlayerInput Controles { get; private set; }

    public event System.Action<bool> PausePlateformesChangee;

    public bool PlateformeEnPause {  get; private set; }

    private float dureePause = 5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// met les plateformes en pause pendant une duree
    /// </summary>
    public void DemarrerPause()
    {
        StartCoroutine(PauseTemporaire());
    }

    /// <summary>
    /// Arrtete les plateformes et attend la duree, puis les remet en mouve
    /// </summary>
    /// <returns></returns>
    private IEnumerator PauseTemporaire()
    {
        changerEtatPause(true);
        yield return new WaitForSeconds(dureePause);
        changerEtatPause(false);
    }

    /// <summary>
    /// change l'état de pause et previent toutes les plateformes
    /// </summary>
    /// <param name="enPause"></param>
    private void changerEtatPause(bool enPause)
    {
        PlateformeEnPause = enPause;
        PausePlateformesChangee?.Invoke(enPause);
    }
}
