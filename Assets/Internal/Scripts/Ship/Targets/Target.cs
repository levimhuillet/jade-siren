using Siren.Projectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Targets
{
    public class ProjectileEventArgs : EventArgs {
        public Projectile Projectile;

        public ProjectileEventArgs(Projectile projectile) {
           Projectile = projectile;
        }
    }

    [RequireComponent(typeof(Collider2D))]
    public class Target : MonoBehaviour
    {

        public event EventHandler<ProjectileEventArgs> OnEncounterProjectile;

        #region External

        public void EncounterProjectile(Projectile projectile) {
            OnEncounterProjectile?.Invoke(this, new ProjectileEventArgs(projectile));
        }

        #endregion // External
    }
}