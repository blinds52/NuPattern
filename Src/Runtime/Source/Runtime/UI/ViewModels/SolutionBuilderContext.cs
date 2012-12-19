﻿using System;

namespace NuPattern.Runtime.UI
{
	/// <summary>
	/// Defines the needed classes for the <see cref="SolutionBuilderViewModel"/>.
	/// </summary>
	[CLSCompliant(false)]
	public class SolutionBuilderContext
	{
		/// <summary>
		/// Gets the binding factory.
		/// </summary>
		public IBindingFactory BindingFactory { get; internal set; }

		/// <summary>
		/// Gets or sets the solution builder.
		/// </summary>
		public SolutionBuilderViewModel SolutionBuilder { get; internal set; }

		/// <summary>
		/// Gets the pattern manager.
		/// </summary>
		public IPatternManager PatternManager { get; internal set; }

		/// <summary>
		/// Gets the set selected action.
		/// </summary>
		public Action<ProductElementViewModel> SetSelected { get; internal set; }

		/// <summary>
		/// Gets the show properties action.
		/// </summary>
		public Action ShowProperties { get; internal set; }

		/// <summary>
		/// Gets the new pattern dialog factory.
		/// </summary>
		public Func<object, IDialogWindow> NewProductDialogFactory { get; internal set; }

		/// <summary>
		/// Gets the new node dialog factory.
		/// </summary>
		public Func<object, IDialogWindow> NewNodeDialogFactory { get; internal set; }

		/// <summary>
		/// Gets the user message service.
		/// </summary>
		public IUserMessageService UserMessageService { get; internal set; }
	}
}