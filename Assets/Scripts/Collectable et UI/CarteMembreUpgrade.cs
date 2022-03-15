using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteMembreUpgrade : MonoBehaviour
{

    [SerializeField]
    private int _carteMembre = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.AddCarteMembre(this._carteMembre);
        }
    }
}
