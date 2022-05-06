// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FzzzBzzz
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton buttonDisplay { get; set; }

		[Outlet]
		AppKit.NSTextField inField { get; set; }

		[Outlet]
		AppKit.NSTextField outField { get; set; }

		[Action ("pushButton:")]
		partial void pushButton (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (inField != null) {
				inField.Dispose ();
				inField = null;
			}

			if (outField != null) {
				outField.Dispose ();
				outField = null;
			}

			if (buttonDisplay != null) {
				buttonDisplay.Dispose ();
				buttonDisplay = null;
			}
		}
	}
}
