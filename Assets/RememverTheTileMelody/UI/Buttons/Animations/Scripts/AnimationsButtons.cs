using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class AnimationsButtons : MonoBehaviour, IInitialization
{
    [SerializeField] private Animator _animator;
    private Score _level;

    [Inject]
    public void Constructor(Score level)
    {
        _level = level;
    }

    private void OnEnable()
    {
        _level.OnAnimationTile += Animationb;
    }

    public void Initialization()
    {
        _animator.GetComponent<Animator>();
        _animator.SetTrigger("ButtonsAnimation");
    }

    private void Animationb(string nameTrigger) 
    {
        _animator.GetComponent<Animator>();
        _animator.SetTrigger(nameTrigger);
    }

    private void OnDisable()
    {
        _level.OnAnimationTile -= Animationb;
    }
}
