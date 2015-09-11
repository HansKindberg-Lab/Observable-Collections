using System;

namespace HansKindberg.Collections.Generic
{
	public abstract class Observable
	{
		#region Events

		public event EventHandler<ObservableEventArgs> Added;
		public event EventHandler<ObservableEventArgs> Adding;

		#endregion

		#region Methods

		protected internal virtual void OnAdded(ObservableEventArgs e)
		{
			this.OnAdded(this, e);
		}

		protected internal virtual void OnAdded(object sender, ObservableEventArgs e)
		{
			if(this.Added != null)
				this.Added(sender, e);
		}

		protected internal virtual void OnAdding(ObservableEventArgs e)
		{
			this.OnAdding(this, e);
		}

		protected internal virtual void OnAdding(object sender, ObservableEventArgs e)
		{
			if(this.Adding != null)
				this.Adding(sender, e);
		}

		#endregion
	}
}