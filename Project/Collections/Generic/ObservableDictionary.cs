using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;

namespace HansKindberg.Collections.Generic
{
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	public class ObservableDictionary<TKey, TValue> : Observable, IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback
	{
		#region Fields

		private readonly Dictionary<TKey, TValue> _dictionary;

		#endregion

		#region Constructors

		public ObservableDictionary()
		{
			this._dictionary = new Dictionary<TKey, TValue>();
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this._dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		public ObservableDictionary(int capacity)
		{
			this._dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			this._dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		protected ObservableDictionary(SerializationInfo info, StreamingContext context)
		{
			this._dictionary = (Dictionary<TKey, TValue>) Activator.CreateInstance(typeof(Dictionary<TKey, TValue>), BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new object[] {info, context}, null, null);
		}

		#endregion

		#region Properties

		public virtual IEqualityComparer<TKey> Comparer
		{
			get { return this.Dictionary.Comparer; }
		}

		public virtual int Count
		{
			get { return this.Dictionary.Count; }
		}

		protected internal virtual Dictionary<TKey, TValue> Dictionary
		{
			get { return this._dictionary; }
		}

		public virtual bool IsFixedSize
		{
			get { return ((IDictionary) this.Dictionary).IsFixedSize; }
		}

		public virtual bool IsReadOnly
		{
			get { return ((ICollection<KeyValuePair<TKey, TValue>>) this.Dictionary).IsReadOnly; }
		}

		bool IDictionary.IsReadOnly
		{
			get { return ((IDictionary) this.Dictionary).IsReadOnly; }
		}

		public virtual bool IsSynchronized
		{
			get { return ((ICollection) this.Dictionary).IsSynchronized; }
		}

		public virtual TValue this[TKey key]
		{
			get { return this.Dictionary[key]; }
			set { this.Dictionary[key] = value; }
		}

		object IDictionary.this[object key]
		{
			get { return ((IDictionary) this.Dictionary)[key]; }
			set { ((IDictionary) this.Dictionary)[key] = value; }
		}

		public virtual Dictionary<TKey, TValue>.KeyCollection Keys
		{
			get { return this.Dictionary.Keys; }
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get { return this.Dictionary.Keys; }
		}

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
		{
			get { return this.Dictionary.Keys; }
		}

		ICollection IDictionary.Keys
		{
			get { return this.Dictionary.Keys; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.Dictionary).SyncRoot; }
		}

		public virtual Dictionary<TKey, TValue>.ValueCollection Values
		{
			get { return this.Dictionary.Values; }
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get { return this.Dictionary.Values; }
		}

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
		{
			get { return this.Dictionary.Values; }
		}

		ICollection IDictionary.Values
		{
			get { return this.Dictionary.Values; }
		}

		#endregion

		#region Methods

		public virtual void Add(TKey key, TValue value)
		{
			this.Dictionary.Add(key, value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			((ICollection<KeyValuePair<TKey, TValue>>) this.Dictionary).Add(keyValuePair);
		}

		void IDictionary.Add(object key, object value)
		{
			((IDictionary) this.Dictionary).Add(key, value);
		}

		public virtual void Clear()
		{
			this.Dictionary.Clear();
		}

		public virtual bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<TKey, TValue>>) this.Dictionary).Contains(item);
		}

		public virtual bool Contains(object key)
		{
			return ((IDictionary) this.Dictionary).Contains(key);
		}

		public virtual bool ContainsKey(TKey key)
		{
			return this.Dictionary.ContainsKey(key);
		}

		public virtual bool ContainsValue(TValue value)
		{
			return this.Dictionary.ContainsValue(value);
		}

		public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>) this.Dictionary).CopyTo(array, arrayIndex);
		}

		public virtual void CopyTo(Array array, int index)
		{
			((ICollection) this.Dictionary).CopyTo(array, index);
		}

		public virtual Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return (this.Dictionary).GetEnumerator();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.Dictionary.GetEnumerator();
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			this.Dictionary.GetObjectData(info, context);
		}

		public virtual void OnDeserialization(object sender)
		{
			this.Dictionary.OnDeserialization(sender);
		}

		public virtual bool Remove(TKey key)
		{
			return this.Dictionary.Remove(key);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			return ((ICollection<KeyValuePair<TKey, TValue>>) this.Dictionary).Remove(keyValuePair);
		}

		void IDictionary.Remove(object key)
		{
			((IDictionary) this.Dictionary).Remove(key);
		}

		public virtual bool TryGetValue(TKey key, out TValue value)
		{
			return this.Dictionary.TryGetValue(key, out value);
		}

		#endregion
	}
}