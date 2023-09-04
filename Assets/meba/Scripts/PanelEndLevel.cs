using DG.Tweening;
using meba.menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace meba
{
    public class PanelEndLevel : MonoBehaviour
    {
        [SerializeField]
        private Transform p1, p2, p3, p4;

        [SerializeField]
        private Animation endLevelAnimation;

        [SerializeField]
        private ScrollViewLevelMenu levelMenu;

        [SerializeField]
        private Canvas parentCanvas;

        private Transform f1, f2, f3, f4;

        Tween tween;

        private void Start()
        {
            f1 = p1; f2 = p2; f3 = p3; f4 = p4;
            ExtraParticle();
            p1.gameObject.SetActive(true);
            p2.gameObject.SetActive(true);
            p3.gameObject.SetActive(true);
            p4.gameObject.SetActive(true);
            p1.GetComponent<ParticleSystem>().Play();
            p2.GetComponent<ParticleSystem>().Play();
            p3.GetComponent<ParticleSystem>().Play();
            p4.GetComponent<ParticleSystem>().Play();
            Invoke(nameof(KillMe), 5f);
        }

        public void ExtraParticle()
        {
            tween.Kill();
            p1 = f1; p2 = f2; p3 = f3; p4 = f4;
            RandomizeParticle(p1);
            RandomizeParticle(p2);
            RandomizeParticle(p3);
            RandomizeParticle(p4);
            //endLevelAnimation.Play();
        }

        public void Particle()
        {
            RandomizeParticle(p1);
            RandomizeParticle(p2);
        }

        private void RandomizeParticle(Transform tr)
        {
            Vector3 first = tr.position;
            Vector3 rng = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0);
            Vector3 target = tr.position + rng;

            float reachTime = Random.Range(2f, 4f);

            tween = tr.DOMove(target, reachTime);
            Invoke(nameof(ExtraParticle), 4f);
        }

        private void KillMe()
        {
            levelMenu.CloseLevel();
            p1.gameObject.SetActive(false);
            p2.gameObject.SetActive(false);
            p3.gameObject.SetActive(false);
            p4.gameObject.SetActive(false);

            parentCanvas.gameObject.SetActive(false);
        }
    }
}