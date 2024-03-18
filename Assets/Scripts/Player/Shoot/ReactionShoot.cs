using UnityEngine;

public class ReactionShoot : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void EnableSound()
    {
        _audioSource.Play();
    }

    public void EnableAnimation()
    {
        _animator.Play("Shooting", 0, 0);
    }
}
