package md5dd2f43a835704629d9f576d6d846464c;


public class DataFormViewerProvider
	extends md5dd2f43a835704629d9f576d6d846464c.DataFormViewProviderBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", DataFormViewerProvider.class, __md_methods);
	}


	public DataFormViewerProvider ()
	{
		super ();
		if (getClass () == DataFormViewerProvider.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public DataFormViewerProvider (md5594e48edf6f8d539e2dcd8d54f889365.DataFormRenderer p0, com.telerik.widget.dataform.visualization.RadDataForm p1)
	{
		super ();
		if (getClass () == DataFormViewerProvider.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.InputRenderer.Android.DataForm.DataFormViewerProvider, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null", "Telerik.XamarinForms.InputRenderer.Android.DataFormRenderer, Telerik.XamarinForms.Input, Version=2017.3.1123.240, Culture=neutral, PublicKeyToken=null:Com.Telerik.Widget.Dataform.Visualization.RadDataForm, Telerik.Xamarin.Android.Input, Version=2017.3.1123.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
