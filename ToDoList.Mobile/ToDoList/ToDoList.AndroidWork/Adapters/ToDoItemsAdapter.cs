using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.AndroidWork.Adapters
{
    public class ToDoItemsAdapter : RecyclerView.Adapter
    {
        private IList<ToDoItemModel> _toDoItems;
        public IList<ToDoItemModel> Items
        {
            get => _toDoItems;
            set
            {
                _toDoItems = value;
                NotifyDataSetChanged();
            }
        }

        public ToDoItemsAdapter(IEnumerable<ToDoItemModel> toDoItems)
        {
            if (toDoItems != null)
            {
                _toDoItems = toDoItems.ToList();
            }
        }

        public event EventHandler<ToDoItemModel> ItemClicked;

        public override int ItemCount => _toDoItems?.Count ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = _toDoItems[position];
            var viewHolder = (ToDoItemsAdapterViewHolder)holder;

            viewHolder.Desciption.SetText(item.Description, TextView.BufferType.Normal);
            if (item.Status == ToDoItemStatus.Closed)
            {
                viewHolder.Desciption.PaintFlags = Android.Graphics.PaintFlags.StrikeThruText;
            }
            else
            {
                viewHolder.Desciption.PaintFlags = Android.Graphics.PaintFlags.LinearText;
            }
            viewHolder.ItemView.SetOnClickListener(new AdapterClickListener<ToDoItemModel>(ItemClicked, item));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_toDoItem, parent, false);

            return new ToDoItemsAdapterViewHolder(view);
        }
    }

    internal class ToDoItemsAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Desciption { get; private set; }

        public ToDoItemsAdapterViewHolder(View view) : base(view)
        {
            Desciption = view.FindViewById<TextView>(Resource.Id.toDoItemDescription);
        }
    }
}