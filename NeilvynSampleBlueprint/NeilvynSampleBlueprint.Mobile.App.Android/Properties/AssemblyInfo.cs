using Android.App;
using NeilvynSampleBlueprint.Mobile.Common.Constants;
using System.Reflection;
using System.Runtime.InteropServices;
using Xamarin.Forms;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NeilvynSampleBlueprint.Mobile.App.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NeilvynSampleBlueprint.Mobile.App.Android")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: ResolutionGroupName(AppConstants.EffectsNamespace)]

#if DEBUG
// Used by Seq in development to communicate with http://10.0.2.2 (localhost)
[assembly: Application(UsesCleartextTraffic = true)]
#endif