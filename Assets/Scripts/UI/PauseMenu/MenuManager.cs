using UnityEngine;

namespace SoulsLikeTutorial
{
    public abstract class MenuManager : MonoBehaviour
    {
        protected UIManager uiManager;

        protected virtual void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
            GetPanel().Open();
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public abstract void OnConfirm();

        public abstract void OnBack();

        public abstract void OnOption1();

        public virtual void OnTabLeft() { }

        public virtual void OnTabRight() { }

        public virtual void OnNavigateLeft() {
            GetPanel().OnNavigateLeft();
        }

        public virtual void OnNavigateRight() {
            GetPanel().OnNavigateRight();
        }

        public virtual void OnNavigateUp() {
            GetPanel().OnNavigateUp();
        }

        public virtual void OnNavigateDown() {
            GetPanel().OnNavigateDown();
        }

        public virtual void ResetToDefault() { }

        protected abstract Panel GetPanel();
    }
}
