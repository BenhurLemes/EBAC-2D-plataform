using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Variáveis privadas")]
    [SerializeField] ProjecttileBase prefabprojecttile;
    [SerializeField] Transform positionToShoot;
    private float timeToShoot = .2f;
    private Coroutine _currentCoroutine;
    [SerializeField] Transform playerSideReference;

    #region UNITY METHODS
    // Start is called before the first frame update
    void Start()
    {
        if(prefabprojecttile == null)
        {
            prefabprojecttile.GetComponent<ProjecttileBase>();
        }
        playerSideReference = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
            StopAllCoroutines();
        }
    }
    #endregion

    #region PRIVATE METHODS
    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeToShoot);
        }
    }

    void Shoot()
    {
        var projecttile = Instantiate(prefabprojecttile);
        projecttile.transform.position = positionToShoot.position;
        projecttile.setSide(playerSideReference.localScale.x);
    }
    #endregion
}
