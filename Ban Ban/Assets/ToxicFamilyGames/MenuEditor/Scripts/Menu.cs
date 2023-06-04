using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames.MenuEditor
{
    [RequireComponent(typeof(Animator), typeof(CanvasGroup))]
    public class Menu : MonoBehaviour
    {
        private bool isOpen = false;
        private Animator animator;
        private CanvasGroup canvasGroup;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup.alpha != 0) isOpen = true;
        }
        public void Open(Menu menu)
        {
            StartCoroutine(Spawn(menu));
        }
        
        public void Open()
        {
            if (isOpen) return;
            isOpen = true;
            animator.SetTrigger("tOpen");
            canvasGroup.blocksRaycasts = true;
        }
        public void Close()
        {
            if (!isOpen) return;
            isOpen = false;
            animator.SetTrigger("tClose");
            canvasGroup.blocksRaycasts = false;
        }
        private IEnumerator Spawn(Menu menu)
        {
            Menu[] menus = FindObjectsOfType<Menu>();
            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].Close();
            }
            yield return new WaitForSeconds(1);
            menu.Open();
        }
    }
}