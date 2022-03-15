using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class NikolasEnnemy : MonoBehaviour
{
	[SerializeField]
    private float _vitesse = 2f;
	[SerializeField]
	private Transform _cible = null;
	private float _distanceSeuil = 0.3f;
	private SpriteRenderer _sr;
    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        Vector3 direction = _cible.position - this.transform.position;
        if (playerInTerritory == true)
        {
            if (Vector3.Distance(this.transform.position, _cible.position) < _distanceSeuil)
            {
                transform.LookAt(_cible.position);
                this.transform.Translate(direction.normalized * _vitesse * Time.deltaTime, Space.World);
            }
        }
    }


}

//Source :
// https://answers.unity.com/questions/938221/basic-enemy-ai-in-c.html