using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HansKindberg.Collections.Generic
{
	public class ObservableEventArgs : CancelEventArgs
	{
		#region Fields

		private readonly IDictionary<string, object> _parameters;

		#endregion

		#region Constructors

		public ObservableEventArgs() : this(new Dictionary<string, object>()) {}

		public ObservableEventArgs(IDictionary<string, object> parameters)
		{
			if(parameters == null)
				throw new ArgumentNullException("parameters");

			this._parameters = parameters;
		}

		#endregion

		#region Properties

		public virtual bool Change { get; set; }

		public virtual IDictionary<string, object> Parameters
		{
			get { return this._parameters; }
		}

		#endregion
	}
}