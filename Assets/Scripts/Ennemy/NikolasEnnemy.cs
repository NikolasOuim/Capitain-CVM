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
    GameObject player;
    NikolasEnnemyBehaviour nikolasEnnemyBehaviour;

    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        _cible = player.transform;
        nikolasEnnemyBehaviour = gameObject.GetComponent<NikolasEnnemyBehaviour>();
    }

    private void Update()
    {
        Vector3 direction = _cible.position - this.transform.position;

        if (nikolasEnnemyBehaviour.PlayerEnTerritoire == true)
        {
            if (direction.x < 0 && !_sr.flipX) _sr.flipX = true;
            else if (direction.x > 0 && _sr.flipX) _sr.flipX = false;

            if (Vector3.Distance(this.transform.position, _cible.position) < _distanceSeuil)
            {
                _cible = player.transform;
                transform.LookAt(_cible.position);
                this.transform.Translate(direction.normalized * _vitesse * Time.deltaTime, Space.World);
            }
        }
    }
}

//Source :
// https://answers.unity.com/questions/938221/basic-enemy-ai-in-c.html