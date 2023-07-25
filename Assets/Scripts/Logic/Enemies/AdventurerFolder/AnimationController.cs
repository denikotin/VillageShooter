using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.AdventurerFolder
{
    public class AnimationController: MonoBehaviour
    {
        private Animator _animator;
        private int _isWalking;
        private int _isPunching;

        private void Start()
        {
            _animator = GetComponent<Animator>();   
            _isWalking = Animator.StringToHash("isWalking");
            _isPunching = Animator.StringToHash("Punch");
        }

        public void EnableRunAnimation() => _animator.SetBool(_isWalking, true);
        public void DisableRunAnimation() => _animator.SetBool(_isWalking, false);
        public void EnablePunchAnimation() => _animator.SetTrigger(_isPunching);

        public void Disable()
        {
            _animator.enabled = false;
            this.enabled = false;
        }

    }
}
