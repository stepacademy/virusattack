﻿/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.VirusAttackSource.AMVCC {

    /// <summary>
    /// Extension to support generic applications.
    /// </summary>
    public class ButtonView<T> : ButtonView where T : BaseApplication {

        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        new public T app { get { return (T)base.app; } }
    }

    /// <summary>
    /// Base class for all Button features related classes.
    /// </summary>
    public class ButtonView : NotificationView,
        IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

        /// <summary>
        /// Flag that indicates if the input is pressed on this element.
        /// </summary>
        public bool down;

        /// <summary>
        /// Flag that indicates the input is over this element.
        /// </summary>
        public bool over;

        /// <summary>
        /// Flag that indicates how many seconds the input is being held.
        /// </summary>
        public float hold;

        /// <summary>
        /// Init.
        /// </summary>
        void Start() {
            hold = 0f;
            down = false;
            over = false;
        }

        /// <summary>
        /// Callback called when mouse is pressed on the element.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData) {
            down = true;
            hold = 0f;
            Notify(notification + "@down");
        }

        /// <summary>
        /// Callback called when mouse is pressed and released over the element.
        /// </summary>
        public void OnPointerClick(PointerEventData eventData) {
            Notify(notification + "@click");
        }

        /// <summary>
        /// Callback called when the input is released.
        /// </summary>
        public void OnPointerUp(PointerEventData eventData) {
            down = false;
            Notify(notification + "@up");
            hold = 0f;
        }

        /// <summary>
        /// Callback called when input enters this element.
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData) {
            over = true;
            Notify(notification + "@over");
        }

        /// <summary>
        /// Callback called when input leaves this element.
        /// </summary>
        public void OnPointerExit(PointerEventData eventData) {
            over = false;
            Notify(notification + "@out");
        }

        /// <summary>
        /// Updates the view input state.
        /// </summary>
        void Update() {
            if (down) {
                Notify(notification + "@hold");
                hold += Time.unscaledDeltaTime;
            }
        }
    }
}