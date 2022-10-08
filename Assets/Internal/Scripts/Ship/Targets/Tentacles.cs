using Siren.Functionalities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Targets
{
    [RequireComponent(typeof(Target))]
    [RequireComponent(typeof(HasHealth))]
    [RequireComponent(typeof(Moves))]
    [RequireComponent(typeof(Animator))]
    public class Tentacles : MonoBehaviour, ITarget, IHasHealth, IMoves
    {
        private Target m_targetComp;
        private HasHealth m_healthComp;
        private Moves m_moveComp;

        private Animator m_animatorComp;

        #region Inspector

        [SerializeField] private float m_franticSpeed;

        #endregion // Inspector

        // temp hack
        private void Awake() {
            Init();
        }

        private void Update() {
            Move();
        }

        public void Init() {
            m_targetComp = this.GetComponent<Target>();
            m_targetComp.OnEncounterProjectile += HandleProjectileEncountered;

            m_healthComp = this.GetComponent<HasHealth>();
            m_healthComp.Init();
            m_healthComp.OnHealthZero += HandleHealthZero;

            m_moveComp = this.GetComponent<Moves>();

            m_animatorComp = this.GetComponent<Animator>();
        }

        #region Handlers

        // Target

        public void HandleProjectileEncountered(object sender, ProjectileEventArgs args) {
            switch (args.Projectile.GetProjectileType()) {
                case Projectiles.Type.Cannonball:
                    m_healthComp.Damage(args.Projectile.GetBaseDamage());
                    args.Projectile.TriggerDestroySequence();

                    m_animatorComp.speed = m_healthComp.GetCurrHealth() == 1 ? m_franticSpeed : 1;
                    break;
                default:
                    break;
            }
        }

        // Has Health

        public void HandleHealthZero(object sender, EventArgs args) {
            Destroy(this.gameObject);
        }

        #endregion // Handlers

        #region IMoves

        public void Move() {
            m_moveComp.MoveTowardRef();
        }

        #endregion // IMoves
    }
}
