using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

namespace VRGuitar
{
    public class GestureManager : MonoBehaviour
    {
        public const float MENU_OPEN_TIME = 1.5f;

        public SteamVR_Action_Skeleton skeletonAction;
        [SerializeField] private GameObject pointer;
        [SerializeField] private GameObject progressBar;
        [SerializeField] private Image bar;

        private bool pointing = false;

        public bool IsMenuOpenPose
            => skeletonAction.middleCurl < 0.2 &&
               skeletonAction.ringCurl < 0.2 &&
               skeletonAction.pinkyCurl < 0.2;
        public float ProgressBarFillAmount
        {
            set
            {
                if (value <= 0)
                {
                    progressBar.SetActive(false);
                }
                else
                {
                    progressBar.SetActive(true);
                }
                bar.fillAmount = value;
            }
        }

        void Start()
        {
            pointer.SetActive(false);
        }

        void Update()
        {
            ProcessMenuOpen();
            /*if (IsMenuOpenPose)
            {
                //Invoke("CheckPointerGesture", 0.5f);
                StartCoroutine(CheckPointerGesture());
            }*/
        }

        private float _timer = -1;
        private void ProcessMenuOpen()
        {
            if (IsMenuOpenPose)
            {
                if (_timer < 0)
                {
                    _timer = 0f;
                    ProgressBarFillAmount = 0;
                }
                else if (_timer < MENU_OPEN_TIME)
                {
                    _timer += Time.deltaTime;
                    ProgressBarFillAmount = (_timer / MENU_OPEN_TIME);
                    if (_timer >= MENU_OPEN_TIME)
                    {
                        pointer.SetActive(!pointer.activeSelf);
                    }
                }
                else
                {
                    ProgressBarFillAmount = 0;
                }
            }
            else
            {
                _timer = -1;
                ProgressBarFillAmount = 0;
            }
        }
        /*
            private IEnumerator CheckPointerGesture()
            {
                yield return new WaitForSeconds(0.5f);

                if (IsMenuOpenPose)
                    progressBar.SetActive(true);
                else
                    yield break;

                for (int i = 1; i <= 10; i++)
                {
                    if (IsMenuOpenPose)
                    {
                        yield return new WaitForSeconds(0.15f);
                        bar.fillAmount = i * 0.1f;
                    }
                    else
                    {
                        progressBar.SetActive(false);
                        yield break;
                    }
                }
                yield return null;
                if (!pointing)
                {
                    pointer.SetActive(true);
                    pointing = true;
                    Debug.Log("pointing");
                }
                else
                {
                    pointer.SetActive(false);
                    pointing = false;
                    Debug.Log("Not pointing");
                }
                yield break;
            }*/

        //private async void CheckPointerGesture()
        //{
        //    if (skeletonAction.middleCurl > 0.8 &&
        //        skeletonAction.ringCurl > 0.8 &&
        //        skeletonAction.pinkyCurl > 0.8)
        //        progressBar.SetActive(true);
        //    else
        //        return;

        //    for (int i = 1; i <= 10; i ++)
        //    {
        //        if (skeletonAction.middleCurl > 0.8 &&
        //        skeletonAction.ringCurl > 0.8 &&
        //        skeletonAction.pinkyCurl > 0.8)
        //        {
        //            await Task.Delay(150);
        //            bar.fillAmount = i * 0.1f;
        //        }
        //        else
        //        {
        //            progressBar.SetActive(false);
        //            return;
        //        }
        //    }
        //    await Task.Delay(200);
        //    if (!pointing)
        //    {
        //        pointer.SetActive(true);
        //        pointing = true;
        //        Debug.Log("pointing");
        //    }
        //    else
        //    {
        //        pointer.SetActive(false);
        //        pointing = false;
        //        Debug.Log("Not pointing");
        //    }
        //    return;
        //}
    }
}