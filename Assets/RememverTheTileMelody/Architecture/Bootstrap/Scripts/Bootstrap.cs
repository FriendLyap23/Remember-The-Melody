using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private IInitialization _initialization;
    [SerializeField] private List<GameObject> initializations;

    [Inject]
    public void Constructor(IInitialization initialization) 
    {
        _initialization = initialization;
    }

    private void Awake()
    {
        StartCoroutine(InitializeComponentsSequentially());
    }

    public IEnumerator InitializeComponentsSequentially() 
    {
        foreach (var initObject in initializations)
        {
            var initComponent = initObject.GetComponent<IInitialization>();

            if (initComponent != null) 
            {
                initComponent.Initialization();
                yield return new WaitForSeconds(0.001f);
            }    
            else
                Debug.LogError("Object does not have a component implementing IInitialization.");
        }
    }
}