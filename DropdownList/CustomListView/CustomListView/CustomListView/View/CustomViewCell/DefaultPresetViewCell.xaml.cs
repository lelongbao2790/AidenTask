﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomListView.View.CustomViewCell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DefaultPresetViewCell : ViewCell
	{
		public DefaultPresetViewCell ()
		{
			InitializeComponent ();
		}
	}
}