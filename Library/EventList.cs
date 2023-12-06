using System.Collections.Generic;

namespace Library
{
    public class ListEventArgs : EventArgs
    {
        public string EventName { get; set; }
    }
    public class EventList<T>
    {
        private System.Collections.Generic.List<EventHandler<ListEventArgs>> _addHandlers = new System.Collections.Generic.List<EventHandler<ListEventArgs>>();
        private System.Collections.Generic.List<EventHandler<ListEventArgs>> _insertHandlers = new System.Collections.Generic.List<EventHandler<ListEventArgs>>();
        private System.Collections.Generic.List<EventHandler<ListEventArgs>> _removeHandlers = new System.Collections.Generic.List<EventHandler<ListEventArgs>>();
        private System.Collections.Generic.List<EventHandler<ListEventArgs>> _removeAtHandlers = new System.Collections.Generic.List<EventHandler<ListEventArgs>>();


        private List<T> list = new List<T>();
        public int Count { get { return list.Count; } }
        
        public event EventHandler<ListEventArgs>? Add
        {
            add { _addHandlers.Add(value); }
            remove { _addHandlers.Remove(value); }
        }
        public void OnAdd(T data)
        {
            list.Add(data);
            CallEvent(_addHandlers, "Add");
        }

        public event EventHandler<ListEventArgs>? Insert
        {
            add { _insertHandlers.Add(value); }
            remove { _insertHandlers.Remove(value); }
        }
        public void OnInsert(int index, T data)
        {
            list.Insert(index, data);
            CallEvent(_insertHandlers, "Insert");
        }

        public event EventHandler<ListEventArgs>? Remove
        {
            add { _removeHandlers.Add(value); }
            remove { _removeHandlers.Remove(value); }
        }
        public void OnRemove(T data)
        {
            list.Remove(data);
            CallEvent(_removeHandlers, "Remove");
        }
        
        public event EventHandler<ListEventArgs>? RemoveAt
        {
            add { _removeAtHandlers.Add(value); }
            remove { _removeAtHandlers.Remove(value); }
        }
        public void OnRemoveAt(int index)
        {
            list.RemoveAt(index);
            CallEvent(_removeAtHandlers, "RemoveAt");
        }

        private void CallEvent(System.Collections.Generic.List<EventHandler<ListEventArgs>> handlerList, string eventName)
        {
            foreach (var handler in handlerList)
            {
                handler(this, new ListEventArgs { EventName = eventName });
            }
        }
    }
}
