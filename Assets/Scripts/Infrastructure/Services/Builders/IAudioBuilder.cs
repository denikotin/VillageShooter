using Assets.Scripts.Data.Enums;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public interface IAudioBuilder:IBuilder
    {
        public GameObject Build(SceneID sceneID);
    }
}
