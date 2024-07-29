using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MT_Toggle
{
    public class M_ToggleWithSound : Toggle
    {
        private bool pointerWasUp;

        private ButtonSoundRes buttonSounds;

        protected override void Awake()
        {
            base.Awake();
            buttonSounds = GetComponent<ButtonSoundRes>();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (buttonSounds != null)
            {
                buttonSounds.PlayPressedSound();
            }

            base.OnPointerClick(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            pointerWasUp = true;
            base.OnPointerUp(eventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (pointerWasUp)
            {
                pointerWasUp = false;
                base.OnPointerEnter(eventData);
            }
            else
            {
                if (buttonSounds != null)
                {
                    buttonSounds.PlayHoverSound();
                }

                base.OnPointerEnter(eventData);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            pointerWasUp = false;
            base.OnPointerExit(eventData);
        }
    }
}
