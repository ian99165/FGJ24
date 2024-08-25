using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Project_Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.InstantiatePrefabResource("Music");
        }
    }
}