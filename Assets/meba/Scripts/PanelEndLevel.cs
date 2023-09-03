using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace meba
{
    public class PanelEndLevel : MonoBehaviour
    {
        [SerializeField]
        private Transform p1, p2, p3, p4;

        private void Start()
        {
            ExtraParticle();
        }

        public void ExtraParticle()
        {
            RandomizeParticle(p1);
            RandomizeParticle(p2);
            RandomizeParticle(p3);
            RandomizeParticle(p4);
        }

        public void Particle()
        {
            RandomizeParticle(p1);
            RandomizeParticle(p2);
        }

        private void RandomizeParticle(Transform tr)
        {
            Vector3 rng = new Vector3(Random.Range(-500f, 500f), Random.Range(-500f, 500f), 0);
            Vector3 target = tr.position + rng;

            float reachTime = Random.Range(50f, 80f);

            tr.DOMove(target, reachTime);
        }
    }
}