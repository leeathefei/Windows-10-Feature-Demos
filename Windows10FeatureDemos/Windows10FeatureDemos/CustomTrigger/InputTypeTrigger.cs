using Windows.Devices.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace Windows10FeatureDemos.CustomTriggers
{
    public class InputTypeTrigger : StateTriggerBase
    {
        private FrameworkElement _targetElement;
        private PointerDeviceType _lastPointerType, _triggerPointerType;

        public FrameworkElement TargetElement
        {
            get
            {
                return _targetElement;
            }
            set
            {
                _targetElement = value;
                _targetElement.AddHandler(FrameworkElement.PointerPressedEvent, new PointerEventHandler(_targetElement_PointerPressed), true);
            }
        }
        public PointerDeviceType PointerType
        {
            get
            {
                return _triggerPointerType;
            }
            set
            {
                _triggerPointerType = value;
            }
        }
        //Handle event to get current values
        private void _targetElement_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _lastPointerType = e.Pointer.PointerDeviceType;
            UpdateTrigger();
        }
        //Logic to evaluate and apply trigger value
        public void UpdateTrigger()
        {
            SetActive(_triggerPointerType == _lastPointerType);
        }
    }
}
