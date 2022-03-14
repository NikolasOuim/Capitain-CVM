using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConventionCollectiveUpgrade : MonoBehaviour
{

    [SerializeField]
    private int _conventionCollective = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.AddConventionCollective(this._conventionCollective);
        }
    }
}
