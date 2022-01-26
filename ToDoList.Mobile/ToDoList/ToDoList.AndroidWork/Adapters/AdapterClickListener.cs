using Android.Views;
using System;

namespace ToDoList.AndroidWork.Adapters
{
    public class AdapterClickListener<T> : Java.Lang.Object, View.IOnClickListener
    {
        private EventHandler<T> _clickHandler;
        private T _clickHandlerArg;

        public AdapterClickListener(EventHandler<T> clickHandler, T clickHandlerArg)
        {
            _clickHandler = clickHandler;
            _clickHandlerArg = clickHandlerArg;
        }

        public void OnClick(View view)
        {
            _clickHandler?.Invoke(null, _clickHandlerArg);
        }
    }
}