using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBuilder:IService
    {
        public GameObject Build();
    }
}
