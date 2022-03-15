using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtonAction : MonoBehaviour
{
    public Button ButtonNiv2;
    public Button ButtonNiv3;
    public TextMeshProUGUI TextChapeau;
    public TextMeshProUGUI TextCarteMembre;
    public TextMeshProUGUI TextConventionCollective;
 

    /// <summary>
    /// Permet d'afficher un panel transmis en paramètre
    /// </summary>
    /// <param name="PanelAOuvrir">Panel à afficher</param>
    public void AfficherPanel(GameObject PanelAOuvrir)
    {
        PanelAOuvrir.SetActive(true);
        if (GameManager.Instance.PlayerData.Niveau >= 2)
        {
            ButtonNiv2.interactable = true;
        }

        if (GameManager.Instance.PlayerData.Niveau.Equals(3))
        {
            ButtonNiv3.interactable = true;
        }

        TextChapeau.text = GameManager.Instance.PlayerData.Chapeau.ToString();
        TextCarteMembre.text = GameManager.Instance.PlayerData.CarteMembre.ToString();
        TextConventionCollective.text = GameManager.Instance.PlayerData.ConventionCollective.ToString();
    }

    /// <summary>
    /// Permet de ferme aussi le panel actuel
    /// </summary>
    /// <param name="PanelAFermer">Panel à fermer</param>
    public void FermerPanel(GameObject PanelAFermer)
    {
        PanelAFermer.SetActive(false);
    }

    /// <summary>
    /// Permet de charger un niveau
    /// </summary>
    /// <param name="nom">Nom du niveau à charger</param>
    public void ChargerNiveau(string nom)
    {
        SceneManager.LoadScene(nom);
    }



    /// <summary>
    /// Permet de fermer l'application
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }
}
