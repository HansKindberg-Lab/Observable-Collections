using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.Collections.Generic
{
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public class ObservableList<T> : Observable, IList<T>, IList, IReadOnlyList<T>
	{
		#region Fields

		private readonly List<T> _list;

		#endregion

		#region Constructors

		public ObservableList()
		{
			this._list = new List<T>();
		}

		public ObservableList(IEnumerable<T> collection)
		{
			this._list = new List<T>(collection);
		}

		public ObservableList(int capacity)
		{
			this._list = new List<T>(capacity);
		}

		#endregion

		#region Properties

		public virtual int Capacity
		{
			get { return this.List.Capacity; }
			set { this.List.Capacity = value; }
		}

		public virtual int Count
		{
			get { return this.List.Count; }
		}

		public virtual bool IsFixedSize
		{
			get { return ((IList) this.List).IsFixedSize; }
		}

		public virtual bool IsReadOnly
		{
			get { return ((ICollection<T>) this.List).IsReadOnly; }
		}

		bool IList.IsReadOnly
		{
			get { return ((IList) this.List).IsReadOnly; }
		}

		public virtual bool IsSynchronized
		{
			get { return ((ICollection) this.List).IsSynchronized; }
		}

		public virtual T this[int index]
		{
			get { return this.List[index]; }
			set { this.List[index] = value; }
		}

		object IList.this[int index]
		{
			get { return ((IList) this.List)[index]; }
			set { ((IList) this.List)[index] = value; }
		}

		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected internal virtual List<T> List
		{
			get { return this._list; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.List).SyncRoot; }
		}

		#endregion

		#region Methods

		public virtual void Add(T item)
		{
			const string itemParameterName = "item";

			var e = new ObservableEventArgs(new Dictionary<string, object> {{itemParameterName, item}});

			this.OnAdding(e);

			if(e.Cancel)
				return;

			if(e.Change)
				this.List.Add((T) e.Parameters[itemParameterName]);
			else
				this.List.Add(item);

			this.OnAdded(e);
		}

		int IList.Add(object item)
		{
			return ((IList) this.List).Add(item);
		}

		public virtual void AddRange(IEnumerable<T> collection)
		{
			this.List.AddRange(collection);
		}

		public virtual ReadOnlyCollection<T> AsReadOnly()
		{
			return this.List.AsReadOnly();
		}

		public virtual int BinarySearch(T item)
		{
			return this.List.BinarySearch(item);
		}

		public virtual int BinarySearch(T item, IComparer<T> comparer)
		{
			return this.List.BinarySearch(item, comparer);
		}

		public virtual int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return this.List.BinarySearch(index, count, item, comparer);
		}

		public virtual void Clear()
		{
			this.List.Clear();
		}

		public virtual bool Contains(T item)
		{
			return this.List.Contains(item);
		}

		bool IList.Contains(object item)
		{
			return ((IList) this.List).Contains(item);
		}

		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public virtual List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return this.List.ConvertAll(converter);
		}

		public virtual void CopyTo(T[] array)
		{
			this.List.CopyTo(array);
		}

		public virtual void CopyTo(T[] array, int arrayIndex)
		{
			this.List.CopyTo(array, arrayIndex);
		}

		public virtual void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			this.List.CopyTo(index, array, arrayIndex, count);
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			((ICollection) this.List).CopyTo(array, arrayIndex);
		}

		public virtual bool Exists(Predicate<T> match)
		{
			return this.List.Exists(match);
		}

		public virtual T Find(Predicate<T> match)
		{
			return this.List.Find(match);
		}

		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public virtual List<T> FindAll(Predicate<T> match)
		{
			return this.List.FindAll(match);
		}

		public virtual int FindIndex(Predicate<T> match)
		{
			return this.List.FindIndex(match);
		}

		public virtual int FindIndex(int startIndex, Predicate<T> match)
		{
			return this.List.FindIndex(startIndex, match);
		}

		public virtual int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return this.List.FindIndex(startIndex, count, match);
		}

		public virtual T FindLast(Predicate<T> match)
		{
			return this.List.FindLast(match);
		}

		public virtual int FindLastIndex(Predicate<T> match)
		{
			return this.List.FindLastIndex(match);
		}

		public virtual int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return this.List.FindLastIndex(startIndex, match);
		}

		public virtual int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return this.List.FindLastIndex(startIndex, count, match);
		}

		public virtual void ForEach(Action<T> action)
		{
			this.List.ForEach(action);
		}

		public virtual List<T>.Enumerator GetEnumerator()
		{
			return this.List.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.List.GetEnumerator();
		}

		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public virtual List<T> GetRange(int index, int count)
		{
			return this.List.GetRange(index, count);
		}

		public virtual int IndexOf(T item)
		{
			return this.List.IndexOf(item);
		}

		public virtual int IndexOf(T item, int index)
		{
			return this.List.IndexOf(item, index);
		}

		public virtual int IndexOf(T item, int index, int count)
		{
			return this.List.IndexOf(item, index, count);
		}

		int IList.IndexOf(object item)
		{
			return ((IList) this.List).IndexOf(item);
		}

		public virtual void Insert(int index, T item)
		{
			this.List.Insert(index, item);
		}

		void IList.Insert(int index, object item)
		{
			((IList) this.List).Insert(index, item);
		}

		public virtual void InsertRange(int index, IEnumerable<T> collection)
		{
			this.List.InsertRange(index, collection);
		}

		public virtual int LastIndexOf(T item)
		{
			return this.List.LastIndexOf(item);
		}

		public virtual int LastIndexOf(T item, int index)
		{
			return this.List.LastIndexOf(item, index);
		}

		public virtual int LastIndexOf(T item, int index, int count)
		{
			return this.List.LastIndexOf(item, index, count);
		}

		public virtual bool Remove(T item)
		{
			return this.List.Remove(item);
		}

		void IList.Remove(object item)
		{
			((IList) this.List).Remove(item);
		}

		public virtual int RemoveAll(Predicate<T> match)
		{
			return this.List.RemoveAll(match);
		}

		public virtual void RemoveAt(int index)
		{
			this.List.RemoveAt(index);
		}

		public virtual void RemoveRange(int index, int count)
		{
			this.List.RemoveRange(index, count);
		}

		public virtual void Reverse()
		{
			this.List.Reverse();
		}

		public virtual void Reverse(int index, int count)
		{
			this.List.Reverse(index, count);
		}

		public virtual void Sort()
		{
			this.List.Sort();
		}

		public virtual void Sort(IComparer<T> comparer)
		{
			this.List.Sort(comparer);
		}

		public virtual void Sort(Comparison<T> comparison)
		{
			this.List.Sort(comparison);
		}

		public virtual void Sort(int index, int count, IComparer<T> comparer)
		{
			this.List.Sort(index, count, comparer);
		}

		public virtual T[] ToArray()
		{
			return this.List.ToArray();
		}

		public virtual void TrimExcess()
		{
			this.List.TrimExcess();
		}

		public virtual bool TrueForAll(Predicate<T> match)
		{
			return this.List.TrueForAll(match);
		}

		#endregion
	}
}