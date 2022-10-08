using Siren.Targets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{
    interface ITarget
    {
        void HandleProjectileEncountered(object sender, ProjectileEventArgs args);
    }
}