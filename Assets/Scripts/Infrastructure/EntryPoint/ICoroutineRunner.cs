using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EntryPoint
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
